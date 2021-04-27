using FluentAssertions;
using RedesPetri.Entidades;
using RedesPetri.Entidades.Arcos;
using Xunit;

namespace RedesPetri.Testes.Arcos
{
    public sealed class ArcoResetTestes
    {
        [Theory]
        [InlineData(10), InlineData(104), InlineData(1020)]
        public void Deve_Consumir_Todas_Marcas_Do_Lugar(int qtdMarcasLugar)
        {
            var lugar = new Lugar(1, qtdMarcasLugar);
            var arco = new ArcoReset(
                lugar,
                100,
                new Transicao(1),
                DirecaoArco.EntradaTransição
            );

            arco.ConsumirMarcasDoLugar();

            lugar.Marcas.Should().Be(0);
        }
    }
}
