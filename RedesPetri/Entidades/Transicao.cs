using System;
using System.Collections.Generic;
using System.Linq;
using RedesPetri.Entidades.Arcos;

namespace RedesPetri.Entidades
{
    public sealed class Transicao
    {
        private readonly Action<Transicao>? _callbackTransicaoExecutada;
        private readonly List<Arco> _arcosEntrada = new();
        private readonly List<Arco> _arcosSaida = new();

        public Transicao(int id, Action<Transicao>? callbackTransicaoExecutada = null)
        {
            Id = id;
            _callbackTransicaoExecutada = callbackTransicaoExecutada;
        }

        /// <summary>
        /// Identificador da transição
        /// </summary>
        public int Id { get; }
        
        /// <summary>
        /// Define se uma transição está habilitada ou não.
        /// Uma transição é habilitada quando contém arcos de entrada e todos eles têm suas condições atendidas.
        /// </summary>
        public bool EstáHabilitada => _arcosEntrada is { Count: > 0 } arcos && arcos.All(arco => arco.EstáHabilitado);
        
        /// <summary>
        /// Retornar todos os arcos (de entrada e saída) da transição
        /// </summary>
        public IReadOnlyCollection<Arco> TodosArcos => _arcosEntrada.Concat(_arcosSaida).ToArray();

        /// <summary>
        /// Cria um novo arco de entrada (de um lugar) para a transição
        /// </summary>
        /// <param name="lugar">Lugar de saída do arco</param>
        /// <param name="peso">Peso do arco</param>
        /// <param name="tipoArco">Define se o arco instanciado será Normal, Inibidor ou Reset</param>
        public void CriarArcoEntrada(Lugar lugar, int peso, TipoArco tipoArco) =>
            _arcosEntrada.Add(tipoArco switch
            {
                TipoArco.Normal => new ArcoNormal(lugar, peso, this, DirecaoArco.EntradaTransição),
                TipoArco.Inibidor => new ArcoInibidor(lugar, peso, this, DirecaoArco.EntradaTransição),
                TipoArco.Reset => new ArcoReset(lugar, peso, this, DirecaoArco.EntradaTransição),
                _ => throw new InvalidOperationException("Tipo de arco inválido")
            });

        /// <summary>
        /// Cria um arco de saída da transição (para um lugar)
        /// </summary>
        /// <param name="lugar">Lugar de chegada do arco</param>
        /// <param name="peso">Peso do arco</param>
        public void CriarArcoSaida(Lugar lugar, int peso) =>
            _arcosSaida.Add(new ArcoNormal(lugar, peso, this, DirecaoArco.SaídaTransição));

        /// <summary>
        /// Executa a transição.
        ///
        /// A execução da transição consome as marcas dos lugares de entrada (de acordo com a regra
        /// de cada tipo de arco e seu peso) e produz marcas nos lugares de saída.
        ///
        /// Ao final da execução é disparado o callback de transição executada (caso exista).
        /// </summary>
        public void ExecutarTransicao()
        {
            foreach (var (lugar, peso, _, _, tipoConexao) in _arcosEntrada)
            {
                if (tipoConexao == TipoArco.Reset)
                {
                    //reset consome todas marcas
                    lugar.ConsumirMarcas(lugar.Marcas);
                }
                else if (tipoConexao == TipoArco.Normal)
                {
                    //normal consome marcas igual ao peso
                    lugar.ConsumirMarcas(peso);
                }
            }

            foreach (var (lugar, peso, _, _, _) in _arcosSaida)
                lugar.ProduzirMarcas(peso);

            _callbackTransicaoExecutada?.Invoke(this);
        }
    }
}