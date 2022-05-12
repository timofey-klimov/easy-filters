namespace Filters.FiltersAbstract.Builder.Condition
{
    public interface IRangeEndValueConditionBuilder<T>
        where T : struct
    {
        void GreaterThan(T value);

        void GreaterOrEqual(T value);
    }
}
