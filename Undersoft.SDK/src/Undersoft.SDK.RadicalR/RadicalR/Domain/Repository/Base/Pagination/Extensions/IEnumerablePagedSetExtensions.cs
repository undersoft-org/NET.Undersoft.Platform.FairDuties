﻿using System;
using System.Collections.Generic;

namespace RadicalR
{
    public static class IEnumerablePagedSetExtensions
    {
        public static IPagedSet<T> ToPagedSet<T>(this IEnumerable<T> source, int pageIndex, int pageSize, int indexFrom = 0) => new PagedSet<T>(source, pageIndex, pageSize, indexFrom);

        public static IPagedSet<TResult> ToPagedSet<TSource, TResult>(this IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter, int pageIndex, int pageSize, int indexFrom = 0) => new PagedSet<TSource, TResult>(source, converter, pageIndex, pageSize, indexFrom);
    }
}
