using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using System.Linq.Expressions;
using System.Reflection;

namespace Filters.FiltersAbstract.Conventions
{
    public interface IConvention
    {
        Expression<Func<T, bool>> CreateFilterExpression<T>(FilterInfo filterInfo, PropertyInfo propInfo, ParameterExpression paramExp);
    }
}
