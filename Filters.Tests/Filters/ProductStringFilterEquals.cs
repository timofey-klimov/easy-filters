using Filters.FiltersImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters.Tests.Filters
{
    public class ProductStringFilterEquals : FilterModel<Product>
    {
        public ProductStringFilterEquals(string value)
        {
            Create(x => x.Name,
                x => x.GetStringFilter()
                    .SelectCondition(x => x.Equals(value)));
        }
    }
}
