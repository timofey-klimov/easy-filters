using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersAbstract.Builder.Condition
{
    public interface IStringConditionBuilder
    {
        void Equals(string value);

        void StartsWith(string value);

        void EndsWith(string value);

        void Contains(string value);

        StringFilterInfo Build();
    }
}
