using controleFinanceiro.Dtos;
using controleFinanceiro.Services;
using Microsoft.AspNetCore.Mvc;

namespace controleFinanceiro.Controllers
{
    [Route("contas")]
    [ApiController]
    public class ContaController(ContaService service) : ControllerBase
    {
        // GET: /contas - Lista todas as contas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.FindAll());
        }

        // GET: /contas/{id} - Busca uma conta por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var conta = await service.FindById(id);

            return conta is null
                ? NotFound(new { Mensagem = $"Conta {id} não encontrada" })
                : Ok(conta);
        }

        // POST: /contas - Cadastra uma nova conta
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContaDto data)
        {
            var conta = await service.Create(data);

            return CreatedAtAction(nameof(GetById), new { id = conta.Id }, conta);
        }

        // PUT: /contas/{id} - Atualiza uma conta existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ContaDto data)
        {
            var updated = await service.Update(id, data);

            return updated
                ? NoContent()
                : NotFound(new { Mensagem = $"Conta {id} não encontrada" });
        }

        // DELETE: /contas/{id} - Remove uma conta
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.Delete(id);

            return deleted
                ? NoContent()
                : NotFound(new { Mensagem = $"Conta {id} não encontrada" });
        }

        // GET: /contas/{id}/movimentacoes - Lista as movimentações de uma conta
        [HttpGet("{id}/movimentacoes")]
        public async Task<IActionResult> GetMovimentacoes(int id)
        {
            var movimentacoes = await service.FindMovimentacoes(id);

            return movimentacoes is null
                ? NotFound(new { Mensagem = $"Conta {id} não encontrada" })
                : Ok(movimentacoes);
        }
    }
}