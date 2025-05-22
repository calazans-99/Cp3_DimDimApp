using Microsoft.AspNetCore.Mvc;
using DimDimApp.Data;
using DimDimApp.Models;

namespace DimDimApp.Controllers
{
    [Route("api/locacoes")]
    [ApiController]
    public class LocacoesController(DimDimDbContext context) : ControllerBase
    {
        private readonly DimDimDbContext _context = context;

        [HttpPost("calcular")]
        public async Task<IActionResult> CalcularLocacao([FromBody] LocacaoRequest request)
        {
            var veiculo = await _context.Veiculos.FindAsync(request.VeiculoId);
            if (veiculo == null)
                return NotFound("Veículo não encontrado.");

            int dias = (request.DataFim - request.DataInicio).Days;
            double subtotal = dias * veiculo.ValorDiaria;
            double desconto = dias >= 7 ? 0.10 : dias >= 3 ? 0.05 : 0.0;
            double valorFinal = subtotal * (1 - desconto);

            var resultado = new
            {
                veiculo = veiculo.Modelo,
                marca = veiculo.Marca,
                dataInicio = request.DataInicio.ToString("yyyy-MM-dd"),
                dataFim = request.DataFim.ToString("yyyy-MM-dd"),
                valorDiaria = veiculo.ValorDiaria,
                subtotal,
                desconto = $"{desconto * 100}%",
                valorFinal
            };

            return Ok(resultado);
        }
    }
}
