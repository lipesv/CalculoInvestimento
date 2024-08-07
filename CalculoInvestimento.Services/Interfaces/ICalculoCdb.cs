using CalculoInvestimento.Models;

namespace CalculoInvestimento.Services.Interfaces
{
    public interface ICalculoCdb
    {
        CalculoCdbResult CalcularCdb(decimal valorInicial, int prazoMeses);
    }
}
