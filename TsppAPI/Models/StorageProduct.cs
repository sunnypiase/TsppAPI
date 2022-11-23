namespace TsppAPI.Models
{
    public class StorageProduct : IEntity
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Storage Storage { get; set; }
    }
}
