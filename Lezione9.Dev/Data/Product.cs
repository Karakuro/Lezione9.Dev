using System.ComponentModel.DataAnnotations.Schema;

namespace Lezione9.Dev.Data
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<Allocation>? Allocations { get; set; }
    }
}
