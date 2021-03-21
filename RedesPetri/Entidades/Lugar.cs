namespace RedesPetri.Entidades
{
    public record Lugar
    {
        public Lugar(int id, int marcas)
        {
            Id = id;
            Marcas = marcas;
        }

        public int Id { get; }
        public int Marcas { get; private set; } = 0;

        public void ConsumirMarcas(int quantidade) => Marcas -= quantidade;
        public void ProduzirMarcas(int quantidade) => Marcas += quantidade;

        public void LimparMarcas() => Marcas = 0;
    }
}