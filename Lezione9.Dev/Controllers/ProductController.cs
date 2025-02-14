using Lezione9.Dev.Data;
using Lezione9.Dev.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lezione9.Dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly WarehouseDbContext _ctx;
        private readonly Mapper _mapper;

        public ProductController(WarehouseDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Products.ToList().ConvertAll(_mapper.MapEntityToDTO);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingle(int id)
        {
            var result = _ctx.Products.SingleOrDefault(w => w.Id == id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.MapEntityToDTO(result));
        }

        [HttpPost]
        public IActionResult Create(ProductDTO dto)
        {
            try
            {
                var entity = _mapper.MapDTOToEntity(dto);
                entity.Id = 0;
                _ctx.Products.Add(entity);
                return _ctx.SaveChanges() == 1
                    ? Created("", _mapper.MapEntityToDTO(entity))
                    : BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(ProductDTO product)
        {
            try
            {
                var entity = _ctx.Products.Find(product.Id);
                if (entity == null)
                {
                    return BadRequest();
                }
                entity.Name = product.Name;
                return _ctx.SaveChanges() == 1
                    ? Ok(_mapper.MapEntityToDTO(entity))
                    : BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var entity = _ctx.Products.Find(id);
                if (entity == null)
                {
                    return BadRequest();
                }
                _ctx.Products.Remove(entity);

                //Inutilmente più complicato per ottenere lo stesso risultato ed Esotico, mi dicono
                //_ctx.Products.RemoveRange(_ctx.Products.Where(w => w.Id == id));
                return _ctx.SaveChanges() == 1
                    ? Ok()
                    : BadRequest();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
