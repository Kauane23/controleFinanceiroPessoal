using controleFinanceiro.Dtos;
using controleFinanceiro.Services;
using Microsoft.AspNetCore.Mvc;

namespace controleFinanceiro.Controllers
{
    [Route("usuarios")]
    [ApiController]
    public class UsuarioController(UsuarioService service) : ControllerBase
    {
        // GET: /usuarios - Lista todos os usuários
        // IMPORTANTE: o Service não deve devolver a senha na resposta
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.FindAll());
        }

        // GET: /usuarios/{id} - Busca um usuário por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await service.FindById(id);

            return usuario is null
                ? NotFound(new { Mensagem = $"Usuário {id} não encontrado" })
                : Ok(usuario);
        }

        // POST: /usuarios - Cadastra um novo usuário
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDto data)
        {
            var usuario = await service.Create(data);

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        // PUT: /usuarios/{id} - Atualiza um usuário existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioDto data)
        {
            var updated = await service.Update(id, data);

            return updated
                ? NoContent()
                : NotFound(new { Mensagem = $"Usuário {id} não encontrado" });
        }

        // DELETE: /usuarios/{id} - Remove um usuário
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await service.Delete(id);

            return deleted
                ? NoContent()
                : NotFound(new { Mensagem = $"Usuário {id} não encontrado" });
        }

        // GET: /usuarios/{id}/contas - Lista as contas de um usuário
        [HttpGet("{id}/contas")]
        public async Task<IActionResult> GetContas(int id)
        {
            var contas = await service.FindContas(id);

            return contas is null
                ? NotFound(new { Mensagem = $"Usuário {id} não encontrado" })
                : Ok(contas);
        }
    }
}