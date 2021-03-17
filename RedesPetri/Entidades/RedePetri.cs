using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace RedesPetri.Entidades
{
    public class RedePetri
    {
        public List<Lugar> Lugares { get; set; } = new();
        public List<Transicao> Transicoes { get; set; } = new();

        public IReadOnlyCollection<(string id, string valor)> LugaresTransicoes
            => Lugares.Select(lugar => ($"L{lugar.Id}", lugar.Marcas.ToString()))
                .Concat(Transicoes.Select(tr => ($"T{tr.Id}", tr.EstáHabilitada ? "S" : "N")))
                .ToArray();

        public void CriarLugar(int id, int marcas = 0)
        {
            // Validar se já existe
            Lugares.Add(new Lugar(id, marcas));
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

        public void ImprimirRepresentacaoTextual()
        {
            Write("| ");
            foreach (var id in Lugares.Select(lugar => $"L{lugar.Id}").Concat(Transicoes.Select(transicao => $"T{transicao.Id}")))
                Write($"{id} |\t");

            WriteLine();
            Write("| ");

            foreach (var valor in Lugares.Select(lugar => lugar.Marcas.ToString()).Concat(Transicoes.Select(transicao => transicao.EstáHabilitada ? "S" : "N")))
                Write($"{valor}  |\t");
        }
    }
}