using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text.Json;

namespace RadicalR.Server
{
    [LinkedResult]
    [StreamService]
    public class StreamEventController<TKey, TStore, TEntity, TDto> : IStreamEventController<TDto> where TDto : Dto
        where TEntity : Entity
        where TStore : IDataStore
    {
        protected Func<TKey, Func<TDto, object>> _keysetter = k => e => e.SetId(k);
        protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher;
        protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
        protected readonly IRadicalr _radicalr;
        protected readonly PublishMode _publishMode;

        public StreamEventController() : this(new Radicalr(), null, k => e => e.SetId(k), null, PublishMode.PropagateCommand) { }

        public StreamEventController(IRadicalr radicalr,
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

        public virtual IAsyncEnumerable<TDto> All()
        {
            return _radicalr.CreateStream(new GetAsync<TStore, TEntity, TDto>(0, 0));
        }

        public virtual async Task<int> Count()
        {
            return await Task.Run(() => _radicalr.use<TStore, TEntity>().Count());
        }

        public virtual IAsyncEnumerable<TDto> Range(int offset, int limit)
        {
            return _radicalr.CreateStream(new GetAsync<TStore, TEntity, TDto>(offset, limit));
        }

        public virtual IAsyncEnumerable<TDto> Query(int offset, int limit, QueryItems query)
        {
            query.Filter.ForEach(
                (fi) =>
                    fi.Value = JsonSerializer.Deserialize(
                        ((JsonElement)fi.Value).GetRawText(),
                        Type.GetType($"System.{fi.Type}", null, null, false, true)
                    )
            );

            return
                _radicalr
                    .CreateStream(
                        new FilterAsync<TStore, TEntity, TDto>(offset, limit,
                            new FilterExpression<TEntity>(query.Filter).Create(),
                            new SortExpression<TEntity>(query.Sort)
                        )
                    );
        }

        public virtual IAsyncEnumerable<string> Creates([FromBody] TDto[] dtos)
        {
            var result = _radicalr.CreateStream(new CreateSetAsync<TStore, TEntity, TDto>
                                                        (_publishMode, dtos));

            var response = result.ForEachAsync(c => (c.IsValid)
                                                   ? c.Id.ToString()
                                                   : c.ErrorMessages);
            return response;
        }

        public virtual IAsyncEnumerable<string> Changes([FromBody] TDto[] dtos)
        {
            var result = _radicalr.CreateStream(new ChangeSetAsync<TStore, TEntity, TDto>
                                                       (_publishMode, dtos));

            var response = result.ForEachAsync(c => (c.IsValid)
                                                  ? c.Id.ToString()
                                                  : c.ErrorMessages);
            return response;
        }

        public virtual IAsyncEnumerable<string> Updates([FromBody] TDto[] dtos)
        {
            var result = _radicalr.CreateStream(new UpdateSetAsync<TStore, TEntity, TDto>
                                                     (_publishMode, dtos));

            var response = result.ForEachAsync(c => (c.IsValid)
                                                 ? c.Id.ToString()
                                                 : c.ErrorMessages);
            return response;
        }

        public virtual IAsyncEnumerable<string> Deletes([FromBody] TDto[] dtos)
        {
            var result = _radicalr.CreateStream(new DeleteSetAsync<TStore, TEntity, TDto>
                                                      (_publishMode, dtos));

            var response = result.ForEachAsync(c => (c.IsValid)
                                                 ? c.Id.ToString()
                                                 : c.ErrorMessages);
            return response;
        }
    }
}
