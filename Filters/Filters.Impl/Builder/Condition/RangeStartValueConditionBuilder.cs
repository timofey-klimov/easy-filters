using Filters.FiltersAbstract.Builder.Condition;
using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersImpl.Builder.Condition
{
    public class RangeStartValueConditionBuilder<T> : IRangeStartValueConditionBuilder<T>
        where T : struct
    {
        private RangeFilterInfo<T> _info;

        public RangeStartValueConditionBuilder(RangeFilterInfo<T> info)
        {
            _info = info ?? throw new ArgumentNullException(nameof(info));
        }

        public void LessOrEqual(T value)
        {
            _info.StartValue = value;
            _info.StartCondition = RangeCondition.LessOrEqual;
        }

        public void LessThan(T value)
        {
            _info.StartValue = value;
            _info.StartCondition = RangeCondition.LessThan;
        }
    }
}
