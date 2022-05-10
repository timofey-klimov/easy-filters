using Filters.FiltersAbstract.Builder.Condition;
using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersImpl.Builder.Condition
{
    public class StandardConditionBuilder<T> : IStandardConditionBuilder<T>
        where T: struct
    {
        private readonly StandardFilterInfo<T> _info;
        public StandardConditionBuilder(StandardFilterInfo<T> info)
        {
            _info = info ?? throw new ArgumentNullException(nameof(info));
        }

        public StandardFilterInfo<T> Build() => _info;

        public void Equals(T value)
        {
            _info.Condition = StandardCondition.Equal;
            _info.Value = value;
        }

        public void GreaterOrEquals(T value)
        {
            _info.Condition = StandardCondition.GreaterThanOrEqual;
            _info.Value = value;
        }

        public void GreaterThan(T value)
        {
            _info.Condition = StandardCondition.GreaterThan;
            _info.Value = value;
        }

        public void LessOrEquals(T value)
        {
            _info.Condition = StandardCondition.LessThanOrEqual;
            _info.Value = value;
        }

        public void LessThan(T value)
        {
            _info.Condition = StandardCondition.LessThan;
            _info.Value = value;
        }

        public void NotEquals(T value)
        {
            _info.Condition = StandardCondition.NotEqual;
            _info.Value = value;
        }
    }
}
