﻿using Microsoft.AspNetCore.OData.Deltas;
using System;
using System.Collections.Generic;
using System.Instant;
using System.Linq;
using System.Linq.Expressions;
using System.Series;
using System.Threading.Tasks;

namespace RadicalR
{
    public partial class Repository<TEntity>
    {
        #region Methods

        public abstract TEntity NewEntry(params object[] parameters);

        public abstract TEntity Add(TEntity entity);

        public virtual IEnumerable<TEntity> Add(IEnumerable<TEntity> entity)
        {
            foreach (var e in entity)
                yield return Add(e);
        }
        public virtual IEnumerable<TEntity> Add(IEnumerable<TEntity> entities, Func<TEntity, Expression<Func<TEntity, bool>>> predicate)
        {
            var addins = entities;
            if (predicate != null)
                addins = entities.Where(e => !Query.Any(predicate.Invoke(e)));
            if (addins.Any())
            {
                foreach (var addin in addins)
                {
                    yield return Add(addin);
                }
            }
        }

        public virtual IAsyncEnumerable<TEntity> AddAsync(IEnumerable<TEntity> entity)
        {
            return entity.ForEachAsync((e) => Add(e));
        }
        public virtual IAsyncEnumerable<TEntity> AddAsync(IEnumerable<TEntity> entities, Func<TEntity, Expression<Func<TEntity, bool>>> predicate)
        {
            var addin = entities;
            if (predicate != null)
                addin = entities.Where(e => !Query.Any(predicate.Invoke(e)));
            if (addin.Any())
                return AddAsync(addin);
            return null;
        }

        public virtual IAsyncEnumerable<TEntity> AddAsync(IAsyncEnumerable<TEntity> entity)
        {
            return entity.ForEachAsync((e) => Add(e));
        }
    
        public virtual TEntity Add(TEntity entity, Func<TEntity, Expression<Func<TEntity, bool>>> predicate)
        {
            if (predicate != null && Query.Any(predicate.Invoke(entity))) return null;
            return Add(entity);
        }

        public abstract TEntity Delete(TEntity entity);
        public virtual IEnumerable<TEntity> Delete(IEnumerable<TEntity> entity)
        {
            foreach (var e in entity)
                yield return Delete(e);
        }
        public virtual IEnumerable<TEntity> Delete(long[] ids)
        {
            var deck = Query.WhereIn(p => p.Id, ids).ToDeck();
            foreach (TEntity model in deck)
            {
                yield return Delete(model);
            }
        }
        public virtual async Task<TEntity> Delete(params object[] key)
        {
            var toDelete = await Find(key);
            if (toDelete != null)
                return Delete(toDelete);
            return null;
        }
        public virtual TEntity Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var toDelete = this[false, predicate];
            if (toDelete != null)
                return Delete(toDelete);
            return null;
        }
        public virtual TEntity Delete(TEntity entity, Func<TEntity, Expression<Func<TEntity, bool>>> predicate)
        {
            if (predicate != null)
                return Delete(predicate.Invoke(entity));
            return null;
        }
        public virtual IEnumerable<TEntity> Delete(IEnumerable<TEntity> entities, Func<TEntity, Expression<Func<TEntity, bool>>> predicate)
        {
            if (predicate != null)
                foreach (var entity in entities)
                    yield return Delete(predicate.Invoke(entity));
            yield return null;
        }

        public virtual async IAsyncEnumerable<TEntity> DeleteAsync(IEnumerable<TEntity> entity)
        {
            foreach (var e in entity)
                yield return await Task.Run(() => Delete(e));
        }
        public virtual async IAsyncEnumerable<TEntity> DeleteAsync(IEnumerable<TEntity> entities, Func<TEntity, Expression<Func<TEntity, bool>>> predicate)
        {
            if (predicate != null)
                foreach (var entity in entities)
                    yield return await Task.Run(() => Delete(predicate.Invoke(entity)));
            yield return null;
        }

