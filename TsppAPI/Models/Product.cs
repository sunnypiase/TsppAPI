namespace TsppAPI.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Amount { get; set; }
        public double Weight { get; set; }
        public ICollection<ProductType>? Types { get; set; }

        public override bool Equals(object? obj)
        {
            Product? product = obj as Product;

            return product is not null &&
                   Id == product.Id &&
                   Name == product.Name &&
                   Price == product.Price &&
                   Amount == product.Amount &&
                   Weight == product.Weight &&
                   Types.Select(x => product.Types.Contains(x)).Distinct().First();
        }
    }

}
