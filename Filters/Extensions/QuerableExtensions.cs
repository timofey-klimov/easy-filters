using Filters.FiltersAbstract;

namespace Filters.Extensions
{
    public static class QuerableExtensions
    {
        public static IQueryable<T> Filter<T>(
            this IQueryable<T> query, 
            IFilter<T> filter, ExpressionCondition condition = ExpressionCondition.And) => 
                filter.Filter(query, condition);
    }
}
