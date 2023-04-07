namespace TsppAPI.Models.Filters
{
    public class ProductFilter : IFilter<Product>
    {
        public double price { get; set; }
    }
}
