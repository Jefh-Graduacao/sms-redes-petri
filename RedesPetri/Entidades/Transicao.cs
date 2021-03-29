using System;
using System.Collections.Generic;
using System.Linq;

namespace RedesPetri.Entidades
{
    public class Transicao
    {
        private readonly Action<Transicao>? _callbackTransicaoDisparada = null;
        private readonly List<Arco> _conexoesEntrada = new();
        private readonly List<Arco> _conexoesSaida = new();

        public Transicao(int id, Action<Transicao>? callbackTransicaoDisparada = null)
        {
            Id = id;
            _callbackTransicaoDisparada = callbackTransicaoDisparada;
        }

        public int Id { get; }

        public bool EstáHabilitada
        {
            get
            {
                bool habilitada = false;

                List<bool> _listaResults = new();

                foreach (var con in _conexoesEntrada)
                {
                    if (con.Peso <= con.Lugar.Marcas && con.Tipo == TipoArco.Normal)
                    {
                        // tipo normal habilita se estiver com marcas maiores ou igual ao peso do arco
                        _listaResults.Add(true);
                    }
                    else if (con.Lugar.Marcas < con.Peso && con.Tipo == TipoArco.Inibidor)
                    {
                        // tipo inibidor habilita se estiver com menos marcas que peso do arco
                        _listaResults.Add(true);
                    }
                    else if (con.Tipo == TipoArco.Reset)
                    {
                        // tipo reset habilita mesmo sem marcas
                        _listaResults.Add(true);
                    }
                    else
                    {
                        // senao for nenhum caso acima desabilita
                        _listaResults.Add(false);
                    }
                }

                // se todos arcos de entrada tem condiçoes validadas a transição é habilitada
                // && tem que ter arcos pois se não tiver não pode habilitar
                habilitada = _listaResults.All(con => con.Equals(true)) && (_conexoesEntrada.ToArray().Length > 0);

                return habilitada;
            }
        }

        public IReadOnlyCollection<Arco> ConexoesEntrada => _conexoesEntrada.AsReadOnly();
        public IReadOnlyCollection<Arco> ConexoesSaida => _conexoesSaida.AsReadOnly();
        public IReadOnlyCollection<Arco> TodasConexoes => _conexoesEntrada.Concat(_conexoesSaida).ToArray();

        public void CriarArcoEntrada(Lugar lugar, int peso, TipoArco tipoConexao) =>
            _conexoesEntrada.Add(new(lugar, peso, this, DirecaoArco.EntradaTransicao, tipoConexao));

        public void CriarArcoSaida(Lugar lugar, int peso) =>
            _conexoesSaida.Add(new(lugar, peso, this, DirecaoArco.SaidaTransicao, TipoArco.Normal));

        public void ConsumirMarcas()
        {
            foreach (var (lugar, peso, _, _, tipoConexao) in _conexoesEntrada)
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

            foreach (var (lugar, peso, _, _, _) in _conexoesSaida)
                lugar.ProduzirMarcas(peso);

            _callbackTransicaoDisparada?.Invoke(this);
        }
    }
}