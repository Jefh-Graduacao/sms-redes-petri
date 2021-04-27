namespace RedesPetri.Entidades.Arcos
{
    public abstract record Arco(Lugar Lugar, int Peso, Transicao Transicao, DirecaoArco Direcao)
    {
        public virtual bool EstáHabilitado => Direcao is DirecaoArco.EntradaTransição;

        public abstract void ConsumirMarcasDoLugar();
    }
}
