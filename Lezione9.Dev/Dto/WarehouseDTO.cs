namespace Lezione9.Dev.Dto
{
    public class WarehouseDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public List<ProductDTO>? Products { get; set; }
    }
}
