using System;

namespace RedesPetri.Entidades
{
    public sealed class Lugar
    {
        private readonly Action<Lugar>? _actionMarcaProduzida;
        private readonly Action<Lugar>? _actionMarcaConsumida;

        public Lugar(int id, int marcas, Action<Lugar>? callbackMarcaProduzida = null, Action<Lugar>? callbackMarcaConsumida = null)
        {
            Id = id;
            Marcas = marcas;

            _actionMarcaProduzida = callbackMarcaProduzida;
            _actionMarcaConsumida = callbackMarcaConsumida;
        }

        /// <summary>
        /// Identificador do lugar
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Quantidade de marcas dispon�veis
        /// </summary>
        public int Marcas { get; private set; }

        /// <summary>
        /// Consome marcas do lugar. Ap�s consumir as marcas o callback de marcas consumidas � disparado.
        /// </summary>
        /// <param name="quantidade">Quantidade de marcas a serem consumidas</param>
        public void ConsumirMarcas(int quantidade)
        {
            if (quantidade > Marcas)
                throw new InvalidOperationException($"N�o � poss�vel consumir {quantidade} marcas porque lugar cont�m apenas {Marcas}");

            Marcas -= quantidade;
            _actionMarcaConsumida?.Invoke(this);
        }

        /// <summary>
        /// Produz marcas no lugar. Ap�s produzir as marcas o callback de marcas produzidas � disparado.
        /// </summary>
        /// <param name="quantidade">Quantidade de marcas para produzir</param>
        public void ProduzirMarcas(int quantidade)
        {
            Marcas += quantidade;
            _actionMarcaProduzida?.Invoke(this);
        }
    }
}