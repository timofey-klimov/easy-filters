using Filters.FiltersAbstract.Builder.Condition;
using Filters.FiltersAbstract.Builder.Types;

namespace Filters.FiltersAbstract.Builder
{
    public interface IStringFilterBuilder
    {
        void SelectCondition(Action<IStringConditionBuilder> conditionBuilder);
    }
}
