using Filters.FiltersImpl;

namespace Filters.Tests.Filters
{
    public class ProductStringFilterContains : FilterModel<Product>
    {
        public ProductStringFilterContains(string value)
        {
            Create(x => x.Name, x => x.GetStringFilter()
                .SelectCondition(x => x.Contains(value)));
        }
    }
}
