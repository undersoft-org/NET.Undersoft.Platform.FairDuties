﻿using System.Collections.Generic;
using System.Threading;

namespace System.Series
{
    public class MassCache<V> : MassCatalogBase<V> where V : IUnique
    {
        private readonly Board<Timer> timers = new Board<Timer>();

        private TimeSpan duration;
        private IDeputy callback;

        private void setupExpiration(TimeSpan? lifetime, IDeputy callback)
        {
            duration = (lifetime != null) ? lifetime.Value : TimeSpan.FromMinutes(15);
            if (callback != null)
                this.callback = callback;
        }

        public MassCache(
            IEnumerable<IUnique<V>> collection,
            TimeSpan? lifeTime = null,
            IDeputy callback = null,
            int capacity = 17
        ) : base(collection, capacity)
        {
            setupExpiration(lifeTime, callback);
        }

        public MassCache(
            IEnumerable<V> collection,
            TimeSpan? lifeTime = null,
            IDeputy callback = null,
            int capacity = 17
        ) : base(collection, capacity)
        {
            setupExpiration(lifeTime, callback);
        }

        public MassCache(
            IList<IUnique<V>> collection,
            TimeSpan? lifeTime = null,
            IDeputy callback = null,
            int capacity = 17
        ) : base(collection, capacity)
        {
            setupExpiration(lifeTime, callback);
        }

        public MassCache(
            IList<V> collection,
            TimeSpan? lifeTime = null,
            IDeputy callback = null,
            int capacity = 17
        ) : base(collection, capacity)
        {
            setupExpiration(lifeTime, callback);
        }

        public MassCache(TimeSpan? lifeTime = null, IDeputy callback = null, int capacity = 17)
            : base(capacity)
        {
            setupExpiration(lifeTime, callback);
        }

        public override ICard<V> EmptyCard()
        {
            return new CacheCard<V>();
        }

        public override ICard<V>[] EmptyCardTable(int size)
        {
            return new CacheCard<V>[size];
        }

        public override ICard<V>[] EmptyDeck(int size)
        {
            return new CacheCard<V>[size];
        }

        public override ICard<V> NewCard(ICard<V> card)
        {
            return new CacheCard<V>(card, duration, callback);
        }

        public override ICard<V> NewCard(object key, V value)
        {
            return new CacheCard<V>(key, value, duration, callback);
        }

        public override ICard<V> NewCard(ulong key, V value)
        {
            return new CacheCard<V>(key, value, duration, callback);
        }

        public override ICard<V> NewCard(V value)
        {
            return new CacheCard<V>(value, duration, callback);
        }
    }
}
