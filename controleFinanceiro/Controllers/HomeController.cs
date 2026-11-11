using Microsoft.AspNetCore.Mvc;

namespace controleFinanceiro.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: / - Serve para conferir se a API está no ar
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { status = "up", api = "controleFinanceiro" });
        }
    }
}