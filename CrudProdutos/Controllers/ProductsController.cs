using CrudProdutos.Data;
using CrudProdutos.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProductsController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _repo.GetAllProducts();

            return Ok(product);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _repo.GetProductById(id);

            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product model)
        {
            _repo.Add(model);
            if (_repo.SaveChanges())
            {
                return Ok(model);
            }

            return BadRequest("Produto não encontrado");
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product model)
        {
            var product = _repo.GetProductById(id);
            if (product == null) return BadRequest("Produto não encontrado");

            _repo.Update(model);
            if (_repo.SaveChanges())
            {
                return Ok(model);
            }
            return BadRequest("Produto não atualizado");
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _repo.GetProductById(id);
            if (product == null) return BadRequest("Produto não encontrado");

            _repo.Delete(product);
            if (_repo.SaveChanges())
            {
                return Ok("Excluido com sucesso");
            }
            return BadRequest("Produto não excluido");
        }
    }
}
