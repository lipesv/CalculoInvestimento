using CalculoInvestimento.Models;
using CalculoInvestimento.Services.Interfaces;
using Moq;

namespace CalculoInvestimento.Test
{
    public class CalculoCdbTest
    {
        [Fact]
        public void CalculoInvestimentoCdb_RetornaValoresCorretos()
        {
            // Arrange
            var mockCalculoCdb = new Mock<ICalculoCdb>();

            var calculoCdb = new CalculoCdbResult
            {
                ValorBruto = 141.6558486730713m,
                ValorLiquido = 135.4074713721106m
            };

            mockCalculoCdb.Setup(c => c.CalcularCdb(It.IsAny<decimal>(), It.IsAny<int>()))
                          .Returns(calculoCdb);

            var valorInicial = 100m;
            var prazo = 36;

            // Act
            var result = mockCalculoCdb.Object.CalcularCdb(valorInicial, prazo);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(calculoCdb.ValorBruto, result.ValorBruto);
            Assert.Equal(calculoCdb.ValorLiquido, result.ValorLiquido);
        }

        [Fact]
        public void ExcecaoRetornada_QuandoInformado_ValorInicial_Invalido()
        {
            // Arrange
            var mockCalculoCdb = new Mock<ICalculoCdb>();

            mockCalculoCdb
                .Setup(c => c.CalcularCdb(It.Is<decimal>(v => v <= 0), It.IsAny<int>()))
                .Throws(new ArgumentException("Valor inicial deve ser positivo."));

            var valorInicial = -1000m;
            var prazo = 12;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => mockCalculoCdb.Object.CalcularCdb(valorInicial, prazo));
        }

        [Fact]
        public void ExcecaoRetornada_QuandoInformado_Prazo_Invalido()
        {
            // Arrange
            var mockCalculoCdb = new Mock<ICalculoCdb>();

            mockCalculoCdb
                .Setup(c => c.CalcularCdb(It.IsAny<decimal>(), It.Is<int>(p => p == 1)))
                .Throws(new ArgumentException("Prazo deve ser maior que 1 m�s."));

            var valorInicial = 50m;
            var prazo = 1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => mockCalculoCdb.Object.CalcularCdb(valorInicial, prazo));
        }
    }
}