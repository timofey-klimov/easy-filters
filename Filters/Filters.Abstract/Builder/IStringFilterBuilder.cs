using Filters.FiltersAbstract.Builder.Types;

namespace Filters.FiltersAbstract.Builder
{
    public interface IStringFilterBuilder
    {
        IStringFilterBuilder SetValue(string value);

        IStringFilterBuilder SelectCondition(StringCondition condition);
    }
}
