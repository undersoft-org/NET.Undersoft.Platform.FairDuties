using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Linq.Expressions;
using System.Uniques;

namespace RadicalR.Server
{
    [IgnoreApi]
    [LinkedResult]
    [OpenService]
    [ODataRouteComponent(StoreRoutes.Constant.OpenEventStore)]
    public abstract class OpenEventController<TKey, TStore, TEntity, TDto> : ODataController where TDto : Dto
        where TEntity : Entity
        where TStore : IDataStore
    {
        protected Func<TKey, Func<TDto, object>> _keysetter = k => e => e.SetId(k);
        protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher = k => e => k.Equals(e.Id);
        protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
        protected readonly IRadicalr _radicalr;
        protected readonly PublishMode _publishMode;

        protected OpenEventController() { }

        protected OpenEventController(
            IRadicalr radicalr,
            PublishMode publishMode = PublishMode.PropagateCommand
        ) : this(radicalr, null, k => e => e.SetId(k), k => e => k.Equals(e.Id), publishMode) { }

        protected OpenEventController(
            IRadicalr radicalr,
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

        [EnableQuery]
        [HttpGet]
        public virtual Task<IQueryable<TDto>> Get()
        {
            return _radicalr.Send(new GetQuery<TStore, TEntity, TDto>());
        }

        [EnableQuery]
        [HttpGet]
        public virtual async Task<UniqueOne<TDto>> Get([FromODataUri] TKey key)
        {
            return new UniqueOne<TDto>(await _radicalr.Send(new FindQuery<TStore, TEntity, TDto>(_keymatcher(key))));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _radicalr.Send(new CreateSet<TStore, TEntity, TDto>
                                                    (_publishMode, new[] { dto }))
                                                        .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                  ? c.Id as object
                                                  : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Created(response);
        }

        [HttpPatch]
        public virtual async Task<IActionResult> Patch([FromODataUri] TKey key, TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _keysetter(key).Invoke(dto);

            var result = await _radicalr.Send(new ChangeSet<TStore, TEntity, TDto>
                                                  (_publishMode, new[] { dto }, _predicate))
                                                     .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                  ? c.Id as object
                                                  : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Updated(response);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromODataUri] TKey key, TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _keysetter(key).Invoke(dto);

            var result = await _radicalr.Send(new UpdateSet<TStore, TEntity, TDto>
                                                        (_publishMode, new[] { dto }, _predicate))
                                                            .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                  ? c.Id as object
                                                  : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Updated(response);
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete([FromODataUri] TKey key)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _radicalr.Send(new DeleteSet<TStore, TEntity, TDto>
                                                                 (_publishMode, key))
                                                                        .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                   ? c.Id as object
                                                   : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Ok(response);
        }
    }
}
