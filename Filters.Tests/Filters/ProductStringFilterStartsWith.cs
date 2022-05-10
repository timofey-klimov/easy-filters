using Filters.FiltersImpl;

namespace Filters.Tests.Filters
{
    public class ProductStringFilterStartsWith : FilterModel<Product>
    {
        public ProductStringFilterStartsWith(string value)
        {
            Create(x => x.Name,
                x => x.GetStringFilter()
                    .SelectCondition(x => x.StartsWith(value)));
        }
    }
}
