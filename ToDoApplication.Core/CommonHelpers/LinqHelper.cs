using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ToDoApplication.Common.ValueTypes;

namespace ToDoApplication.Core.CommonHelpers
{
    public static class LinqHelper
    {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source, bool condition, Expression<Func<TSource, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int pageIndex, int pageSize)
        {
            return source.Skip((pageIndex - Int.One) * pageSize).Take(pageSize);
        }

        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int pageIndex, int pageSize)
        {
            return source.Skip((pageIndex - Int.One) * pageSize).Take(pageSize);
        }
    }
}
