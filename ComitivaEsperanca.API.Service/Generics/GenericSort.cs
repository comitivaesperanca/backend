using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ComitivaEsperanca.API.Generics
{
    public class GenericSort
    {
        public static IOrderedQueryable<TObject> SortByAscending<TObject, TResult>(IQueryable<TObject> queryableList, Expression<Func<TObject, TResult>> condition)
            => queryableList.OrderBy(condition);

        public static IOrderedQueryable<TObject> SortByDescending<TObject, TResult>(IQueryable<TObject> queryableList, Expression<Func<TObject, TResult>> condition)
            => queryableList.OrderByDescending(condition);

        public static async Task<List<TList>> SkipTakeAndSelectItemsAsync<TList, TObject>(IQueryable<TObject> itemsOrderQueryble, int pageSize, int pageIndex, Expression<Func<TObject, TList>> condition)
            => await itemsOrderQueryble.Skip(pageSize * (pageIndex - 1))
                           .Take(pageSize)
                           .Select(condition)
                           .ToListAsync();
    }
}
