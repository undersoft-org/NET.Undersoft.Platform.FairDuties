using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Linq.Expressions;
using System.Uniques;

namespace UltimatR
{
    [IgnoreApi]
    [LinkedResult]
    [ODataService]
    [ODataRouteComponent(StoreRoutes.Constant.OpenEventStore)]
    public abstract class OpenDataEventController<TKey, TStore, TEntity, TDto> : ODataController where TDto : Dto
        where TEntity : Entity
        where TStore : IDataStore
    {
        protected Func<TKey, Func<TDto, object>> _keysetter = k => e => e.SetId(k);
        protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher = k => e => k.Equals(e.Id);
        protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
        protected readonly IUltimatr _ultimatr;
        protected readonly PublishMode _publishMode;

        protected OpenDataEventController() { }

        protected OpenDataEventController(
            IUltimatr ultimatr,
            PublishMode publishMode = PublishMode.PropagateCommand
        ) : this(ultimatr, null, k => e => e.SetId(k), k => e => k.Equals(e.Id), publishMode) { }

        protected OpenDataEventController(
            IUltimatr ultimatr,
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


        [HttpDelete]
        public virtual async Task<IActionResult> Delete([FromODataUri] TKey key)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _ultimatr.Send(new DeleteDtoSet<TStore, TEntity, TDto>
                                                                 (_publishMode, key))
                                                                        .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                   ? c.Id as object
                                                   : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Ok(response);
        }

        [EnableQuery]
        [HttpGet]
        public virtual Task<IQueryable<TDto>> Get()
        {
            return _ultimatr.Send(new GetAllQuery<TStore, TEntity, TDto>());
        }

        [EnableQuery]
        [HttpGet]
        public virtual Task<UniqueOne<TDto>> Get([FromODataUri] TKey key)
        {
            return _ultimatr.Send(new FindOneQuery<TStore, TEntity, TDto>(_keymatcher(key)));
        }

        [HttpPatch]
        public virtual async Task<IActionResult> Patch([FromODataUri] TKey key, TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _keysetter(key).Invoke(dto);

            var result = await _ultimatr.Send(new ChangeDtoSet<TStore, TEntity, TDto>
                                                  (_publishMode, new[] { dto }, _predicate))
                                                     .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                  ? c.Id as object
                                                  : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Updated(response);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _ultimatr.Send(new CreateDtoSet<TStore, TEntity, TDto>
                                                    (_publishMode, new[] { dto }))
                                                        .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                  ? c.Id as object
                                                  : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Created(response);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromODataUri] TKey key, TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _keysetter(key).Invoke(dto);

            var result = await _ultimatr.Send(new UpdateDtoSet<TStore, TEntity, TDto>
                                                        (_publishMode, new[] { dto }, _predicate))
                                                            .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                  ? c.Id as object
                                                  : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Updated(response);
        }
    }
}
