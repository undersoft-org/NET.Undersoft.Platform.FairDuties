using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Linq.Expressions;
using System.Uniques;

namespace RadicalR
{
    //[IgnoreApi]
    [LinkedResult]
    [ODataService]
    public class OpenDataServiceController<TKey, TEntry, TReport, TEntity, TDto>
        : ODataController, IOpenDataServiceController<TKey, TEntity, TDto> where TDto : Dto
        where TEntity : Entity
        where TEntry : IDataStore
        where TReport : IDataStore
    {
        protected Func<TKey, Func<TDto, object>> _keysetter = k => e => e.SetId(k);
        protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher = k => e => k.Equals(e.Id);
        protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
        protected readonly IRadicalr _ultimatr;
        protected readonly PublishMode _publishMode;

        protected OpenDataServiceController() { }

        protected OpenDataServiceController(
            IRadicalr ultimatr,
            PublishMode publishMode = PublishMode.PropagateCommand
        ) : this(ultimatr, null, k => e => e.SetId(k), k => e => k.Equals(e.Id), publishMode) { }

        protected OpenDataServiceController(
            IRadicalr ultimatr,
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

        [HttpGet]
        [EnableQuery]
        public virtual IQueryable<TDto> Get()
        {
            return _ultimatr.Send(new GetAllQuery<TReport, TEntity, TDto>()).Result;
        }

        [HttpGet]
        [EnableQuery]
        public virtual Task<UniqueOne<TDto>> Get([FromODataUri] TKey key)
        {
            return _ultimatr.Send(new FindOneQuery<TReport, TEntity, TDto>(_keymatcher(key)));
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromODataBody] TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _ultimatr.Send(new CreateDtoSet<TEntry, TEntity, TDto>
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
        public virtual async Task<IActionResult> Patch([FromODataUri] TKey key, [FromODataBody] TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _keysetter(key).Invoke(dto);

            var result = await _ultimatr.Send(new ChangeDtoSet<TEntry, TEntity, TDto>
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
        public virtual async Task<IActionResult> Put([FromODataUri] TKey key, [FromODataBody] TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _keysetter(key).Invoke(dto);

            var result = await _ultimatr.Send(new UpdateDtoSet<TEntry, TEntity, TDto>
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

            var result = await _ultimatr.Send(new DeleteDtoSet<TEntry, TEntity, TDto>
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
