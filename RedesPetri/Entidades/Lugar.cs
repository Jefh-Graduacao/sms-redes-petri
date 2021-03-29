using System;

namespace RedesPetri.Entidades
{
    public class Lugar
    {
        private readonly Action<Lugar>? _actionMarcaProduzida = null;
        private readonly Action<Lugar>? _actionMarcaConsumida = null;

        public Lugar(int id, int marcas, Action<Lugar>? callbackMarcaProduzida = null, Action<Lugar>? callbackMarcaConsumida = null)
        {
            Id = id;
            Marcas = marcas;

            _actionMarcaProduzida = callbackMarcaProduzida;
            _actionMarcaConsumida = callbackMarcaConsumida;
        }

        public int Id { get; }
        public int Marcas { get; private set; } = 0;

        public void ConsumirMarcas(int quantidade)
        {
            Marcas -= quantidade;
            _actionMarcaConsumida?.Invoke(this);
        }

        public void ProduzirMarcas(int quantidade)
        {
            Marcas += quantidade;
            _actionMarcaProduzida?.Invoke(this);
        }

        public void LimparMarcas() => Marcas = 0;
    }
}