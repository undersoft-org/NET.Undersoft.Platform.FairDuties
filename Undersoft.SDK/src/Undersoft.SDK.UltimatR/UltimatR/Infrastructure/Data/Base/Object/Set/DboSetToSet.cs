using System.Collections.ObjectModel;
using System.Linq;
using System.Series;
using System.Uniques;

namespace UltimatR
{

    public class DboSetToSet<TLeft, TRight> : KeyedCollection<long, IEntityLink<TLeft, TRight>>, IFindable where TLeft : class, IIdentifiable where TRight : class, IIdentifiable
    {
        // public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected override long GetKeyForItem(IEntityLink<TLeft, TRight> item)
        {
            return (item.Id == 0) ? (long)item.AutoId() : item.Id;
        }

        public IEntityLink<TLeft, TRight> Single
        {
            get => this.FirstOrDefault();
        }

        public object this[object key]
        {
            get
            {
                TryGetValue((long)(key.UniqueKey64()), out IEntityLink<TLeft, TRight> result);
                return result;
            }
            set
            {
                Dictionary[(long)(key.UniqueKey64())] = (EntityLink<TLeft, TRight>)value;
            }
        }

        protected override void ClearItems()
        {
            base.ClearItems();
            // CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        protected override void InsertItem(int index, IEntityLink<TLeft, TRight> item)
        {
            base.InsertItem(index, item);
            // CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }

        protected override void RemoveItem(int index)
        {
            // var item = base.Items[index];
            base.RemoveItem(index);
            // CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
        }

        protected override void SetItem(int index, IEntityLink<TLeft, TRight> item)
        {
            // var olditem = base.Items[index];
            base.SetItem(index, item);
            //  CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, item, olditem, index));
        }
    }
}