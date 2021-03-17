using System.Collections.Generic;
using System.Linq;

namespace RedesPetri.Entidades
{
    public record Transicao
    {
        private readonly List<Conexao> _conexoesEntrada = new();
        private readonly List<Conexao> _conexoesSaida = new();

        public Transicao(int id) => Id = id;

        public IReadOnlyCollection<Conexao> ConexoesEntrada => _conexoesEntrada.AsReadOnly();
        public IReadOnlyCollection<Conexao> ConexoesSaida => _conexoesSaida.AsReadOnly();
        public IReadOnlyCollection<Conexao> TodasConexoes => _conexoesEntrada.Concat(_conexoesSaida).ToArray();

        public void CriarConexaoEntrada(Lugar lugar, int peso) => _conexoesEntrada.Add(new(lugar, peso, this, DirecaoConexao.EntradaTransicao));
        public void CriarConexaoSaida(Lugar lugar, int peso) => _conexoesSaida.Add(new(lugar, peso, this, DirecaoConexao.SaidaTransicao));

        public int Id { get; }
        public bool Ativa { get; private set; } = true;

        // Todo: Implementar (com base em _conexoesEntrada)
        public bool EstáHabilitada => _conexoesEntrada.All(con => con.Peso <= con.Lugar.Marcas);

        public void Ativar() => Ativa = true;
        public void Inativar() => Ativa = false;
    }
}