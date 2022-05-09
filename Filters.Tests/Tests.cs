using Filters.Extensions;
using Filters.FiltersAbstract;
using Filters.FiltersImpl;
using Filters.Tests.Filters;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
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
            var expected = _dbContext.Products.Where(x => x.Name.Contains("ea"));

            var result = _dbContext.Products.Filter(new ProductFilter("ea", FiltersAbstract.Builder.Types.StringCondition.Contains));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringFilter_StartsWith_Success()
        {
            var expected = _dbContext.Products.Where(x => x.Name.StartsWith("P"));

            var result = _dbContext.Products.Filter(new ProductFilter("P", FiltersAbstract.Builder.Types.StringCondition.StartsWith));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringFilter_Equals_Success()
        {
            var expected = _dbContext.Products.Where(x => x.Name == "Pen");

            var result = _dbContext.Products.Filter(new ProductFilter("Pen", FiltersAbstract.Builder.Types.StringCondition.Equals));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void StringFilter_ThrowsTypeChecking()
        {
            Assert.Throws<TypeCheckException>(() => _dbContext.Products.Filter(new ProductFailedInStockFilter()));
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
