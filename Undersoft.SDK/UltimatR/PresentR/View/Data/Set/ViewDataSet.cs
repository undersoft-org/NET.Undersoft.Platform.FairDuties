using BootstrapBlazor.Components;

using System.Collections.Generic;
using System.Threading.Tasks;
using UltimatR;

namespace PresentR
{
    public class ViewDataSet<TModel> : ViewData<TModel> where TModel : class, IIdentifiable, new()
    {
        protected IDsoSet<IEntryStore, TModel> _entrySet;
        protected IDsoSet<IReportStore, TModel> _reportSet;

        public ViewDataSet(IDsoSet<IEntryStore, TModel> entrySet, IDsoSet<IReportStore, TModel> reportSet) { _entrySet = entrySet; _reportSet = reportSet; }

        public override Task<bool> AddAsync(TModel model) => Task.FromResult(true);

        public override Task<bool> DeleteAsync(IEnumerable<TModel> models) => Task.FromResult(true);

        public override Task<bool> SaveAsync(TModel model, ItemChangedType changedType) => Task.FromResult(true);

        public override Task<QueryData<TModel>> QueryAsync(QueryPageOptions option) => null;
    }
}