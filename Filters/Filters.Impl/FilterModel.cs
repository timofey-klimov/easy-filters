using Filters.FiltersAbstract;
using Filters.FiltersAbstract.Builder;
using Filters.FiltersAbstract.Builder.Types.FilterInfo;
using Filters.FiltersImpl.Builder;
using System.Linq.Expressions;
using System.Reflection;

namespace Filters.FiltersImpl
{
    public abstract class FilterModel<TEntity> : IFilter<TEntity>
    {
        private readonly IDictionary<PropertyInfo, FilterInfo> _dict;

        public FilterModel()
        {
            _dict = new Dictionary<PropertyInfo, FilterInfo>();
        }

        public IQueryable<TEntity> Filter(IQueryable<TEntity> query, ExpressionCondition condition)
        {
            var provider = new FilterExpressionProvider(_dict);

            return query.Where(provider.CreateExpression<TEntity>(condition));
        }

        protected void Create<TProp>(Expression<Func<TEntity, TProp>> propCreator, Action<IFilterBuilder> builderAction)
        {
            var prop = (PropertyInfo)((MemberExpression)propCreator.Body).Member;

            var filterBuilder = new FilterBuilder();

            builderAction(filterBuilder);

            var filterInfo = filterBuilder.Build();

            if (_dict.ContainsKey(prop))
                throw new Exception("Property already has filter");

            _dict.Add(prop, filterInfo);
        }
    }
}
