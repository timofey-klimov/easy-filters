using Filters.FiltersAbstract.Builder.Types;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;

namespace Filters.FiltersAbstract.Builder.Condition
{
    public interface IStandardConditionBuilder<T>
        where T: struct
    {
        void Equals(T value);

        void NotEquals(T value);

        void LessThan(T value);

        void GreaterThan(T value);

        void LessOrEquals(T value);

        void GreaterOrEquals(T value);

        StandardFilterInfo<T> Build();
    }
}
