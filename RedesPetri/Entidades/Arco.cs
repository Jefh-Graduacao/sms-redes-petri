namespace RedesPetri.Entidades
{
    public record Arco(Lugar Lugar, int Peso, Transicao Transicao, DirecaoArco Direcao, TipoArco Tipo);
}
