using System.Collections.Generic;
using System.Linq;

namespace RedesPetri.Entidades
{
    public class Rede
    {
        public List<Lugar> Lugares { get; set; } = new();
        public List<Transicao> Transicoes { get; set; } = new();

        public void CriarLugar(int id)
        {
            // Validar se já existe
            Lugares.Add(new Lugar(id));
        }

        public Lugar? ObterLugar(int id) => Lugares.FirstOrDefault(lugar => lugar.Id == id);

        public bool RemoverLugar(int id)
        {
            // Aqui preferi criar uma lista nova do que remover o lugar da atual...

            var novaLista = Lugares.Where(lugar => lugar.Id != id).ToList();
            bool teveExclusao = novaLista.Count == Lugares.Count;
            Lugares = novaLista;
            return teveExclusao;
        }

        public bool CriarTransicao(int id)
        {
            if (ObterTransicao(id) is { })
                return false;

            Transicoes.Add(new(id));
            return true;
        }

        public Transicao? ObterTransicao(int id) => Transicoes.FirstOrDefault(transicao => transicao.Id == id);

        public bool RemoverTransicao(int id)
        {
            // Generalizar junto com o outro Remover
            var novaLista = Transicoes.Where(transicao => transicao.Id != id).ToList();
            bool teveExclusao = novaLista.Count == Transicoes.Count;
            Transicoes = novaLista;
            return teveExclusao;
        }

        public void CriarConexao(Lugar lugar, (Transicao transicao, int peso) conexao)
        {
            var (transicao, peso) = conexao;
            transicao.CriarConexaoEntrada(lugar, peso);
        }

        public void CriarConexao(Transicao transicao, (Lugar lugar, int peso) conexao)
        {
            var (lugar, peso) = conexao;
            transicao.CriarConexaoSaida(lugar, peso);
        }
    }
}