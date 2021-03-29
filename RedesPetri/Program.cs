using RedesPetri.Entidades;

namespace RedesPetri
{
    class Program
    {
        static void Main(string[] args)
        {
            var rede = new RedePetri();

            rede.CriarLugar(1);
            rede.CriarLugar(2);

            rede.CriarTransicao(1);
            rede.CriarTransicao(2);

            rede.CriarArco(rede.ObterLugar(1)!,  (rede.ObterTransicao(1)!, 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(1)!, (rede.ObterLugar(2)!,1));

            rede.ImprimirRepresentacaoTextual();
        }
    }
}
