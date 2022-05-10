using Filters.FiltersImpl;

namespace Filters.Tests.Filters
{
    public class ProductFailedInStockFilter : FilterModel<Product>
    {
        public ProductFailedInStockFilter()
        {
            Create(x => x.InStock,
                x => x.GetStringFilter()
                .SelectCondition(x => x.Contains("Anb")));
        }
    }
}
