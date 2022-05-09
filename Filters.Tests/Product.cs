namespace Filters.Tests
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int InStock { get; set; }

        public Product(string name, int inStock)
        {
            Name = name;
            InStock = inStock;
        }
    }
}
