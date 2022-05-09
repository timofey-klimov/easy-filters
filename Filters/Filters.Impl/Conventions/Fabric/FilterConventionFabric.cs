using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using Filters.FiltersAbstract.Conventions;
using Filters.FiltersAbstract.Conventions.Fabric;

namespace Filters.FiltersImpl.Conventions.Fabric
{
    public class FilterConventionFabric : IFilterConventionFabric
    {
        public IConvention Create(FilterType filterType)
        {
            return filterType switch
            {
                FilterType.StringFilter => new StringFilterConvention(),

                _ => throw new InvalidOperationException()
            };
        }
    }
}
