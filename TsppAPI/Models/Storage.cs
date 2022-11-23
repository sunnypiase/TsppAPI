namespace TsppAPI.Models
{
    public class Storage : IEntity
    {
        public int Id { get; set; }
        public string Adress { get; set; } = string.Empty;
        public ICollection<StorageProduct>? StorageProducts { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}
