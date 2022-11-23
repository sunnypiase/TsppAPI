namespace TsppAPI.Models
{
    public class SoldProduct : IEntity
    {
        public int Id { get; set; }
        public DateTime SoldDate { get; set; }
        public Product Product { get; set; }

    }
}
