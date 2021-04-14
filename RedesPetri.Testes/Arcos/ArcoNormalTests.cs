using FluentAssertions;
using RedesPetri.Entidades;
using RedesPetri.Entidades.Arcos;
using Xunit;

namespace RedesPetri.Testes.Arcos
{
    public sealed class ArcoNormalTests
    {
        [Fact]
        public void Deve_Popular_Propriedades_Da_Base_Pelo_Construtor()
        {
            var lugar = new Lugar(1, 10);
            const int peso = 1;
            var transicao = new Transicao(1);
            const DirecaoArco direcao = DirecaoArco.EntradaTransição;

            new ArcoNormal(lugar, peso, transicao, direcao)
                .Should()
                .BeEquivalentTo(new
                {
                    Lugar = lugar,
                    Peso = peso, 
                    Transicao = transicao,
                    Direcao = direcao
                });
        }

        [Theory]
        [InlineData(10, 1), InlineData(12, 10)]
        [InlineData(1, 1), InlineData(2, 2)]
        public void Deve_Habilitar_Quando_Lugar_Tiver_Marcas_Suficientes_Para_Peso_Do_Arco(int qtdMarcasLugar, int pesoArco)
        {
            var arco = new ArcoNormal(
                new Lugar(1, qtdMarcasLugar), 
                pesoArco, 
                new Transicao(1), 
                DirecaoArco.EntradaTransição
            );

            arco.EstáHabilitado.Should().BeTrue();
        }

        [Fact]
        public void Não_Deve_Habilitar_Quando_Arco_For_De_Saída_De_Transição()
        {
            var arco = new ArcoNormal(
                new Lugar(1, 11),
                1,
                new Transicao(1),
                DirecaoArco.SaídaTransição
            );

            arco.EstáHabilitado.Should().BeFalse();
        }
    }
}
