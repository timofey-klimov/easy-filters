namespace Filters.FiltersAbstract.Builder.Types.FilterInfo
{
    public class StandardFilterInfo<T> : FilterInfo
        where T: struct
    {
        public T Value { get; set; }

        public StandardCondition Condition { get; set; }

        public override FilterType FilterType => FilterType.StandardFilter;

        public bool IsDefault => Value.Equals(default);

        public override Type GetValueType()
        {
            return typeof(T);
        }
    }
}
