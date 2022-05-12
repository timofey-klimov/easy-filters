using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using Filters.FiltersAbstract.Conventions;
using Filters.FiltersAbstract.Conventions.Fabric;

namespace Filters.FiltersImpl.Conventions.Fabric
{
    public class FilterConventionFabric : IFilterConventionFabric
    {
        public IConvention Create(FilterType filterType, Type valueType)
        {
            return filterType switch
            {
                FilterType.StringFilter => new StringFilterConvention(),
                FilterType.StandardFilter => CreateGenericFilter(typeof(StandardFilterConvention<>), valueType),
                FilterType.RangeFilter => CreateGenericFilter(typeof(RangeFilterConvention<>), valueType),
                _ => throw new InvalidOperationException()
            };
        }

        private IConvention CreateGenericFilter(Type filterType, Type valueType)
        {
            var constructed = filterType.MakeGenericType(valueType);

            if (constructed is null
                || constructed.IsAbstract
                || constructed.IsInterface
                || !typeof(IConvention).IsAssignableFrom(filterType))
                throw new ArgumentException(nameof(filterType));

            return (IConvention)Activator.CreateInstance(constructed)!;
        }
    }
}
