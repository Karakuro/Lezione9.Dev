using System.ComponentModel.DataAnnotations.Schema;

namespace Lezione9.Dev.Data
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public Warehouse? Warehouse { get; set; }
    }
}
