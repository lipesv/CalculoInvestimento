using CalculoInvestimento.Models;
using CalculoInvestimento.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoInvestimento.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CdbController : ControllerBase
    {
        private readonly ICalculoCdb _calculoCdb;

        public CdbController(ICalculoCdb calculoCDB)
        {
            _calculoCdb = calculoCDB;
        }


        [HttpPost("calcular")]
        [ProducesResponseType<CalculoCdbResult>(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CalcularCdb(CalculoCdbRequest request)
        {
            if (request.ValorInicial <= 0 || request.PrazoMeses <= 1)
            {
                return BadRequest("Valor inicial deve ser positivo e o prazo deve ser maior que 1 mês.");
            }

            var result = _calculoCdb.CalcularCdb(request.ValorInicial, request.PrazoMeses);

            return Ok(result);

        }
    }
}
