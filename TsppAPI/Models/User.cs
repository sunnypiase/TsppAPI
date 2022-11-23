namespace TsppAPI.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public ICollection<Storage>? Storages { get; set; }
    }
}
