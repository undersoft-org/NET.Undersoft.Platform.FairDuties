﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using System.Instant;
using System.Linq.Expressions;
using System.Logs;
using System.Uniques;

namespace RadicalR
{
    public partial class EntityRepository<TEntity> : Repository<TEntity>, IEntityRepository<TEntity>
        where TEntity : class, IIdentifiable, IEntity
    {
        DbSet<TEntity> _dbSet;

        public EntityRepository() : base() { }

        public EntityRepository(IRepositoryEndpoint repositorySource) : base(repositorySource)
        {
            TrackingEvents();
        }

        public EntityRepository(DataBaseContext dbContext) : base(dbContext)
        {
            TrackingEvents();

            Expression = Expression.Constant(this.AsEnumerable());
            Provider = new HostRepositoryQueryProvider<TEntity>(dbSet);
        }

        public EntityRepository(IRepositoryContextPool context) : base(context)
        {
            TrackingEvents();
        }

        public EntityRepository(IQueryProvider provider, Expression expression)
        {
            ElementType = typeof(TEntity);
            Provider = provider;
            Expression = expression;
        }

        public bool HasNextPage { get; set; }

        public bool HasPreviousPage { get; set; }

        public int IndexFrom { get; set; }

        public IList<TEntity> Items { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        protected DataBaseContext dbContext => (DataBaseContext)InnerContext;

        protected DbSet<TEntity> dbSet => _dbSet ??= dbContext.Set<TEntity>();

        private TEntity lookup(params object[] keys)
        {
            var item = cache.Lookup<TEntity>(keys);
            if (item != null)
                return dbSet.Attach(item).Entity;
            else
                return dbSet.Find(keys);
        }

        public override TEntity this[params object[] keys]
        {
            get { return lookup(keys); }
            set
            {
                object current = null;
                TEntity entity = lookup(keys);

                if (entity != null)
                    current = value.PatchTo(Stamp(entity));
                else
                    current = dbSet.Add(Sign(value)).Entity;
            }
        }

        public override TEntity this[object[] keys, params Expression<
            Func<TEntity, object>
        >[] expanders]
        {
            get
            {
                TEntity entity = this[keys];
                if (entity == null)
                    return entity;
                if (expanders != null)
                {
                    IQueryable<TEntity> query = entity.ToQueryable();
                    if (expanders != null)
                    {
                        foreach (Expression<Func<TEntity, object>> expander in expanders)
                        {
                            query = query.Include(expander);
                        }
                    }
                    entity = query.FirstOrDefault();
                }
                return entity;
            }
            set
            {
                TEntity entity = this[keys];
                if (entity != null)
                {
                    IQueryable<TEntity> query = entity.ToQueryable();
                    if (expanders != null)
                    {
                        foreach (Expression<Func<TEntity, object>> expander in expanders)
                        {
                            query = query.Include(expander);
                        }
                    }

                    TEntity current = value.PatchTo(Stamp(entity));
                }
            }
        }

        public override object this[Expression<
            Func<TEntity, object>
        > selector, object[] keys, params Expression<Func<TEntity, object>>[] expanders]
        {
            get
            {
                TEntity entity = this[keys];
                if (entity == null)
                    return entity;
                IQueryable<TEntity> query = entity.ToQueryable();
                if (expanders != null)
                {
                    foreach (Expression<Func<TEntity, object>> expander in expanders)
                    {
                        query = query.Include(expander);
                    }
                }
                return query.Select(selector).FirstOrDefault();
            }
            set
            {
                TEntity entity = this[keys];
                IQueryable<TEntity> query = entity.ToQueryable();
                if (expanders != null)
                {
                    foreach (Expression<Func<TEntity, object>> expander in expanders)
                    {
                        query = query.Include(expander);
                    }
                }
                object s = query.Select(selector).FirstOrDefault();
                if (s != null)
                {
                    value.PatchTo(s);
                }
            }
        }

        public override TEntity Add(TEntity entity)
        {
            return dbSet.Add(Sign(entity)).Entity;
        }

        public override TEntity Update(TEntity entity)
        {
            return dbSet.Update(Stamp(entity)).Entity;
        }

        public override IAsyncEnumerable<TEntity> AddAsync(IEnumerable<TEntity> entity)
        {
            return entity.ForEachAsync((e) => dbSet.Add(Sign(e)).Entity);            
        }

        public void AutoTransaction(bool enable)
        {
            dbContext.Database.AutoTransactionsEnabled = enable;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return dbContext.Database.BeginTransaction();
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return dbContext.Database.BeginTransactionAsync(Cancellation);
        }

        public void ChangeDetecting(bool enable = true)
        {
            if (InnerContext != null)
            {
                dbContext.ChangeTracker.AutoDetectChangesEnabled = enable;
            }
        }

        public virtual async Task CommitTransaction(Task<IDbContextTransaction> transaction)
        {
            await (await transaction).CommitAsync(Cancellation);
        }

        public virtual void CommitTransaction(IDbContextTransaction transaction)
        {
            transaction.Commit();
        }

        public override TEntity Delete(TEntity entity)
        {
            EntityEntry<TEntity> entry = dbContext.Entry(entity);
            if ((entry == null) || (entry.State == EntityState.Detached))
                entry = dbSet.Attach(entity);

            entry.State = EntityState.Deleted;
            return entry.Entity;
        }

        public void LazyLoading(bool enable)
        {
            dbContext.ChangeTracker.LazyLoadingEnabled = enable;
        }

        public override TEntity NewEntry(params object[] parameters)
        {
            return dbSet.Add(Sign(typeof(TEntity).New<TEntity>(parameters))).Entity;
        }

        public void QueryTracking(bool enable)
        {
            if (!enable)
                dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            else
                dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }

        public void TrackingEvents(bool enable = true)
        {
            if (InnerContext != null)
            {
                if (enable)
                {
                    dbContext.ChangeTracker.StateChanged += AuditTrigger;
                    dbContext.ChangeTracker.StateChanged += LinkTrigger;
                    dbContext.ChangeTracker.Tracked += LinkTrigger;
                }
                else
                {
                    dbContext.ChangeTracker.StateChanged -= AuditTrigger;
                    dbContext.ChangeTracker.StateChanged -= LinkTrigger;
                    dbContext.ChangeTracker.Tracked -= LinkTrigger;
                }
            }
        }

        public override object TracePatching(
            object item,
            string propertyName = null,
            Type type = null
        )
        {
            if (type == null)
            {
                dbContext.Attach(item);
                return item;
            }
            else if (type.IsAssignableTo(typeof(ICollection)))
            {
                var list = dbContext.Entry(item).Collection(propertyName);
                dbContext.Attach(list.EntityEntry.Entity);
                list.Load();
                return list.CurrentValue;
            }
            else
            {
                var obj = dbContext.Entry(item).Reference(propertyName);
                dbContext.Attach(obj.EntityEntry.Entity);
                obj.Load();
                return obj.CurrentValue;
            }
        }

        public override IQueryable<TEntity> AsQueryable()
        {
            return Query;
        }

        public override IQueryable<TEntity> Query => dbSet;

        protected override async Task<int> saveAsTransaction(
            CancellationToken token = default(CancellationToken)
        )
        {
            await using (
                IDbContextTransaction tr = await dbContext.Database.BeginTransactionAsync(token)
            )
            {
                try
                {
                    int changes = await dbContext.SaveChangesAsync(token);

                    await tr.CommitAsync(token);

                    return changes;
                }
                catch (DbUpdateException e)
                {
                    if (e is DbUpdateConcurrencyException)
                        tr.Warning<Datalog>(
                            $"{$"Concurrency update exception data changed by: {e.Source}, "}{$"entries involved in detail data object"}",
                            e.Entries,
                            e
                        );
                    tr.Failure<Datalog>(
                        $"{$"Fail on update database transaction Id:{tr.TransactionId}, using context:{dbContext.GetType().Name},"}{$" context Id:{dbContext.ContextId}, TimeStamp:{DateTime.Now.ToString()}, changes made count"}"
                    );

                    await tr.RollbackAsync(token);

                    tr.Warning<Datalog>($"Transaction Id:{tr.TransactionId} Rolling Back !!");
                }

                return -1;
            }
        }

        protected override async Task<int> saveChanges(
            CancellationToken token = default(CancellationToken)
        )
        {
            try
            {
                return await dbContext.SaveChangesAsync(token);
            }
            catch (DbUpdateException e)
            {
                if (e is DbUpdateConcurrencyException)
                    dbContext.Warning<Datalog>(
                        $"{$"Concurrency update exception data changed by: {e.Source}, "}{$"entries involved in detail data object"}",
                        e.Entries,
                        e
                    );
                dbContext.Failure<Datalog>(
                    $"{$"Fail on update database, using context:{dbContext.GetType().Name}, "}{$"context Id: {dbContext.ContextId}, TimeStamp: {DateTime.Now.ToString()}"}"
                );
            }

            return -1;
        }
    }

    public class EntityRepository<TStore, TEntity>
        : EntityRepository<TEntity>,
            IEntityRepository<TStore, TEntity>
        where TEntity : Entity
        where TStore : IDataStore
    {
        public EntityRepository(
            IRepositoryContextPool<DataBaseContext<TStore>> pool,
            IEntityCache<TStore, TEntity> cache,
            IEnumerable<ILinkedObject<TStore, TEntity>> linked,
            ILinkSynchronizer synchronizer
        ) : base(pool.ContextPool)
        {
            mapper = cache.Mapper;
            this.cache = cache;
            synchronizer.AddRepository(this);
            LinkedObjects = linked.DoEach(
                (o) =>
                {
                    o.Host = this;
                    return o;
                }
            );
        }

        public override Task<int> Save(
            bool asTransaction,
            CancellationToken token = default(CancellationToken)
        )
        {
            return ContextLease.Save(asTransaction, token);
        }
    }
}
