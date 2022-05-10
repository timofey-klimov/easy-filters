using Filters.FiltersImpl;

namespace Filters.Tests.Filters
{
    public class ProductStandardFilterGreaterThan : FilterModel<Product>
    {
        public ProductStandardFilterGreaterThan(int value)
        {
            Create(x => x.InStock,
                x => x.GetStandardFilter<int>()
                    .SelectCondition(x => x.GreaterThan(value)));
        }
    }
}
