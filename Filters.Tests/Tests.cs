using Filters.Extensions;
using Filters.FiltersImpl;
using Filters.Tests.Filters;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace Filters.Tests
{
    [TestFixture]
    public class Tests
    {
        private TestDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            CreateDbContext();
        }
        
        [Test]
        public void StringFilter_Contains_Success()
        {
            var value = "ea";

            var expected = _dbContext.Products.Where(x => x.Name.Contains(value));

            var result = _dbContext.Products.Filter(new ProductStringFilterContains(value));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringFilter_StartsWith_Success()
        {
            var value = "P";

            var expected = _dbContext.Products.Where(x => x.Name.StartsWith(value));

            var result = _dbContext.Products.Filter(new ProductStringFilterStartsWith(value));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringFilter_Equals_Success()
        {
            var value = "Pen";

            var expected = _dbContext.Products.Where(x => x.Name == value);

            var result = _dbContext.Products.Filter(new ProductStringFilterEquals(value));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringFilter_ThrowsTypeChecking()
        {
            Assert.Throws<TypeCheckException>(() => _dbContext.Products.Filter(new ProductFailedInStockFilter()));
        }

        [Test]
        public void StandardFilter_Equals_Success()
        {
            int value = 20;

            var expected = _dbContext.Products.Where(x => x.InStock == value);

            var result = _dbContext.Products.Filter(new ProductStandardFilterEquals(value));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardFilter_NotEquals_Success()
        {
            int value = 20;

            var expected = _dbContext.Products.Where(x => x.InStock != value);

            var result = _dbContext.Products.Filter(new ProductStandardFilterNotEquals(value));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardFilter_LessThan_Success()
        {
            int value = 50;

            var expected = _dbContext.Products.Where(x => x.InStock < value);

            var result = _dbContext.Products.Filter(new ProductStandardFilterLessThan(value));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StandardFilter_GreaterThan_Success()
        {
            int value = 50;

            var expected = _dbContext.Products.Where(x => x.InStock > 50);

            var result = _dbContext.Products.Filter(new ProductStandardFilterGreaterThan(value));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Complex_Success()
        {
            int inStock = 20;

            var name = "ea";

            var expected = _dbContext.Products.Where(x => x.InStock >= inStock && x.Name.Contains(name));

            var result = _dbContext.Products.Filter(new ComplexProductFilter(name, inStock));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RangeFilter_Success()
        {
            var startValue = 0;
            var endValue = 100;

            var expected = _dbContext.Products.Where(x => x.InStock >= 0 && x.InStock <= endValue);

            var result = _dbContext.Products.Filter(new RangeProductFilter(startValue, endValue));

            Assert.AreEqual(expected, result);
        }

        #region helper
        public void CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
             .UseInMemoryDatabase(databaseName: "Test")
             .Options;

            _dbContext = new TestDbContext(options);
            _dbContext.Products.Add(new Product("Sneackers", 10));
            _dbContext.Products.Add(new Product("Pear", 20));
            _dbContext.Products.Add(new Product("Orange", 30));
            _dbContext.Products.Add(new Product("Crocs", 150));
            _dbContext.Products.Add(new Product("Pen", 20));
            _dbContext.Products.Add(new Product("Eraser", 25));
            _dbContext.Products.Add(new Product("SmartPhone", 35));
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
