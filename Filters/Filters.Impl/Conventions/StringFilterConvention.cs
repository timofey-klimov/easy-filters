using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using Filters.FiltersAbstract.Conventions;
using System.Linq.Expressions;
using System.Reflection;

namespace Filters.FiltersImpl.Conventions
{
    public class StringFilterConvention : BaseConvention
    {
        private static MethodInfo Equals
            = typeof(string).GetMethod("Equals", new[] { typeof(string) });

        private static MethodInfo Contains
            = typeof(string).GetMethod("Contains", new[] { typeof(string) });

        private static MethodInfo StartsWith
            = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });

        private static MethodInfo EndsWith
            = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

        public override Expression<Func<T, bool>> CreateFilterExpression<T>(FilterInfo filterInfo, PropertyInfo propInfo, ParameterExpression paramExp)
        {
            if (propInfo.PropertyType != typeof(string))
                throw new TypeCheckException("Property type must be typeof string");

            if (filterInfo is not StringFilterInfo stringFilterInfo)
                throw new Exception("Invalid filterInfo type");

            if (stringFilterInfo.IsNullOrEmpty)
                return DoNothing<T>();

            var constant = Expression.Constant(stringFilterInfo.Value);

            var propExpr = Expression.Property(paramExp, propInfo);

            var methodCall = stringFilterInfo.Condition switch
            {
                StringCondition.Equals => Expression.Call(propExpr, Equals, constant),
                StringCondition.Contains => Expression.Call(propExpr, Contains, constant),
                StringCondition.StartsWith => Expression.Call(propExpr, StartsWith, constant),
                StringCondition.EndsWith => Expression.Call(propExpr, EndsWith, constant),
                _ => throw new InvalidOperationException()
            };

            return Expression.Lambda<Func<T, bool>>(methodCall, paramExp);
        }
    }
}
