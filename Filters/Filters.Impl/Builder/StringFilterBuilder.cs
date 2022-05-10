using Filters.FiltersAbstract.Builder;
using Filters.FiltersAbstract.Builder.Condition;
using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using Filters.FiltersImpl.Builder.Condition;

namespace Filters.FiltersImpl.Builder
{
    public class StringFilterBuilder : IStringFilterBuilder
    {
        private StringFilterInfo _info;
        public StringFilterBuilder(FilterInfo filterInfo)
        {
            if (filterInfo is StringFilterInfo info)
                _info = info;
            else
                throw new ArgumentException($"argument is not typeof StringFilterInfo");
        }

        public void SelectCondition(Action<IStringConditionBuilder> conditionBuilder)
        {
            var builder = new StringConditionBuilder(_info);

            conditionBuilder(builder);

            _info = builder.Build(); 
        }
    }
}
