﻿using PresentR.Components;

namespace PresentR
{
    public abstract class ViewData<TModel> : IDataService<TModel> where TModel : class, new()
    {
        public virtual Task<bool> AddAsync(TModel model) => Task.FromResult(true);

        public virtual Task<bool> DeleteAsync(IEnumerable<TModel> models) => Task.FromResult(true);

        public virtual Task<bool> SaveAsync(TModel model, ItemChangedType changedType) => Task.FromResult(true);

        public abstract Task<QueryData<TModel>> QueryAsync(QueryPageOptions option);
    }
}