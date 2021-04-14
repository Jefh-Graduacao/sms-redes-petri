using FluentAssertions;
using RedesPetri.Entidades;
using Xunit;

namespace RedesPetri.Testes
{
    public class TransicaoTestes
    {
        [Fact]
        public void Deve_Popular_Id_Pelo_Construtor()
        {
            const int id = 1;
            var transicao = new Transicao(id);

            transicao.Id.Should().Be(id);
        }

        [Theory]
        [InlineData(1, 1), InlineData(2, 1), InlineData(3, 2), InlineData(100, 10)]
        public void Deve_Habilitar_Transicao_Quando_Tiver_Arco_Normal_Com_Peso_Menor_Ou_Igual_Que_Marcas_Do_Lugar(int qtdMarcasLugar, int pesoArco)
        {
            var transicao = new Transicao(1);

            transicao.CriarArcoEntrada(new Lugar(1, qtdMarcasLugar), pesoArco, TipoArco.Normal);

            transicao.Est·Habilitada.Should().BeTrue();
        }

        [Fact]
        public void Deve_Habilitar_Transicao_Quando_Tiver_Arco_Inibidor_Com_Peso_Maior_Que_Marcas()
        {
            var transicao = new Transicao(1);

            transicao.CriarArcoEntrada(new Lugar(1, 2), 3, TipoArco.Inibidor);

            transicao.Est·Habilitada.Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 2), InlineData(1, 1), InlineData(2, 1)]
        public void Deve_Habilitar_Transicao_Com_Arco_Reset_Sempre(int qtdMarcasLugar, int pesoArco)
        {
            var transicao = new Transicao(1);

            transicao.CriarArcoEntrada(new Lugar(1, qtdMarcasLugar), pesoArco, TipoArco.Reset);

            transicao.Est·Habilitada.Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 2), InlineData(2, 3), InlineData(3, 10)]
        public void Nao_Deve_Habilitar_Transicao_Quando_Tiver_Arco_Normal_Com_Peso_Maior_Que_Marcas_Do_Lugar(int qtdMarcasLugar, int pesoArco)
        {
            var transicao = new Transicao(1);

            transicao.CriarArcoEntrada(new Lugar(1, qtdMarcasLugar), pesoArco, TipoArco.Normal);

            transicao.Est·Habilitada.Should().BeFalse();
        }

        [Theory]
        [InlineData(2, 2), InlineData(3, 2), InlineData(30, 10)]
        public void Nao_Deve_Habilitar_Transicao_Quando_Tiver_Arco_Inibidor_Com_Peso_Menor_Que_Marcas(int qtdMarcasLugar, int pesoArco)
        {
            var transicao = new Transicao(1);

            transicao.CriarArcoEntrada(new Lugar(1, qtdMarcasLugar), pesoArco, TipoArco.Inibidor);

            transicao.Est·Habilitada.Should().BeFalse();
        }
    }
}
