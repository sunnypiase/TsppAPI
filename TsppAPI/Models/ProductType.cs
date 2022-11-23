namespace TsppAPI.Models
{
    public class ProductType : IEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ProductType product &&
                   Id == product.Id &&
                   TypeName == product.TypeName && (
                   Products == null ||
                   Products.Select(x => product.Products.Contains(x)).Distinct().First());
        }
    }
}
