using Filters.FiltersImpl;

namespace Filters.Tests.Filters
{
    public class ProductStandardFilterEquals : FilterModel<Product>
    {
        public ProductStandardFilterEquals(int value)
        {
            Create(x => x.InStock,
                x => x.GetStandardFilter<int>()
                    .SelectCondition(x => x.Equals(value)));
        }
    }
}
