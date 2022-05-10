namespace Filters.FiltersAbstract.Builder.Types.FilterInfo
{
    public abstract class FilterInfo
    {
        public abstract FilterType FilterType { get; }

        public abstract Type GetValueType();
    }
}
