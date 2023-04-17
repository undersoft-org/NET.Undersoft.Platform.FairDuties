using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Uniques;

namespace UltimatR
{
    [LinkedResult]
    [IgnoreApi]
    public abstract class DsoController<TKey, TStore, TEntity> : ODataController, IDsoController<TKey, TStore, TEntity> where TEntity : Entity where TStore : IDataStore
    {
        protected readonly Func<TKey, Expression<Func<TEntity, bool>>> _keymatcher;
        protected readonly IUltimatr _ultimatr;
        protected readonly PublishMode _publishMode;

        protected DsoController() { }
        protected DsoController(IUltimatr ultimatr, PublishMode publishMode = PublishMode.PropagateCommand) : this(ultimatr, k => e => k.Equals(e.Id), publishMode)
        {
        }
        protected DsoController(IUltimatr ultimatr, Func<TKey, Expression<Func<TEntity, bool>>> keymatcher, PublishMode publishMode = PublishMode.PropagateCommand)
        {
            _keymatcher = keymatcher;
            _ultimatr = ultimatr;
            _publishMode = publishMode;
        }

        [EnableQuery]
        [HttpGet]
        public virtual IQueryable Get()
        {
            return _ultimatr.Use<TStore, TEntity>().AsQueryable();
        }

        [EnableQuery]
        [HttpGet]
        public virtual UniqueOne Get([FromODataUri] TKey key)
        {
            return _ultimatr.Use<TStore, TEntity>()[_keymatcher(key)].AsUniqueOne();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntity entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Created(await _ultimatr.Send(new CreateDso<TStore, TEntity>
                                                    (_publishMode, entity))
                                                    .ConfigureAwait(false));
        }

        [HttpPatch]
        public virtual async Task<IActionResult> Patch([FromODataUri] TKey key, TEntity entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Updated(await _ultimatr.Send(new ChangeDso<TStore, TEntity>
                                                    (_publishMode, entity, key))
                                                    .ConfigureAwait(false));
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromODataUri] TKey key, TEntity entity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Updated(await _ultimatr.Send(new UpdateDso<TStore, TEntity>
                                                     (_publishMode, entity, key))
                                                    .ConfigureAwait(false));
        }

        [HttpDelete]
        public virtual async Task<IActionResult> Delete([FromODataUri] TKey key)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _ultimatr.Send(new DeleteDso<TStore, TEntity>
                                                    (_publishMode, key))
                                                    .ConfigureAwait(false));
        }
    }
}
