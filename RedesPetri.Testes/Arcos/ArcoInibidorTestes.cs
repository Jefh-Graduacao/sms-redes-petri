using FluentAssertions;
using RedesPetri.Entidades;
using RedesPetri.Entidades.Arcos;
using Xunit;

namespace RedesPetri.Testes.Arcos
{
    public sealed class ArcoInibidorTestes
    {
        [Theory]
        [InlineData(10), InlineData(104), InlineData(1020)]
        public void Não_Deve_Consumir_Marcas_Do_Lugar(int qtdMarcasLugar)
        {
            var lugar = new Lugar(1, qtdMarcasLugar);
            var arco = new ArcoInibidor(
                lugar,
                0,
                new Transicao(1),
                DirecaoArco.EntradaTransição
            );

            arco.ConsumirMarcasDoLugar();

            lugar.Marcas.Should().Be(qtdMarcasLugar);
        }
    }
}
