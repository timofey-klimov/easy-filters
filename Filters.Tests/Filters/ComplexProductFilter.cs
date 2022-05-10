using Filters.FiltersImpl;

namespace Filters.Tests.Filters
{
    public class ComplexProductFilter : FilterModel<Product>
    {

        public ComplexProductFilter(string name, int inStock)
        {
            Create(x => x.Name,
                x => x.GetStringFilter()
                    .SelectCondition(x => x.Contains(name)));

            Create(x => x.InStock,
                x => x.GetStandardFilter<int>()
                    .SelectCondition(x => x.GreaterOrEquals(inStock)));
        }
    }
}
