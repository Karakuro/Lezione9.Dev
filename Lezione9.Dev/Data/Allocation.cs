using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lezione9.Dev.Data
{
    [PrimaryKey("WarehouseId", "ProductId")]
    public class Allocation
    {
        public int WarehouseId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("WarehouseId")]
        public Warehouse? Warehouse { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
