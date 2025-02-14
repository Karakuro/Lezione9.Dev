namespace Lezione9.Dev.Dto
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Quantity { get; set; }
        
        public List<WarehouseDTO>? Warehouses { get; set; }
    }
}
