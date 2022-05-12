using Filters.FiltersAbstract.Builder.Condition;

namespace Filters.FiltersAbstract.Builder
{
    public interface IRangeFilterBuilder<T>
        where T: struct
    {
        IRangeFilterBuilder<T> SelectStartValueCondition(Action<IRangeStartValueConditionBuilder<T>> builder);

        IRangeFilterBuilder<T> SelectEndValueCondition(Action<IRangeEndValueConditionBuilder<T>> builder);
    }
}
