using Filters.FiltersAbstract.Builder.Condition;
using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersImpl.Builder.Condition
{
    public class RangeEndValueConditionBuilder<T> : IRangeEndValueConditionBuilder<T>
        where T : struct
    {
        private RangeFilterInfo<T> _info;

        public RangeEndValueConditionBuilder(RangeFilterInfo<T> info)
        {
            _info = info ?? throw new ArgumentNullException(nameof(info));
        }

        public void GreaterOrEqual(T value)
        {
            _info.EndValue = value;
            _info.EndCondition = RangeCondition.GreaterOrEqual;
        }

        public void GreaterThan(T value)
        {
            _info.EndValue = value;
            _info.EndCondition = RangeCondition.GreaterThan;
        }
    }
}
