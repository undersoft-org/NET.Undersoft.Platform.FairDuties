﻿using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.Json;

namespace RadicalR.Server
{
    [LinkedResult]
    [CrudService]
    [ApiController]
    [Route($"{StoreRoutes.Constant.CrudDataStore}/[controller]")]
    public class CrudDataController<TKey, TEntry, TReport, TEntity, TDto>
        : ControllerBase, ICrudDataController<TKey, TEntity, TDto> where TDto : Dto
        where TEntity : Entity
        where TEntry : IDataStore
        where TReport : IDataStore
    {
        protected Func<TKey, Func<TDto, object>> _keysetter = k => e => e.SetId(k);
        protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher;
        protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate;
        protected readonly IRadicalr _radicalr;
        protected readonly PublishMode _publishMode;

        protected CrudDataController() { }

        protected CrudDataController(
            IRadicalr radicalr,
            PublishMode publishMode = PublishMode.PropagateCommand
        ) : this(radicalr, null, k => e => e.SetId(k), null, publishMode) { }

        protected CrudDataController(
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

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(
                await _radicalr.Send(new GetItems<TReport, TEntity, TDto>(0, 0)).ConfigureAwait(true)
            );
        }

        [HttpGet("count")]
        public virtual async Task<IActionResult> Count()
        {
            return Ok(await Task.Run(() => _radicalr.use<TReport, TEntity>().Count()));
        }

        [HttpGet("{key}")]
        public virtual async Task<IActionResult> Get(TKey key)
        {
            Task<TDto> query =
                (_keymatcher == null)
                    ? _radicalr.Send(new FindItem<TReport, TEntity, TDto>(key))
                    : _radicalr.Send(new FindItem<TReport, TEntity, TDto>(_keymatcher(key)));

            return Ok(await query.ConfigureAwait(false));
        }

        [HttpGet("{offset}/{limit}")]
        public virtual async Task<IActionResult> Get(int offset, int limit)
        {
            return Ok(
                await _radicalr
                    .Send(new GetItems<TReport, TEntity, TDto>(offset, limit))
                    .ConfigureAwait(true)
            );
        }

        [HttpPost("query/{offset}/{limit}")]
        public virtual async Task<IActionResult> Post(int offset, int limit, QueryItems query)
        {
            query.Filter.ForEach(
                (fi) =>
                    fi.Value = JsonSerializer.Deserialize(
                        ((JsonElement)fi.Value).GetRawText(),
                        Type.GetType($"System.{fi.Type}", null, null, false, true)
                    )
            );

            return Ok(
                await _radicalr
                    .Send(
                        new FilterItems<TReport, TEntity, TDto>(offset, limit,
                            new FilterExpression<TEntity>(query.Filter).Create(),
                            new SortExpression<TEntity>(query.Sort)
                        )
                    )
                    .ConfigureAwait(false)
            );
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TDto[] dtos)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _radicalr.Send(new CreateSet<TEntry, TEntity, TDto>
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

            _keysetter(key).Invoke(dto);

            var result = await _radicalr.Send(new CreateSet<TEntry, TEntity, TDto>
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

            var result = await _radicalr.Send(new ChangeSet<TEntry, TEntity, TDto>
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

            _keysetter(key).Invoke(dto);

            var result = await _radicalr.Send(new ChangeSet<TEntry, TEntity, TDto>
                                                  (_publishMode, new[] { dto }, _predicate))
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

            var result = await _radicalr.Send(new UpdateSet<TEntry, TEntity, TDto>
                                                                        (_publishMode, dtos, _predicate))
                                                                                    .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid) ? (c.Id as object) : c.ErrorMessages)
                .ToArray();
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
        }

        [HttpPut("{key}")]
        public virtual async Task<IActionResult> Put([FromRoute] TKey key, [FromBody] TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _keysetter(key).Invoke(dto);

            var result = await _radicalr.Send(new UpdateSet<TEntry, TEntity, TDto>
                                                        (_publishMode, new[] { dto }, _predicate))
                                                            .ConfigureAwait(false);

            var response = result.ForEach(c => (isValid = c.IsValid)
                                                  ? c.Id as object
                                                  : c.ErrorMessages).ToArray();
            return (!isValid)
                   ? UnprocessableEntity(response)
                   : Ok(response);
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete([FromBody] TDto[] dtos)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _radicalr.Send(new DeleteSet<TEntry, TEntity, TDto>
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

            _keysetter(key).Invoke(dto);

            var result = await _radicalr.Send(new DeleteSet<TEntry, TEntity, TDto>
                                                                 (_publishMode, new[] { dto }))
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
