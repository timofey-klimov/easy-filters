using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersImpl;

namespace Filters.Tests
{
    public class ProductFilter : FilterModel<Product>
    {
        public ProductFilter(string name, StringCondition stringCondition)
        {
            Create(x => x.Name,
                x => x.GetStringFilter()
                .SelectCondition(stringCondition)
                .SetValue(name));
        }
    }
}
