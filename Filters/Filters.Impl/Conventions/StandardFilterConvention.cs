using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using Filters.FiltersAbstract.Conventions;
using System.Linq.Expressions;
using System.Reflection;

namespace Filters.FiltersImpl.Conventions
{
    public class StandardFilterConvention<TValue> : BaseConvention
        where TValue: struct
    {
        public override Expression<Func<T, bool>> CreateFilterExpression<T>(FilterInfo filterInfo, PropertyInfo propInfo, ParameterExpression paramExp)
        {
            _ = filterInfo ?? throw new ArgumentNullException(nameof(filterInfo));

            if (filterInfo is not StandardFilterInfo<TValue> info)
                throw new ArgumentException(nameof(filterInfo));

            if (info.IsDefault)
                return DoNothing<T>();

            var propertyExpr = Expression.Property(paramExp, propInfo);
            var constant = Expression.Constant(info.Value);

            var binaryExpr = info.Condition switch
            {
                StandardCondition.Equal => Expression.Equal(propertyExpr, constant),
                StandardCondition.NotEqual => Expression.NotEqual(propertyExpr, constant),
                StandardCondition.LessThan => Expression.LessThan(propertyExpr, constant),
                StandardCondition.GreaterThan => Expression.GreaterThan(propertyExpr, constant),
                StandardCondition.LessThanOrEqual => Expression.LessThanOrEqual(propertyExpr, constant),
                StandardCondition.GreaterThanOrEqual => Expression.GreaterThanOrEqual(propertyExpr, constant),
                _ => throw new NotImplementedException()
            };

            return Expression.Lambda<Func<T, bool>>(binaryExpr, paramExp);
        }
    }
}
