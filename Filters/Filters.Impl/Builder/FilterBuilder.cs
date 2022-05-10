using Filters.FiltersAbstract.Builder;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersImpl.Builder
{
    public class FilterBuilder : IFilterBuilder
    {
        private FilterInfo _info;

        public FilterInfo Build() => _info;

        public IStandardFilterBuilder<T> GetStandardFilter<T>()
            where T: struct
        {
            _info = new StandardFilterInfo<T>();
            return new StandardFilterBuilder<T>(_info);
        }

        public IStringFilterBuilder GetStringFilter()
        {
            _info = new StringFilterInfo();
            return new StringFilterBuilder(_info);
        }
    }
}
