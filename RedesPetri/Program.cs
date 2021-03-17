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

            rede.CriarConexao(rede.ObterLugar(1)!, (rede.ObterTransicao(1)!, 3));

            rede.ImprimirRepresentacaoTextual();
        }
    }
}
