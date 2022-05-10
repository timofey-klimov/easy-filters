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
                FilterType.StandardFilter => CreateStandardFilterConvention(valueType),

                _ => throw new InvalidOperationException()
            };
        }

        private IConvention CreateStandardFilterConvention(Type valueType)
        {
            var filterType = typeof(StandardFilterConvention<>);
            var constructed = filterType.MakeGenericType(valueType);
            return (IConvention)Activator.CreateInstance(constructed);
        }
    }
}
