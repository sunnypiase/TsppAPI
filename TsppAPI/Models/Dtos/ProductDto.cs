namespace TsppAPI.Models.Dtos
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public double Price { get; init; }
        public int Amount { get; init; }
        public double Weight { get; init; }
        public ICollection<int>? TypeIds { get; init; }

    }
}
