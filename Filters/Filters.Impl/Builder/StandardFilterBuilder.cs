using Filters.FiltersAbstract.Builder;
using Filters.FiltersAbstract.Builder.Condition;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using Filters.FiltersImpl.Builder.Condition;

namespace Filters.FiltersImpl.Builder
{
    public class StandardFilterBuilder<T> : IStandardFilterBuilder<T>
        where T: struct
    {
        private StandardFilterInfo<T> _info;

        public StandardFilterBuilder(FilterInfo filterInfo)
        {
            if (filterInfo is not StandardFilterInfo<T> info)
                throw new ArgumentException(nameof(filterInfo));

            _info = info;
        }

        public void SelectCondition(Action<IStandardConditionBuilder<T>> conditionBuilder)
        {
            var builder = new StandardConditionBuilder<T>(_info);

            conditionBuilder(builder);

            _info = builder.Build();
        }
    }
}
