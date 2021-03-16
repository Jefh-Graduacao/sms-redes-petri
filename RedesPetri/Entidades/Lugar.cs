namespace RedesPetri.Entidades
{
    public record Lugar
    {
        public Lugar(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public int Marcas { get; private set; } = 0;

        public void ProduzirMarca() => Marcas += 1;
        public void ConsumirMarca() => Marcas += 1;
        public void LimparMarcas() => Marcas = 0;
    }
}