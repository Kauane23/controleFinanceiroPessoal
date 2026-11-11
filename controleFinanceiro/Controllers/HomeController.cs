using Microsoft.AspNetCore.Mvc;

namespace controleFinanceiro.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(new
            {
                status = "up",
                api = "controleFinanceiro"
            });
        }

        [HttpGet("down")]
        public IActionResult Get2()
        {
            return Ok(new
            {
                status = "down",
                api = "controleFinanceiro"
            });
        }
    }
}
