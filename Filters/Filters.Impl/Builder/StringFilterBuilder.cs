using Filters.FiltersAbstract.Builder;
using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersImpl.Builder
{
    public class StringFilterBuilder : IStringFilterBuilder
    {
        private readonly StringFilterInfo _info;
        public StringFilterBuilder(FilterInfo filterInfo)
        {
            if (filterInfo is StringFilterInfo info)
                _info = info;
            else
                throw new ArgumentException($"argument is not typeof StringFilterInfo");
        }

        public IStringFilterBuilder SelectCondition(StringCondition condition)
        {
            _info.Condition = condition;
            return this;
        }

        public IStringFilterBuilder SetValue(string value)
        {
            _info.Value = value;
            return this;
        }
    }
}
