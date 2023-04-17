using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UltimatR
{
    [LinkedResult]
    [ApiController]
    public abstract class DtoCommandController<TKey, TStore, TEntity, TDto> : ControllerBase where TEntity : Entity
        where TDto : Dto
        where TStore : IDataStore
    {
        protected Func<TKey, Func<TDto, object>> _keymatcher = k => e => e.SetId(k);
        protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
        protected IServicer _ultimatr;
        protected PublishMode _publishMode;

        protected DtoCommandController(IUltimatr ultimatr, PublishMode publishMode = PublishMode.PropagateCommand) { _ultimatr = ultimatr; _publishMode = publishMode; }

        protected DtoCommandController(IUltimatr ultimatr, Func<TKey, Func<TDto, object>> keymatcher, PublishMode publishMode = PublishMode.PropagateCommand)
            : this(ultimatr, publishMode) { _keymatcher = keymatcher; }

        protected DtoCommandController(
            IUltimatr ultimatr,
            Func<TDto, Expression<Func<TEntity, bool>>> predicate,
            Func<TKey, Func<TDto, object>> keymatcher,
            PublishMode publishMode = PublishMode.PropagateCommand) : this(ultimatr, keymatcher, publishMode) { _predicate = predicate; }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete([FromBody] TDto[] dtos)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _ultimatr.Send(new DeleteDtoSet<TStore, TEntity, TDto>
                                                                (_publishMode, dtos))
                                                                 .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                       ? c.Id as object
                                                       : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Ok(response);
        }

        [HttpDelete("{key}")]
        public virtual async Task<IActionResult> Delete([FromRoute] TKey key, [FromBody] TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _keymatcher(key).Invoke(dto);

            var result = await _ultimatr.Send(new DeleteDtoSet<TStore, TEntity, TDto>
                                                                 (_publishMode, new[] { dto }))
                                                                        .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                   ? c.Id as object
                                                   : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Ok(response);
        }

        [HttpPatch]
        public virtual async Task<IActionResult> Patch([FromBody] TDto[] dtos)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _ultimatr.Send(new ChangeDtoSet<TStore, TEntity, TDto>
                                                                    (_publishMode, dtos, _predicate))
                                                                        .ConfigureAwait(false);
            var response = result.ForEach(c => (isValid = c.IsValid)
                                                  ? c.Id as object
                                                  : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Ok(response);
        }

        [HttpPatch("{key}")]
        public virtual async Task<IActionResult> Patch([FromRoute] TKey key, [FromBody] TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid) return BadRequest(ModelState);

            _keymatcher(key).Invoke(dto);

            var result = await _ultimatr.Send(new ChangeDtoSet<TStore, TEntity, TDto>
                                                  (_publishMode, new[] { dto }, _predicate))
                                                     .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                  ? c.Id as object
                                                  : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Ok(response);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto[] dtos)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DtoCommandSet<TDto> result = await _ultimatr.Send(new CreateDtoSet<TStore, TEntity, TDto>
                                                        (_publishMode, dtos)).ConfigureAwait(false);

            object[] response = result.ForEach(c => (isValid = c.IsValid) ? (c.Id as object) : c.ErrorMessages)
                .ToArray();
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
        }

        [HttpPost("{key}")]
        public virtual async Task<IActionResult> Post([FromRoute] TKey key, [FromBody] TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _keymatcher(key).Invoke(dto);

            var result = await _ultimatr.Send(new CreateDtoSet<TStore, TEntity, TDto>
                                                    (_publishMode, new[] { dto }))
                                                        .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                  ? c.Id as object
                                                  : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Ok(response);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TDto[] dtos)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DtoCommandSet<TDto> result = await _ultimatr.Send(new UpdateDtoSet<TStore, TEntity, TDto>
                                                                        (_publishMode, dtos, _predicate))
                                                                                    .ConfigureAwait(false);

            object[] response = result.ForEach(c => (isValid = c.IsValid) ? (c.Id as object) : c.ErrorMessages)
                .ToArray();
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
        }

        [HttpPut("{key}")]
        public virtual async Task<IActionResult> Put([FromRoute] TKey key, [FromBody] TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _keymatcher(key).Invoke(dto);

            var result = await _ultimatr.Send(new UpdateDtoSet<TStore, TEntity, TDto>
                                                        (_publishMode, new[] { dto }, _predicate))
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
