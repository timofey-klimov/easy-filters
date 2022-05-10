using Filters.FiltersImpl;

namespace Filters.Tests.Filters
{
    public class ProductStandardFilterLessThan : FilterModel<Product>
    {
        public ProductStandardFilterLessThan(int value)
        {
            Create(x => x.InStock,
                x => x.GetStandardFilter<int>()
                    .SelectCondition(x => x.LessThan(value)));
        }
    }
}
