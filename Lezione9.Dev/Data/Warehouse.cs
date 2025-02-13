namespace Lezione9.Dev.Data
{
    public class Warehouse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public List<Product>? Products { get; set; }
    }
}
