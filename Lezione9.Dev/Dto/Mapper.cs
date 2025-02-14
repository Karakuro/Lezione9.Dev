using Lezione9.Dev.Data;

namespace Lezione9.Dev.Dto
{
    public class Mapper
    {
        public ProductDTO MapEntityToDTO(Product entity)
        {
            return new ProductDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Quantity = entity.Allocations?.Sum(a => a.Quantity) ?? 0,
                Warehouses = entity.Allocations?.ConvertAll(MapAllocationToWarehouseDTO)
            };
        }

        public Product MapDTOToEntity(ProductDTO dto)
        {
            return new Product
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public Warehouse MapDTOToEntity(WarehouseDTO dto)
        {
            return new Warehouse
            {
                Id = dto.Id,
                Title = dto.Title
            };
        }

        public WarehouseDTO MapEntityToDTO(Warehouse entity)
        {
            return new WarehouseDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Products = entity.Allocations?.ConvertAll(MapAllocationToProductDTO)
            };
        }

        public ProductDTO MapAllocationToProductDTO(Allocation entity)
        {
            return new ProductDTO() {
                Id = entity.ProductId,
                Name = entity.Product?.Name ?? "Not provided",
                Quantity = entity.Quantity
            };
        }

        public WarehouseDTO MapAllocationToWarehouseDTO(Allocation entity)
        {
            return new WarehouseDTO()
            {
                Id = entity.WarehouseId,
                Title = entity.Warehouse?.Title ?? "Not provided",
                Quantity = entity.Quantity
            };
        }
    }
}
