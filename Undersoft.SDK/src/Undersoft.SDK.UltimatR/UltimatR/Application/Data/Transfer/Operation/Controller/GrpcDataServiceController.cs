using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.Json;

namespace UltimatR
{
    [LinkedResult]
    [IgnoreApi]
    [GrpcService]
    public class GrpcDataServiceController<TKey, TEntry, TReport, TEntity, TDto> : IGrpcDataServiceController<TKey, TEntity, TDto> where TDto : Dto
        where TEntity : Entity
        where TEntry : IDataStore
        where TReport : IDataStore
    {
        protected Func<TKey, Func<TDto, object>> _keysetter = k => e => e.SetId(k);
        protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher;
        protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
        protected readonly IUltimatr _ultimatr;
        protected readonly PublishMode _publishMode;


        public GrpcDataServiceController() : this(new Ultimatr(), null, k => e => e.SetId(k), null, PublishMode.PropagateCommand) { }

        public GrpcDataServiceController(IUltimatr ultimatr,
            Func<TDto, Expression<Func<TEntity, bool>>> predicate,
            Func<TKey, Func<TDto, object>> keysetter,
            Func<TKey, Expression<Func<TEntity, bool>>> keymatcher,
            PublishMode publishMode = PublishMode.PropagateCommand
        )
        {
            _keymatcher = keymatcher;
            _keysetter = keysetter;
            _ultimatr = ultimatr;
            _publishMode = publishMode;
        }

        public virtual async Task<IEnumerable<TDto>> Get()
        {
            return await _ultimatr.Send(new GetAll<TReport, TEntity, TDto>(0, 0)).ConfigureAwait(true);
        }

        public virtual async Task<int> Count()
        {
            return await Task.Run(() => _ultimatr.use<TReport, TEntity>().Count());
        }

        public virtual async Task<TDto> Get(TKey key)
        {
            Task<TDto> query =
                (_keymatcher == null)
                    ? _ultimatr.Send(new FindOne<TReport, TEntity, TDto>(key))
                    : _ultimatr.Send(new FindOne<TReport, TEntity, TDto>(_keymatcher(key)));

            return await query.ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TDto>> Get(int offset, int limit)
        {
            return
                await _ultimatr
                    .Send(new GetAll<TReport, TEntity, TDto>(offset, limit))
                    .ConfigureAwait(true);
        }

        public virtual async Task<IEnumerable<TDto>> Post(int offset, int limit, QueryItems query)
        {
            query.Filter.ForEach(
                (fi) =>
                    fi.Value = JsonSerializer.Deserialize(
                        ((JsonElement)fi.Value).GetRawText(),
                        Type.GetType($"System.{fi.Type}", null, null, false, true)
                    )
            );

            return
                await _ultimatr
                    .Send(
                        new FilterData<TReport, TEntity, TDto>(offset, limit,
                            new FilterExpression<TEntity>(query.Filter).Create(),
                            new SortExpression<TEntity>(query.Sort)
                        )
                    )
                    .ConfigureAwait(false);
        }

        public virtual async Task<string[]> Post([FromBody] TDto[] dtos)
        {
            var result = await _ultimatr.Send(new CreateDtoSet<TEntry, TEntity, TDto>
                                                        (_publishMode, dtos)).ConfigureAwait(false);
            var response = result.ForEach(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages).ToArray();
            return response;
        }

        public virtual async Task<string[]> Post([FromRoute] TKey key, [FromBody] TDto dto)
        {
            var result = await _ultimatr.Send(new CreateDtoSet<TEntry, TEntity, TDto>
                                                    (_publishMode, new[] { dto }))
                                                        .ConfigureAwait(false);
            var response = result.ForEach(c => (c.IsValid)
                                       ? c.Id.ToString()
                                       : c.ErrorMessages).ToArray();
            return response;
        }

        public virtual async Task<string[]> Patch([FromBody] TDto[] dtos)
        {
            var result = await _ultimatr.Send(new ChangeDtoSet<TEntry, TEntity, TDto>
                                                                    (_publishMode, dtos, _predicate))
                                                                        .ConfigureAwait(false);
            var response = result.ForEach(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages).ToArray();
            return response;
        }

        public virtual async Task<string[]> Patch([FromRoute] TKey key, [FromBody] TDto dto)
        {
            _keysetter(key).Invoke(dto);

            var result = await _ultimatr.Send(new ChangeDtoSet<TEntry, TEntity, TDto>
                                                  (_publishMode, new[] { dto }, _predicate))
                                                     .ConfigureAwait(false);

            var response = result.ForEach(c => (c.IsValid)
                                       ? c.Id.ToString()
                                       : c.ErrorMessages).ToArray();
            return response;
        }

        public virtual async Task<string[]> Put([FromBody] TDto[] dtos)
        {
            var result = await _ultimatr.Send(new UpdateDtoSet<TEntry, TEntity, TDto>
                                                                        (_publishMode, dtos, _predicate))
                                                                                    .ConfigureAwait(false);

            var response = result.ForEach(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages).ToArray();
            return response;
        }

        public virtual async Task<string[]> Put([FromRoute] TKey key, [FromBody] TDto dto)
        {
            _keysetter(key).Invoke(dto);

            var result = await _ultimatr.Send(new UpdateDtoSet<TEntry, TEntity, TDto>
                                                        (_publishMode, new[] { dto }, _predicate))
                                                            .ConfigureAwait(false);

            var response = result.ForEach(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages).ToArray();
            return response;
        }

        public virtual async Task<string[]> Delete([FromBody] TDto[] dtos)
        {
            var result = await _ultimatr.Send(new DeleteDtoSet<TEntry, TEntity, TDto>
                                                                (_publishMode, dtos))
                                                                 .ConfigureAwait(false);

            var response = result.ForEach(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages).ToArray();
            return response;
        }

        public virtual async Task<string[]> Delete(TKey key, TDto dto)
        {
            _keysetter(key).Invoke(dto);

            var result = await _ultimatr.Send(new DeleteDtoSet<TEntry, TEntity, TDto>
                                                                 (_publishMode, new[] { dto }))
                                                                        .ConfigureAwait(false);

            var response = result.ForEach(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages).ToArray();
            return response;
        }
    }
}
