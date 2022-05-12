using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersAbstract.Builder.Condition
{
    public interface IRangeStartValueConditionBuilder<T>
        where T : struct
    {
        void LessThan(T value);

        void LessOrEqual(T value);

    }
}
