using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.Json;

namespace RadicalR
{
    [LinkedResult]
    [GrpcService]
    public class GrpcDataServiceController<TKey, TEntry, TReport, TEntity, TDto> : IGrpcDataServiceController<TKey, TEntity, TDto> where TDto : Dto
        where TEntity : Entity
        where TEntry : IDataStore
        where TReport : IDataStore
    {
        protected Func<TKey, Func<TDto, object>> _keysetter = k => e => e.SetId(k);
        protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher;
        protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
        protected readonly IRadicalr _radicalr;
        protected readonly PublishMode _publishMode;

        public GrpcDataServiceController() : this(new Radicalr(), null, k => e => e.SetId(k), null, PublishMode.PropagateCommand) { }

        public GrpcDataServiceController(IRadicalr radicalr,
            Func<TDto, Expression<Func<TEntity, bool>>> predicate,
            Func<TKey, Func<TDto, object>> keysetter,
            Func<TKey, Expression<Func<TEntity, bool>>> keymatcher,
            PublishMode publishMode = PublishMode.PropagateCommand
        )
        {
            _keymatcher = keymatcher;
            _keysetter = keysetter;
            _radicalr = radicalr;
            _publishMode = publishMode;
        }

        public virtual async Task<IEnumerable<TDto>> All()
        {
            return await _radicalr.Send(new GetAll<TReport, TEntity, TDto>(0, 0)).ConfigureAwait(true);
        }

        public virtual async Task<int> Count()
        {
            return await Task.Run(() => _radicalr.use<TReport, TEntity>().Count());
        }

        public virtual async Task<IEnumerable<TDto>> Range(int offset, int limit)
        {
            return
                await _radicalr
                    .Send(new GetAll<TReport, TEntity, TDto>(offset, limit))
                    .ConfigureAwait(true);
        }

        public virtual async Task<IEnumerable<TDto>> Query(int offset, int limit, QueryItems query)
        {
            query.Filter.ForEach(
                (fi) =>
                    fi.Value = JsonSerializer.Deserialize(
                        ((JsonElement)fi.Value).GetRawText(),
                        Type.GetType($"System.{fi.Type}", null, null, false, true)
                    )
            );

            return
                await _radicalr
                    .Send(
                        new FilterData<TReport, TEntity, TDto>(offset, limit,
                            new FilterExpression<TEntity>(query.Filter).Create(),
                            new SortExpression<TEntity>(query.Sort)
                        )
                    )
                    .ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<string>> Creates([FromBody] TDto[] dtos)
        {
            var result = await _radicalr.Send(new CreateDtoSet<TEntry, TEntity, TDto>
                                                        (_publishMode, dtos)).ConfigureAwait(false);
            var response = result.ForEach(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages).ToArray();
            return response;
        }

        public virtual async Task<IEnumerable<string>> Changes([FromBody] TDto[] dtos)
        {
            var result = await _radicalr.Send(new ChangeDtoSet<TEntry, TEntity, TDto>
                                                                    (_publishMode, dtos, _predicate))
                                                                        .ConfigureAwait(false);
            var response = result.ForEach(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages).ToArray();
            return response;
        }

        public virtual async Task<IEnumerable<string>> Updates([FromBody] TDto[] dtos)
        {
            var result = await _radicalr.Send(new UpdateDtoSet<TEntry, TEntity, TDto>
                                                                        (_publishMode, dtos, _predicate))
                                                                                    .ConfigureAwait(false);

            var response = result.ForEach(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages).ToArray();
            return response;
        }

        public virtual async Task<IEnumerable<string>> Deletes([FromBody] TDto[] dtos)
        {
            var result = await _radicalr.Send(new DeleteDtoSet<TEntry, TEntity, TDto>
                                                                (_publishMode, dtos))
                                                                 .ConfigureAwait(false);

            var response = result.ForEach(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages).ToArray();
            return response;
        }
    }
}
