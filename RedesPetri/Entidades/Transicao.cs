using System.Collections.Generic;

namespace RedesPetri.Entidades
{
    public record Transicao
    {
        private readonly List<(Lugar lugar, int peso)> _conexoesEntrada = new();
        private readonly List<(Lugar lugar, int peso)> _conexoesSaida = new();

        public Transicao(int id) => Id = id;

        public void CriarConexaoEntrada(Lugar lugar, int peso) => _conexoesEntrada.Add((lugar, peso));
        public void CriarConexaoSaida(Lugar lugar, int peso) => _conexoesSaida.Add((lugar, peso));

        public int Id { get; }
        public bool Ativa { get; private set; } = true;

        // Todo: Implementar (com base em _conexoesEntrada)
        public bool EstáHabilitada => true;

        public void Ativar() => Ativa = true;
        public void Inativar() => Ativa = false;
    }
}