using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersAbstract.Builder
{
    public interface IFilterBuilder
    {
        IStringFilterBuilder GetStringFilter();

        IStandardFilterBuilder<T> GetStandardFilter<T>()
            where T : struct;

        IRangeFilterBuilder<T> GetRangeFilter<T>()
            where T : struct;

        FilterInfo Build();
    }
}
