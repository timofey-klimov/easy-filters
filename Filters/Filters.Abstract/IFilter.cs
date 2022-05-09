namespace Filters.FiltersAbstract
{
    public interface IFilter<T>
    {
        IQueryable<T> Filter(IQueryable<T> query, ExpressionCondition condition);
    }
}
