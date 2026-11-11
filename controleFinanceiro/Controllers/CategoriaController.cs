using controleFinanceiro.Dtos;
using controleFinanceiro.Services;
using Microsoft.AspNetCore.Mvc;

namespace controleFinanceiro.Controllers
{
    [Route("categorias")]
    [ApiController]
    public class CategoriaController(CategoriaService service) : ControllerBase
    {
        // GET: /categorias - Lista todas as categorias
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.FindAll());
        }

        // GET: /categorias/{id} - Busca uma categoria por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await service.FindById(id);

            return categoria is null
                ? NotFound(new { Mensagem = $"Categoria {id} não encontrada" })
                : Ok(categoria);
        }

        // POST: /categorias - Cadastra uma nova categoria
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaDto data)
        {
            var categoria = await service.Create(data);

            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        // PUT: /categorias/{id} - Atualiza uma categoria existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoriaDto data)
        {
            var updated = await service.Update(id, data);

            return updated
                ? NoContent()
                : NotFound(new { Mensagem = $"Categoria {id} não encontrada" });
        }

        // DELETE: /categorias/{id} - Remove uma categoria
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.Delete(id);

            return deleted
                ? NoContent()
                : NotFound(new { Mensagem = $"Categoria {id} não encontrada" });
        }
    }
}