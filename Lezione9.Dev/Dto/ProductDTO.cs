namespace Lezione9.Dev.Dto
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int WarehouseId { get; set; }
        public string? WarehouseTitle { get; set; }
    }
}
