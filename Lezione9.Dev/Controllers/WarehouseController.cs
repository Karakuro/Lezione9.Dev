using Lezione9.Dev.Data;
using Lezione9.Dev.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Lezione9.Dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseDbContext _ctx;
        private readonly Mapper _mapper;

        public WarehouseController(WarehouseDbContext ctx, Mapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _ctx.Warehouses.ToList().ConvertAll(_mapper.MapEntityToDTO);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSingle(int id)
        {
            var result = _ctx.Warehouses.Find(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.MapEntityToDTO(result));
        }

        [HttpGet]
        [Route("{id}/Products")]
        public IActionResult GetWithProducts(int id)
        {
            var result = _ctx.Warehouses.Include(w => w.Products).SingleOrDefault(w => w.Id == id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.MapEntityToDTO(result));
        }

        [HttpPost]
        public IActionResult Create(WarehouseDTO dto)
        {
            try
            {
                var entity = _mapper.MapDTOToEntity(dto);
                entity.Id = 0;
                _ctx.Warehouses.Add(entity);
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
        public IActionResult Update(WarehouseDTO warehouse)
        {
            try
            {
                var entity = _ctx.Warehouses.Find(warehouse.Id);
                if (entity == null)
                {
                    return BadRequest();
                }
                entity.Title = warehouse.Title;
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
                var entity = _ctx.Warehouses.Find(id);
                if (entity == null)
                {
                    return BadRequest();
                }
                _ctx.Warehouses.Remove(entity);

                //Inutilmente più complicato per ottenere lo stesso risultato ed Esotico, mi dicono
                //_ctx.Warehouses.RemoveRange(_ctx.Warehouses.Where(w => w.Id == id));
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
