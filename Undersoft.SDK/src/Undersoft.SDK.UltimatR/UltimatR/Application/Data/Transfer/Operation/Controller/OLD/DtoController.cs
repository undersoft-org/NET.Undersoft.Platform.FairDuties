﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;

namespace UltimatR
{
    [LinkedResult]
    [ApiController]
    public abstract class DtoController<TKey, TStore, TEntity, TDto> : ControllerBase
        where TEntity : Entity
        where TDto : Dto
        where TStore : IDataStore
    {
        protected Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher = k =>
            e => k.Equals(e.Id);
        protected Func<TDto, Expression<Func<TEntity, bool>>> _predicate = p => e => p.Id == e.Id;
        protected IServicer _ultimatr;
        protected PublishMode _publishMode;

        protected DtoController(
            IUltimatr ultimatr,
            PublishMode publishMode = PublishMode.PropagateCommand
        )
        {
            _ultimatr = ultimatr;
            _publishMode = publishMode;
        }

        protected DtoController(
            IUltimatr ultimatr,
            Func<TKey, Expression<Func<TEntity, bool>>> keymatcher,
            PublishMode publishMode = PublishMode.PropagateCommand
        ) : this(ultimatr, publishMode)
        {
            _keymatcher = keymatcher;
        }

        protected DtoController(
            IUltimatr ultimatr,
            Func<TDto, Expression<Func<TEntity, bool>>> predicate,
            Func<TKey, Expression<Func<TEntity, bool>>> keymatcher,
            PublishMode publishMode = PublishMode.PropagateCommand
        ) : this(ultimatr, keymatcher, publishMode)
        {
            _predicate = predicate;
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete(TDto[] dtos)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DtoCommandSet<TDto> result = await _ultimatr
                .Send(new DeleteDtoSet<TStore, TEntity, TDto>(_publishMode, dtos))
                .ConfigureAwait(false);

            object[] response = result
                .ForEach(c => (isValid = c.IsValid) ? (c.Id as object) : c.ErrorMessages)
                .ToArray();
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
        }

        [HttpDelete("{key}")]
        public virtual async Task<IActionResult> Delete(TKey key, TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DtoCommand<TDto> result = await _ultimatr
                .Send(new DeleteDto<TStore, TEntity, TDto>(_publishMode, dto, key))
                .ConfigureAwait(false);

            object response = result.IsValid ? (result.Id as object) : result.ErrorMessages;
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            return Ok(
                await _ultimatr.Send(new GetAll<TStore, TEntity, TDto>(0, 0)).ConfigureAwait(false)
            );
        }

        [HttpGet("{key}")]
        public virtual async Task<IActionResult> Get(TKey key)
        {
            Task<TDto> query =
                (_keymatcher == null)
                    ? _ultimatr.Send(new FindOne<TStore, TEntity, TDto>(key))
                    : _ultimatr.Send(new FindOne<TStore, TEntity, TDto>(_keymatcher(key)));

            return Ok(await query.ConfigureAwait(false));
        }

        [HttpGet("{page}/{pageSize}")]
        public virtual async Task<IActionResult> Get(int page, int pageSize)
        {
            return Ok(
                await _ultimatr
                    .Send(new GetAll<TStore, TEntity, TDto>(page * pageSize, pageSize))
                    .ConfigureAwait(true)
            );
        }

        [HttpPatch]
        public virtual async Task<IActionResult> Patch(TDto[] dtos)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DtoCommandSet<TDto> result = await _ultimatr
                .Send(new ChangeDtoSet<TStore, TEntity, TDto>(_publishMode, dtos))
                .ConfigureAwait(false);

            object[] response = result
                .ForEach(c => (isValid = c.IsValid) ? (c.Id as object) : c.ErrorMessages)
                .ToArray();
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
        }

        [HttpPatch("{key}")]
        public virtual async Task<IActionResult> Patch(TKey key, TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DtoCommand<TDto> result = await _ultimatr
                .Send(new ChangeDto<TStore, TEntity, TDto>(_publishMode, dto, key))
                .ConfigureAwait(false);

            object response = result.IsValid ? (result.Id as object) : result.ErrorMessages;
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TDto[] dtos)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DtoCommandSet<TDto> result = await _ultimatr
                .Send(new CreateDtoSet<TStore, TEntity, TDto>(_publishMode, dtos))
                .ConfigureAwait(false);

            object[] response = result
                .ForEach(c => (isValid = c.IsValid) ? (c.Id as object) : c.ErrorMessages)
                .ToArray();
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
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
                await _ultimatr
                    .Send(
                        new FilterData<TStore, TEntity, TDto>(
                            offset,
                            limit,
                            new FilterExpression<TEntity>(query.Filter).Create(),
                            new SortExpression<TEntity>(query.Sort)
                        )
                    )
                    .ConfigureAwait(false)
            );
        }

        [HttpPost("{key}")]
        public virtual async Task<IActionResult> Post(TKey key, TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DtoCommand<TDto> result = await _ultimatr
                .Send(new CreateDto<TStore, TEntity, TDto>(_publishMode, dto, key))
                .ConfigureAwait(false);

            object response = result.IsValid ? (result.Id as object) : result.ErrorMessages;
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put(TDto[] dtos)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DtoCommandSet<TDto> result = await _ultimatr
                .Send(new UpdateDtoSet<TStore, TEntity, TDto>(_publishMode, dtos))
                .ConfigureAwait(false);

            object[] response = result
                .ForEach(c => (isValid = c.IsValid) ? (c.Id as object) : c.ErrorMessages)
                .ToArray();
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
        }

        [HttpPut("{key}")]
        public virtual async Task<IActionResult> Put(TKey key, TDto dto)
        {
            bool isValid = false;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DtoCommand<TDto> result = await _ultimatr
                .Send(new UpdateDto<TStore, TEntity, TDto>(_publishMode, dto, key))
                .ConfigureAwait(false);

            object response = result.IsValid ? (result.Id as object) : result.ErrorMessages;
            return (!isValid) ? UnprocessableEntity(response) : Ok(response);
        }
    }
}