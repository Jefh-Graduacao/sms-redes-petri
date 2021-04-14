namespace RedesPetri.Entidades.Arcos
{
    public abstract record Arco(Lugar Lugar, int Peso, Transicao Transicao, DirecaoArco Direcao, TipoArco Tipo)
    {
        public virtual bool EstáHabilitado => Direcao is DirecaoArco.EntradaTransição;
    }
}
