using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using Filters.FiltersAbstract.Conventions;
using System.Linq.Expressions;
using System.Reflection;

namespace Filters.FiltersImpl.Conventions
{
    public class RangeFilterConvention<TValue> : BaseConvention
        where TValue : struct
    {
        public override Expression<Func<T, bool>> CreateFilterExpression<T>(FilterInfo filterInfo, PropertyInfo propInfo, ParameterExpression paramExp)
        {
            if (filterInfo is not RangeFilterInfo<TValue> info)
                throw new ArgumentException(nameof(filterInfo));

            if (info.IsStartValueDefault && info.IsEndValueDefault)
                return DoNothing<T>();

            var propExpr = Expression.Property(paramExp, propInfo);

            BinaryExpression startBinaryExp = default;
            BinaryExpression endBinaryExpr = default;
            BinaryExpression andAlso = default;

            if (!info.IsStartValueDefault)
            {
                var startValue = Expression.Constant(info.StartValue);

                startBinaryExp = info.StartCondition switch
                {
                    RangeCondition.LessThan => Expression.GreaterThan(propExpr, startValue),
                    RangeCondition.LessOrEqual => Expression.GreaterThanOrEqual(propExpr, startValue),
                    _ => throw new NotImplementedException()
                };
            }

            if (!info.IsEndValueDefault)
            {
                var endValue = Expression.Constant(info.EndValue);

                endBinaryExpr = info.EndCondition switch
                {
                    RangeCondition.GreaterThan => Expression.LessThan(propExpr, endValue),
                    RangeCondition.GreaterOrEqual => Expression.LessThanOrEqual(propExpr, endValue),
                    _ => throw new NotImplementedException()
                };
            }

            if (!info.IsEndValueDefault && !info.IsStartValueDefault)
                andAlso = Expression.AndAlso(startBinaryExp!, endBinaryExpr!);
            else
                andAlso = startBinaryExp ?? endBinaryExpr;

            return Expression.Lambda<Func<T, bool>>(andAlso, paramExp);

        }
    }
}
