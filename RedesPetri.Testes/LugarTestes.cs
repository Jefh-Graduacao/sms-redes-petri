using System;
using FluentAssertions;
using Moq;
using RedesPetri.Entidades;
using Xunit;

namespace RedesPetri.Testes
{
    public sealed class LugarTestes
    {
        [Theory]
        [InlineData(10, 1, 9), InlineData(100, 11, 89), InlineData(80, 23, 57)]
        public void Deve_Descontar_Marcas_Consumidas(int qtdMarcasLugar, int qtdMarcasConsumidas, int qtdMarcasFinal)
        {
            var lugar = new Lugar(1, qtdMarcasLugar);
            lugar.ConsumirMarcas(qtdMarcasConsumidas);

            lugar.Marcas.Should().Be(qtdMarcasFinal);
        }

        [Theory]
        [InlineData(10, 1, 11), InlineData(100, 11, 111), InlineData(80, 23, 103)]
        public void Deve_Acrescentar_Marcas_Produzidas(int qtdMarcasLugar, int qtdMarcasProduzidas, int qtdMarcasFinal)
        {
            var lugar = new Lugar(1, qtdMarcasLugar);
            lugar.ProduzirMarcas(qtdMarcasProduzidas);

            lugar.Marcas.Should().Be(qtdMarcasFinal);
        }

        [Fact]
        public void Deve_Disparar_Callback_Ao_Consumir_Marcas()
        {
            var mockCallback = new Mock<Action<Lugar>>();

            var lugar = new Lugar(1, 1, callbackMarcaConsumida: mockCallback.Object);
            lugar.ConsumirMarcas(1);

            mockCallback.Verify(x => x.Invoke(lugar));
        }

        [Fact]
        public void Deve_Disparar_Callback_Ao_Produzir_Marcas()
        {
            var mockCallback = new Mock<Action<Lugar>>();

            var lugar = new Lugar(1, 1, callbackMarcaProduzida: mockCallback.Object);
            lugar.ProduzirMarcas(1);

            mockCallback.Verify(x => x.Invoke(lugar));
        }

        [Fact]
        public void Deve_Disparar_Exceção_Ao_Tentar_Consumir_Mais_Marcas_Que_O_Disponível()
        {
            var lugar = new Lugar(1, 1);
            Action acaoConsumir = () => lugar.ConsumirMarcas(10);
            acaoConsumir.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Deve_Zerar_Marcas_Ao_Consumir_Todas()
        {
            var lugar = new Lugar(1, 10);
            lugar.ConsumirTodasMarcas();

            lugar.Marcas.Should().Be(0);
        }
    }
}
