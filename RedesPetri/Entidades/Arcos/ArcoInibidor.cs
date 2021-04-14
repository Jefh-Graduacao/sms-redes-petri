namespace RedesPetri.Entidades.Arcos
{
    public sealed record ArcoInibidor(Lugar Lugar, int Peso, Transicao Transicao, DirecaoArco Direcao) : Arco(Lugar, Peso, Transicao, Direcao, TipoArco.Inibidor)
    {
        /// <summary>
        /// Tipo inibidor habilita se estiver com menos marcas que peso do arco
        /// </summary>
        public override bool EstáHabilitado => base.EstáHabilitado && Peso > Lugar.Marcas;
    }
}
