using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersAbstract.Conventions.Fabric
{
    public interface IFilterConventionFabric
    {
        IConvention Create(FilterType filterType);
    }
}
