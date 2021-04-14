using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace RedesPetri.Entidades
{
    public sealed class RedePetri
    {
        public int CicloAtual { get; private set; } = 0;
        public List<Lugar> Lugares { get; set; } = new();
        public List<Transicao> Transicoes { get; set; } = new();

        public IReadOnlyCollection<(string id, string valor)> LugaresTransicoes
            => Lugares.Select(lugar => ($"L{lugar.Id}", lugar.Marcas.ToString()))
                .Concat(Transicoes.Select(tr => ($"T{tr.Id}", tr.EstáHabilitada ? "S" : "N")))
                .ToArray();

        /// <summary>
        /// Cria lugar se não existe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="marcas"></param>
        /// <param name="callbackMarcaProduzida"></param>
        /// <param name="callbackMarcaConsumida"></param>
        /// <returns></returns>
        public bool CriarLugar(int id, int marcas = 0, Action<Lugar>? callbackMarcaProduzida = null, Action<Lugar>? callbackMarcaConsumida = null)
        {
            if (ObterLugar(id) is not null)
                return false;

            Lugares.Add(new Lugar(id, marcas, callbackMarcaProduzida, callbackMarcaConsumida));
            return true;
        }

        // Obtem um lugar da rede
        public Lugar? ObterLugar(int id) => Lugares.FirstOrDefault(lugar => lugar.Id == id);

        //Método para remover um lugar da rede
        public bool RemoverLugar(int id)
        {
            // Aqui preferi criar uma lista nova do que remover o lugar da atual...

            var novaLista = Lugares.Where(lugar => lugar.Id != id).ToList();
            bool teveExclusao = novaLista.Count == Lugares.Count;
            Lugares = novaLista;
            return teveExclusao;
        }

        // Cria Transição se ela nao existe
        public bool CriarTransicao(int id, Action<Transicao>? callbackTransicaoSaida = null)
        {
            if (ObterTransicao(id) is { })
                return false;

            Transicoes.Add(new(id, callbackTransicaoSaida));
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

        /// <summary>
        /// Criar um Arco de um <see cref="Lugar"/> para uma <see cref="Transicao" />
        /// </summary>
        /// <param name="lugar"></param>
        /// <param name="conexao"></param>
        /// <param name="tipoArco"></param>
        public void CriarArco(Lugar lugar, (Transicao transicao, int peso) conexao, TipoArco tipoArco)
        {
            var (transicao, peso) = conexao;
            transicao.CriarArcoEntrada(lugar, peso, tipoArco);
        }
                
        /// <summary>
        /// Criaum Arco de uma Transição para um Lugar
        /// </summary>
        /// <param name="transicao"></param>
        /// <param name="conexao"></param>
        public void CriarArco(Transicao transicao, (Lugar lugar, int peso) conexao)
        {
            var (lugar, peso) = conexao;
            transicao.CriarArcoSaida(lugar, peso);
        }

        /// <summary>
        /// Executa o ciclo atual da rede
        /// </summary>
        /// <returns><see cref="true"/> caso o ciclo tenha sido executado, <see cref="false"/> caso a execução tenha terminado</returns>
        public bool ExecutarCiclo()
        {
            // Todas tr habilitadas no início do ciclo
            var idsTransicoesHabilitadas = Transicoes.Where(tr => tr.EstáHabilitada).Select(tr => tr.Id).ToArray();

            if (idsTransicoesHabilitadas.Length == 0)
                return false;

            foreach (var transicao in Transicoes.ToArray())
            {
                // Se a id da transicao estiver em um dos ids habilitados
                if (idsTransicoesHabilitadas.Any(tr => tr == transicao.Id))
                {
                    // Consome marcas enquanto a transição estiver habilitada no ciclo                    
                    while (transicao.EstáHabilitada)
                    {
                        transicao.ExecutarTransicao();
                    }
                }
            }

            CicloAtual += 1;
            return true;
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