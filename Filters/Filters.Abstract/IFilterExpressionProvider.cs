using System.Linq.Expressions;

namespace Filters.FiltersAbstract
{
    public interface IFilterExpressionProvider
    {
        Expression<Func<T, bool>> CreateExpression<T>(ExpressionCondition condition);
    }
}
