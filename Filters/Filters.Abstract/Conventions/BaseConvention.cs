using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using System.Linq.Expressions;
using System.Reflection;

namespace Filters.FiltersAbstract.Conventions
{
    public abstract class BaseConvention : IConvention
    {
        public abstract Expression<Func<T, bool>> CreateFilterExpression<T>(FilterInfo filterInfo, PropertyInfo propInfo, ParameterExpression paramExp);

        protected Expression<Func<T, bool>> DoNothing<T>() =>
            _ => true;
        
    }
}
