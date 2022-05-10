using Filters.FiltersImpl;

namespace Filters.Tests.Filters
{
    public class ProductStandardFilterNotEquals : FilterModel<Product>
    {
        public ProductStandardFilterNotEquals(int value)
        {
            Create(x => x.InStock,
                x => x.GetStandardFilter<int>()
                    .SelectCondition(x => x.NotEquals(value)));
        }
    }
}
