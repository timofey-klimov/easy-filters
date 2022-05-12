namespace Filters.FiltersAbstract.Builder.Types.FilterInfo
{
    public class RangeFilterInfo<T> : FilterInfo
        where T : struct
    {
        public T StartValue { get; set; }
        public RangeCondition StartCondition { get; set; }


        public T EndValue { get; set; }
        public RangeCondition EndCondition { get; set; }


        public bool IsStartValueDefault => StartValue.Equals(default(T));
        public bool IsEndValueDefault => EndValue.Equals(default(T));

        public override FilterType FilterType => FilterType.RangeFilter;

        public override Type GetValueType()
        {
            return typeof(T);
        }
    }
}
