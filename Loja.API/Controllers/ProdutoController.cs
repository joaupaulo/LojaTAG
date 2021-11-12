using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loja.API.Entidades;
using Loja.API.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loja.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepository;

        public ProdutoController(IProdutoRepositorio produtoRepository)
        {
            _produtoRepository = produtoRepository;

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Produto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProducts()
        {
            var products = await _produtoRepository.GetProduto();

            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        public async Task<ActionResult<Produto>> GetProductById(string id)
        {
            var product = await _produtoRepository.GetProdut(id);

            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produto>))]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProductByCategory(string category)
        {
            if (category is null)
            {
                return BadRequest("Invalid category");
            }

            var products = await _produtoRepository.GetProductByCategory(category);

            return Ok(products);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Produto>> CreateProduto([FromBody] Produto produto)
        {
            if (produto is null)
            {
                return BadRequest("Produto Invalido");
            }

            await _produtoRepository.CreateProduct(produto);

            return CreatedAtRoute("GetProduct", new { id = produto.Id }, produto);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Produto),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduto([FromBody] Produto produto)
        {
            if(produto is null)
            {
                return BadRequest("Produto invalido");
            }

            return Ok(await _produtoRepository.UpdateProduct(produto));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Produto),StatusCodes.Status200OK)]
        
        public async Task<IActionResult> DeleteProductId(string id)
        {
            return Ok(await _produtoRepository.DeleteProduct(id));
        }



    }
}
