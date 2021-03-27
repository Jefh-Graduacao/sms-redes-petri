using System.Collections.Generic;
using System.Linq;

namespace RedesPetri.Entidades
{
    public record Transicao
    {
        private readonly List<Conexao> _conexoesEntrada = new();
        private readonly List<Conexao> _conexoesSaida = new();

        public Transicao(int id) => Id = id;

        public int Id { get; }
        public bool Ativa { get; private set; } = true;

        public bool EstáHabilitada
        {
            get
            {
                bool habilitada = false;

                List<bool> _listaResults = new();

                foreach (var con in _conexoesEntrada){
                    if(con.Peso <= con.Lugar.Marcas && con.tipoConexao == TipoConexao.Normal){
                        // tipo normal habilita se estiver com marcas maiores ou igual ao peso do arco
                        _listaResults.Add(true);
                    } else if(con.Lugar.Marcas < con.Peso  && con.tipoConexao == TipoConexao.Inibidor){
                        // tipo inibidor habilita se estiver com menos marcas que peso do arco
                        _listaResults.Add(true);
                    } else if(con.tipoConexao == TipoConexao.Reset){
                        // tipo reset habilita mesmo sem marcas
                        _listaResults.Add(true);
                    } else {
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

        public IReadOnlyCollection<Conexao> ConexoesEntrada => _conexoesEntrada.AsReadOnly();
        public IReadOnlyCollection<Conexao> ConexoesSaida => _conexoesSaida.AsReadOnly();
        public IReadOnlyCollection<Conexao> TodasConexoes => _conexoesEntrada.Concat(_conexoesSaida).ToArray();

        public void CriarConexaoEntrada(Lugar lugar, int peso, TipoConexao tipoConexao) => 
            _conexoesEntrada.Add(new(lugar, peso, this, DirecaoConexao.EntradaTransicao, tipoConexao));

        public void CriarConexaoSaida(Lugar lugar, int peso) => 
            _conexoesSaida.Add(new(lugar, peso, this, DirecaoConexao.SaidaTransicao, TipoConexao.Normal));

        public void Ativar() => Ativa = true;
        public void Inativar() => Ativa = false;

        public void ConsumirMarcas()
        {
            foreach (var (lugar, peso, _, _,tipoConexao) in _conexoesEntrada){
                if(tipoConexao==TipoConexao.Reset){
                    //reset consome todas marcas
                    lugar.ConsumirMarcas(lugar.Marcas);
                } else if (tipoConexao==TipoConexao.Normal){
                    //normal consome marcas igual ao peso
                    lugar.ConsumirMarcas(peso);
                }
            }
            foreach (var (lugar, peso, _, _,_) in _conexoesSaida)
                lugar.ProduzirMarcas(peso);
        }
    }
}