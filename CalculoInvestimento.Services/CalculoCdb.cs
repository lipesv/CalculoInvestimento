using CalculoInvestimento.Models;
using CalculoInvestimento.Services.Interfaces;

namespace CalculoInvestimento.Services
{
    public class CalculoCdb : ICalculoCdb
    {
        private const decimal TB = 1.08m; // 108%
        private const decimal CDI = 0.009m; // 0.9%

        public CalculoCdbResult CalcularCdb(decimal valorInicial, int prazoMeses)
        {
            decimal valorFinal = valorInicial;

            for (int i = 0; i < prazoMeses; i++)
            {
                valorFinal *= (1 + (CDI * TB));
            }

            decimal valorBruto = valorFinal;
            decimal taxaImposto = ObterTaxaImposto(prazoMeses);
            decimal valorLiquido = valorBruto - (valorBruto - valorInicial) * taxaImposto;

            return new CalculoCdbResult
            {
                ValorBruto = valorBruto,
                ValorLiquido = valorLiquido
            };
        }

        private decimal ObterTaxaImposto(int prazoMeses)
        {
            switch (prazoMeses)
            {
                case <= 6:
                    return 0.225m;
                case <= 12:
                    return 0.20m;
                case <= 24:
                    return 0.175m;
                default:
                    return 0.15m;
            }
        }
    }
}
