using Filters.FiltersImpl;

namespace Filters.Tests.Filters
{
    public class RangeProductFilter : FilterModel<Product>
    {
        public RangeProductFilter(int startValue, int endValue)
        {
            Create(x => x.InStock,
                x => x.GetRangeFilter<int>()
                    .SelectEndValueCondition(x => x.GreaterOrEqual(endValue))
                    .SelectStartValueCondition(x => x.LessOrEqual(startValue)));
        }
    }
}
