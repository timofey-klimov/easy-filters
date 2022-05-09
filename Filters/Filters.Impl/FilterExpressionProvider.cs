using Filters.Extensions;
using Filters.FiltersAbstract;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using Filters.FiltersImpl.Conventions.Fabric;
using System.Linq.Expressions;
using System.Reflection;

namespace Filters.FiltersImpl
{
    public class FilterExpressionProvider : IFilterExpressionProvider
    {
        private readonly IDictionary<PropertyInfo, FilterInfo> _filterInfo;
        public FilterExpressionProvider(IDictionary<PropertyInfo, FilterInfo> filterInfo)
        {
            _filterInfo = filterInfo ?? throw new ArgumentNullException(nameof(filterInfo)); 
        }

        public Expression<Func<T, bool>> CreateExpression<T>(ExpressionCondition condition)
        {
            var parameter = Expression.Parameter(typeof(T));

            var expressions = _filterInfo.Select(x => Create<T>(parameter, x.Key, x.Value));

            var expr = condition == ExpressionCondition.And
                ? expressions.Aggregate((c, n) => c.And(n))
                : expressions.Aggregate((c, n) => c.Or(n));

            return expr;
        }

        private Expression<Func<T, bool>> Create<T>(ParameterExpression parameter, PropertyInfo info, FilterInfo filterInfo)
        {
            var fabric = new FilterConventionFabric();

            return fabric.Create(filterInfo.FilterType)
                .CreateFilterExpression<T>(filterInfo, info, parameter);
        }
    }
}
