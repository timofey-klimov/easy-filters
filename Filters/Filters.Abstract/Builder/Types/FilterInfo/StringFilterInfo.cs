namespace Filters.FiltersAbstract.Builder.Types.FilterInfo
{
    public class StringFilterInfo : FilterInfo
    {
        public override FilterType FilterType => FilterType.StringFilter;

        public string Value { get; set; }

        public bool IsNullOrEmpty => string.IsNullOrEmpty(Value);

        public StringCondition Condition { get; set; }

        public override Type GetValueType()
        {
            return typeof(string);
        }
    }
}
