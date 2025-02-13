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
                WarehouseId = entity.WarehouseId,
                WarehouseTitle = entity.Warehouse?.Title
            };
        }

        public Product MapDTOToEntity(ProductDTO dto)
        {
            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                WarehouseId = dto.WarehouseId
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
                Products = entity.Products?.ConvertAll(MapEntityToDTO)
            };
        }
    }
}
