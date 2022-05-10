using Filters.FiltersAbstract.Builder.Condition;

namespace Filters.FiltersAbstract.Builder
{
    public interface IStandardFilterBuilder<T>
        where T: struct
    {
        void SelectCondition(Action<IStandardConditionBuilder<T>> standardCondition);
    }
}
