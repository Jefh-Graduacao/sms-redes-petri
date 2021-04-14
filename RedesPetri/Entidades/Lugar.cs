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
        /// Quantidade de marcas disponíveis
        /// </summary>
        public int Marcas { get; private set; }

        /// <summary>
        /// Consome marcas do lugar. Após consumir as marcas o callback de marcas consumidas é disparado.
        /// </summary>
        /// <param name="quantidade">Quantidade de marcas a serem consumidas</param>
        public void ConsumirMarcas(int quantidade)
        {
            if (quantidade > Marcas)
                throw new InvalidOperationException($"Não é possível consumir {quantidade} marcas porque lugar contém apenas {Marcas}");

            Marcas -= quantidade;
            _actionMarcaConsumida?.Invoke(this);
        }

        /// <summary>
        /// Produz marcas no lugar. Após produzir as marcas o callback de marcas produzidas é disparado.
        /// </summary>
        /// <param name="quantidade">Quantidade de marcas para produzir</param>
        public void ProduzirMarcas(int quantidade)
        {
            Marcas += quantidade;
            _actionMarcaProduzida?.Invoke(this);
        }
    }
}