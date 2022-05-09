using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersAbstract.Builder
{
    public interface IFilterBuilder
    {
        IStringFilterBuilder GetStringFilter();

        FilterInfo Build();
    }
}
