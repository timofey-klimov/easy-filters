using Filters.FiltersAbstract.Builder;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersImpl.Builder
{
    public class FilterBuilder : IFilterBuilder
    {
        private FilterInfo _info;

        public FilterInfo Build() => _info;

        public IStringFilterBuilder GetStringFilter()
        {
            _info = new StringFilterInfo();

            return new StringFilterBuilder(_info);
        }
    }
}
