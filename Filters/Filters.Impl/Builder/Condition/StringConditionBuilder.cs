using Filters.FiltersAbstract.Builder.Condition;
using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersImpl.Builder.Condition
{
    public class StringConditionBuilder : IStringConditionBuilder
    {
        private StringFilterInfo _info;

        public StringConditionBuilder(StringFilterInfo info)
        {
            _info = info ?? throw new ArgumentNullException(nameof(info));
        }
        public StringFilterInfo Build() => _info;
       

        public void Contains(string value)
        {
            _info.Value = value;
            _info.Condition = StringCondition.Contains;
        }

        public void EndsWith(string value)
        {
            _info.Value = value;
            _info.Condition = StringCondition.EndsWith;
        }

        public void Equals(string value)
        {
            _info.Value = value;
            _info.Condition = StringCondition.Equals;
        }

        public void StartsWith(string value)
        {
            _info.Value = value;
            _info.Condition = StringCondition.StartsWith;
        }
    }
}