        protected virtual TEntity InnerSet(TEntity entity)
        {
            return Stamp(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return InnerSet(entity);
        }

        public virtual async Task<TEntity> Set<TModel>(TModel entity, params object[] key) where TModel : class
        {
            if (key == null) return null;
            var _entity = await Find(key);
            if (_entity != null)
            {
                return InnerSet((TEntity)entity.PutTo(_entity.Valuator, PatchingEvent).Devisor);
            }
            return null;
        }
        public virtual async Task<TEntity> Set<TModel>(TModel entity, object key, Func<TEntity, Expression<Func<TEntity, bool>>> condition) where TModel : class, IIdentifiable
        {
            if (key == null) return null;
            var _entity = await Find(key);
            if (_entity != null)
            {
                if (condition != null &&
                    !Query.Any(condition
                          .Invoke(_entity)))
                    return null;

                return InnerSet((TEntity)entity.PutTo(_entity.Valuator, PatchingEvent).Devisor);
            }
            return _entity;
        }
        public virtual async Task<TEntity> Set<TModel>(TModel entity) where TModel : class, IIdentifiable
        {
            if (entity.Id == 0) return null;
            var _entity = await Find(entity.Id);
            if (_entity != null)
                return Update((TEntity)entity.PutTo(_entity.Valuator, PatchingEvent).Devisor);
            return null;
        }
        
        public virtual IEnumerable<TEntity> Set<TModel>(IEnumerable<TModel> models) where TModel : class, IIdentifiable
        {
            var dtos = models.ToDeck();
            var deck = lookup<TModel>(models).ToDeck();
            if (deck.Count < dtos.Count)
                deck.Add(this[Query.WhereIn(p => p.Id, dtos.Where(id => !deck.ContainsKey(id)).Select(id => id.Id))]);

            foreach (var model in models)
            {
                if (deck.TryGet(model.Id, out TEntity entity))
                {
                    yield return InnerSet((TEntity)model.PatchTo(entity.Valuator, PatchingEvent).Devisor);
                }
            }
        }       
        public virtual async Task<TEntity> Set<TModel>(TModel entity, Func<TModel, Expression<Func<TEntity, bool>>> predicate, params Func<TModel, Expression<Func<TEntity, bool>>>[] conditions) where TModel : class, IIdentifiable
        {
            return await Task.Run(async () =>
            {
                TEntity _entity = null;
                if (predicate != null)
                    _entity = Query.FirstOrDefault(predicate
                                   .Invoke(entity));
                if (_entity == null)
                    _entity = await Find(entity.Id);

                if (_entity == null)
                    return null;

                if (conditions != null)
                    foreach (var condition in conditions)
                        if (!Query.Any(condition.Invoke(entity)))
                            return null;

                return InnerSet((TEntity)entity.PutTo(_entity.Valuator, PatchingEvent).Devisor);
            });
        }        
        public virtual IEnumerable<TEntity> Set<TModel>(IEnumerable<TModel> entities, Func<TModel, Expression<Func<TEntity, bool>>> predicate, params Func<TModel, Expression<Func<TEntity, bool>>>[] conditions) where TModel : class, IIdentifiable
        {
            IDeck<TEntity> deck = null;
            if (predicate != null)
                deck = entities.Select(e => Query
                                  .FirstOrDefault(predicate.Invoke(e)))
                                  .Where(e => e != null).ToDeck();
            if (deck == null)
            {
                var dtos = entities.ToDeck();
                deck = lookup<TModel>(entities).ToDeck();
                if (deck.Count < dtos.Count)
                    deck.Add(this[Query.WhereIn(p => p.Id, dtos.Where(id => !deck.ContainsKey(id)).Select(id => id.Id))]);
            }
            if (deck == null)
                yield return null;

            foreach (var entity in entities)
            {
                if (conditions != null)
                {
                    foreach (var condition in conditions)
                    {
                        if (!Query.Any(condition.Invoke(entity)))
                            yield return null;
                    }
                }
                yield return InnerSet(((TEntity)entity.PutTo(deck.Get(entity).Valuator, PatchingEvent).Devisor));
            }
        }

        public virtual async IAsyncEnumerable<TEntity> SetAsync<TModel>(IEnumerable<TModel> entities, Func<TModel, Expression<Func<TEntity, bool>>> predicate, params Func<TModel, Expression<Func<TEntity, bool>>>[] conditions) where TModel : class, IIdentifiable
        {
            IDeck<TEntity> deck = null;
            if (predicate != null)
                deck = entities.Select(e => Query
                                  .FirstOrDefault(predicate.Invoke(e)))
                                  .Where(e => e != null).ToDeck();
            if (deck == null)
            {
                var dtos = entities.ToDeck();
                deck = lookup<TModel>(entities).ToDeck();
                if (deck.Count < dtos.Count)
                    deck.Add(this[Query.WhereIn(p => p.Id, dtos.Where(id => !deck.ContainsKey(id)).Select(id => id.Id))]);
            }
            if (deck == null)
                yield return null;

            foreach (var entity in entities)
            {
                if (conditions != null)
                {
                    foreach (var condition in conditions)
                    {
                        if (!Query.Any(condition.Invoke(entity)))
                            yield return null;
                    }
                }
                yield return await Task.Run(() => InnerSet(((TEntity)entity.PutTo(deck.Get(entity).Valuator, PatchingEvent).Devisor)));
            }
        }
        public virtual async IAsyncEnumerable<TEntity> SetAsync<TModel>(IEnumerable<TModel> models) where TModel : class, IIdentifiable
        {
            var dtos = models.ToDeck();
            var deck = lookup<TModel>(models).ToDeck();
            if (deck.Count < dtos.Count)
                deck.Add(this[Query.WhereIn(p => p.Id, dtos.Where(id => !deck.ContainsKey(id)).Select(id => id.Id))]);

            foreach (var model in models)
            {
                if (deck.TryGet(model.Id, out TEntity entity))
                {
                    yield return await Task.Run(() => InnerSet((TEntity)model.PatchTo(entity.Valuator, PatchingEvent).Devisor));
                }
            }
        }

        public virtual Task<TEntity> Patch(Delta<TEntity> delta, params object[] key)
        {
            return Task.Run(async () =>
            {
                if (key == null) return null;
                var entity = await Find(key);
                if (entity == null) return null;
                delta.Patch(entity);
                return InnerSet(entity);
            });
        }
        public virtual Task<TEntity> Patch(Delta<TEntity> delta, Func<TEntity, Expression<Func<TEntity, bool>>> predicate)
        {
            return Task.Run(() =>
            {
                TEntity entity = null;
                if (predicate != null)
                    entity = this[false, predicate.Invoke(delta.GetInstance())];

                if (entity != null)
                {
                    delta.Patch(entity);
                    return InnerSet(entity);
                }
                return default;
            });
        }
        
        public virtual async Task<TEntity> Patch<TModel>(TModel delta) where TModel : class, IIdentifiable
        {
            if (delta.Id == 0) return null;
            var entity = await Find(delta.Id);
            if (entity != null)
            {
                return InnerSet((TEntity)delta.PatchTo(entity.Valuator, PatchingEvent).Devisor);
            }
            return null;
        }

        private IEnumerable<TEntity> lookup<TModel>(IEnumerable<TModel> entities) where TModel : class, IIdentifiable
        {
            var items = entities.ForEach(e => cache.Lookup<TEntity>(e.Id)).Where(e => e != null);
            if (items.Any())
                ((DataBaseContext)InnerContext).AttachRange(items);
            return items;
        }
        private TEntity lookup<TModel>(TModel entity) where TModel : class, IIdentifiable
        {
            var item = cache.Lookup<TEntity>(entity.Id);
            if (item != null)
                ((DataBaseContext)InnerContext).Attach(item);
            return item;
        }
        
        public virtual IEnumerable<TEntity> Patch<TModel>(IEnumerable<TModel> entities, params Expression<Func<TEntity, object>>[] expanders) where TModel : class, IIdentifiable
        {
            IDeck<TEntity> deck = null;
            if (expanders.Any())
                deck = this[Query.WhereIn(p => p.Id, entities.Select(e => e.Id)), expanders].ToDeck();
            else
            {
                var dtos = entities.ToDeck();
                deck = lookup<TModel>(entities).ToDeck();
                if (deck.Count < dtos.Count)
                    deck.Add(this[Query.WhereIn(p => p.Id, dtos.Where(id => !deck.ContainsKey(id)).Select(id => id.Id))]);
            }

            foreach (var entity in entities)
            {
                if (deck.TryGet(entity.Id, out TEntity _entity))
                {
                    yield return InnerSet((TEntity)entity.PatchTo(_entity.Valuator, PatchingEvent).Devisor);
                }
            }
        }

        public virtual Task<TEntity> Patch<TModel>(TModel delta, params object[] keys) where TModel : class, IIdentifiable
        {
            return Task.Run(async () =>
            {
                if (keys == null) return null;
                var entity = await Find(keys);

                if (entity != null)
                    return InnerSet((TEntity)delta.PatchTo(entity.Valuator, PatchingEvent).Devisor);

                return null;
            });
        }
        public virtual Task<TEntity> Patch<TModel>(TModel delta, Func<TModel, Expression<Func<TEntity, bool>>> predicate) where TModel : class, IIdentifiable
        {
            return Task.Run(() =>
            {
                TEntity entity = null;
                if (predicate != null)
                    entity = this[false, predicate(delta)];
                else
                    entity = this[delta.Id];

                if (entity != null)
                {
                    return InnerSet((TEntity)delta.PatchTo(entity.Valuator, PatchingEvent).Devisor);
                }
                return default;
            });
        }
        
        public virtual IEnumerable<TEntity> Patch<TModel>(IEnumerable<TModel> entities, Func<TModel, Expression<Func<TEntity, bool>>> predicate, params Expression<Func<TEntity, object>>[] expanders) where TModel : class, IIdentifiable
        {
            IDeck<TEntity> deck = null;
            if (predicate != null)
                if (expanders.Any())
                    deck = entities.Select(e => this[false, predicate(e), expanders]).ToDeck();
                else
                    deck = entities.Select(e => this[false, predicate(e)]).ToDeck();
            else if (expanders.Any())
                deck = this[Query.WhereIn(q => q.Id, entities.Select(i => i.Id)), expanders].ToDeck();

            if (deck == null)
            {
                foreach (var item in Patch(entities))
                    yield return item;
            }

            foreach (var entity in entities)
            {
                if (deck.TryGet(entity.Id, out TEntity _entity))
                    yield return InnerSet(((TEntity)entity.PatchTo(_entity.Valuator, PatchingEvent).Devisor));
            }
        }

        public virtual async IAsyncEnumerable<TEntity> PatchAsync<TModel>(IEnumerable<TModel> entities, params Expression<Func<TEntity, object>>[] expanders) where TModel : class, IIdentifiable
        {
            IDeck<TEntity> deck = null;
            if (expanders.Any())
                deck = this[Query.WhereIn(p => p.Id, entities.Select(e => e.Id)), expanders].ToDeck();
            else
            {
                var dtos = entities.ToDeck();
                deck = lookup<TModel>(entities).ToDeck();
                if (deck.Count < dtos.Count)
                    deck.Add(this[Query.WhereIn(p => p.Id, dtos.Where(id => !deck.ContainsKey(id)).Select(id => id.Id))]);
            }

            foreach (var entity in entities)
            {
                if (deck.TryGet(entity.Id, out TEntity _entity))
                {
                    yield return await Task.Run(() => InnerSet((TEntity)entity.PatchTo(_entity.Valuator, PatchingEvent).Devisor));
                }
            }
        }
        public virtual async IAsyncEnumerable<TEntity> PatchAsync<TModel>(IEnumerable<TModel> entities, Func<TModel, Expression<Func<TEntity, bool>>> predicate, params Expression<Func<TEntity, object>>[] expanders) where TModel : class, IIdentifiable
        {
            IDeck<TEntity> deck = null;
            if (predicate != null)
                if (expanders.Any())
                    deck = entities.Select(e => this[false, predicate(e), expanders]).ToDeck();
                else
                    deck = entities.Select(e => this[false, predicate(e)]).ToDeck();
            else if (expanders.Any())
                deck = this[Query.WhereIn(q => q.Id, entities.Select(i => i.Id)), expanders].ToDeck();

            if (deck == null)
            {
                foreach (var item in Patch(entities))
                    yield return item;
            }

            foreach (var entity in entities)
            {
                if (deck.TryGet(entity.Id, out TEntity _entity))
                    yield return await Task.Run(() => InnerSet(((TEntity)entity.PatchTo(_entity.Valuator, PatchingEvent).Devisor)));
            }
        }

        public virtual Task<TEntity> Put(TEntity entity, Func<TEntity, Expression<Func<TEntity, bool>>> predicate, params Func<TEntity, Expression<Func<TEntity, bool>>>[] conditions)
        {
            return Task.Run(async () =>
            {
                TEntity _entity = null;
                if (predicate != null)
                    _entity = Query.FirstOrDefault(
                              predicate(entity));

                if (_entity == null)
                    _entity = await Find(entity.Id);

                foreach (var condition in conditions)
                    if (!Query.Any(condition(entity)))
                        return null;

                if (_entity == null)
                    return Add(entity);

                return InnerSet((TEntity)entity.PutTo(_entity.Valuator, PatchingEvent).Devisor);
            });
        }
        public virtual IEnumerable<TEntity> Put(IEnumerable<TEntity> entities, Func<TEntity, Expression<Func<TEntity, bool>>> predicate, params Func<TEntity, Expression<Func<TEntity, bool>>>[] conditions)
        {
            IDeck<TEntity> deck = null;
            if (predicate != null)
                deck = entities.Select(e =>
                             Query.FirstOrDefault(
                                   predicate(e)))
                                  .ToDeck();
            if (deck == null)
            {
                var dtos = entities.ToDeck();
                deck = lookup<TEntity>(entities).ToDeck();
                if (deck.Count < dtos.Count)
                    deck.Add(this[Query.WhereIn(p => p.Id, dtos.Where(id => !deck.ContainsKey(id)).Select(id => id.Id))]);
            }

            foreach (var entity in entities)
            {
                foreach (var condition in conditions)
                    if (!Query.Any(condition(entity)))
                        yield return null;

                if (deck.TryGet(entity.Id, out TEntity settin))
                {
                    yield return InnerSet((TEntity)entity.PutTo(settin.Valuator, PatchingEvent).Devisor);
                }
                else
                    yield return Add(entity);
            }
        }

        public virtual async IAsyncEnumerable<TEntity> PutAsync(IEnumerable<TEntity> entities, Func<TEntity, Expression<Func<TEntity, bool>>> predicate, params Func<TEntity, Expression<Func<TEntity, bool>>>[] conditions)
        {
            IDeck<TEntity> deck = null;
            if (predicate != null)
                deck = entities.Select(e =>
                             Query.FirstOrDefault(
                                   predicate(e)))
                                  .ToDeck();
            if (deck == null)
            {
                var dtos = entities.ToDeck();
                deck = lookup<TEntity>(entities).ToDeck();
                if (deck.Count < dtos.Count)
                    deck.Add(this[Query.WhereIn(p => p.Id, dtos.Where(id => !deck.ContainsKey(id)).Select(id => id.Id))]);
            }

            foreach (var entity in entities)
            {
                foreach (var condition in conditions)
                    if (!Query.Any(condition(entity)))
                        yield return null;

                if (deck.TryGet(entity.Id, out TEntity settin))
                {
                    yield return await Task.Run(() => InnerSet((TEntity)entity.PutTo(settin.Valuator, PatchingEvent).Devisor));
                }
                else
                    yield return await Task.Run(() => Add(entity));
            }
        }

        #endregion
    }

}
