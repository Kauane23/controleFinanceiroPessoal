using controleFinanceiro.Dtos;
using controleFinanceiro.Services;
using Microsoft.AspNetCore.Mvc;

namespace controleFinanceiro.Controllers
{
    [Route("movimentacoes")]
    [ApiController]
    public class MovimentacaoController(MovimentacaoService service) : ControllerBase
    {
        // GET: /movimentacoes - Lista todas as movimentações
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.FindAll());
        }

        // GET: /movimentacoes/{id} - Busca uma movimentação por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movimentacao = await service.FindById(id);

            return movimentacao is null
                ? NotFound(new { Mensagem = $"Movimentação {id} não encontrada" })
                : Ok(movimentacao);
        }

        // POST: /movimentacoes - Registra uma nova movimentação
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovimentacaoDto data)
        {
            var movimentacao = await service.Create(data);

            return CreatedAtAction(nameof(GetById), new { id = movimentacao.Id }, movimentacao);
        }

        // PUT: /movimentacoes/{id} - Atualiza uma movimentação existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MovimentacaoDto data)
        {
            var updated = await service.Update(id, data);

            return updated
                ? NoContent()
                : NotFound(new { Mensagem = $"Movimentação {id} não encontrada" });
        }

        // DELETE: /movimentacoes/{id} - Remove uma movimentação
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.Delete(id);

            return deleted
                ? NoContent()
                : NotFound(new { Mensagem = $"Movimentação {id} não encontrada" });
        }
    }
}