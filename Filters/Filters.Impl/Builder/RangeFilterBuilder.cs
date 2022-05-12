using Filters.FiltersAbstract.Builder;
using Filters.FiltersAbstract.Builder.Condition;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using Filters.FiltersImpl.Builder.Condition;

namespace Filters.FiltersImpl.Builder
{
    public class RangeFilterBuilder<T> : IRangeFilterBuilder<T>
        where T:struct
    {
        private RangeFilterInfo<T> _info;

        public RangeFilterBuilder(FilterInfo filterInfo)
        {
            if (filterInfo is not RangeFilterInfo<T> info)
                throw new ArgumentException(nameof(filterInfo));

            _info = info;
        }

        public IRangeFilterBuilder<T> SelectEndValueCondition(Action<IRangeEndValueConditionBuilder<T>> builderAction)
        {
            var builder = new RangeEndValueConditionBuilder<T>(_info);

            builderAction(builder);

            return this;
        }

        public IRangeFilterBuilder<T> SelectStartValueCondition(Action<IRangeStartValueConditionBuilder<T>> builderAction)
        {
            var builder = new RangeStartValueConditionBuilder<T>(_info);

            builderAction(builder);

            return this;
        }
    }
}
