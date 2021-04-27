using RedesPetri.Entidades;
using RedesPetri.Entidades.Arcos;
using System.Collections.Generic;

namespace RedesPetri.WinForms
{
    public static class ExemplosProntos
    {
        public static Dictionary<string, RedePetri> Redes => new()
        {
            ["Padrão Básico"] = Padrao(),
            ["Enunciado"] = ExemploEnunciado(),
            ["Resolução Concorrência"] = ResolucaoConcorrencia(),
            ["Arco Inibidor"] = ArcoInibidor(),
            ["Arco Reset"] = ArcoReset(),
            ["Rede Referência TA"] = ExemploProfessor()
        };
        
        public static RedePetri ExemploProfessor()
        {
            var rede = new RedePetri();
            rede.CriarLugar(1);
            rede.CriarLugar(2,2);
            rede.CriarLugar(3,1);
            rede.CriarLugar(4);
            rede.CriarLugar(5);
            rede.CriarLugar(6);
            rede.CriarLugar(7, 10);
            rede.CriarLugar(8);
            rede.CriarLugar(9);
            rede.CriarLugar(10);
            rede.CriarLugar(11);
            rede.CriarLugar(12);
            rede.CriarLugar(13);

            rede.CriarTransicao(1);
            rede.CriarTransicao(2);
            rede.CriarTransicao(3);
            rede.CriarTransicao(4);
            rede.CriarTransicao(5);
            rede.CriarTransicao(6);
            rede.CriarTransicao(7);

            //relacionados com lugar 1 
            rede.CriarArco(rede.ObterLugar(1)!, (rede.ObterTransicao(1), 2), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(2)!, (rede.ObterLugar(1), 1));

            //relacionados com lugar 2
            rede.CriarArco(rede.ObterLugar(2)!, (rede.ObterTransicao(2), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(6)!, (rede.ObterLugar(2), 1));

            //relacionados com lugar 3
            rede.CriarArco(rede.ObterLugar(3)!, (rede.ObterTransicao(3), 1), TipoArco.Normal);

            //relacionados com lugar 4
            rede.CriarArco(rede.ObterLugar(4)!, (rede.ObterTransicao(4), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(1)!, (rede.ObterLugar(4), 1));
            
            //relacionados com lugar 5
            rede.CriarArco(rede.ObterLugar(5)!, (rede.ObterTransicao(5), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(2)!, (rede.ObterLugar(5), 1));

            //relacionados com lugar 6
            rede.CriarArco(rede.ObterLugar(6)!, (rede.ObterTransicao(5), 2), TipoArco.Inibidor);
            rede.CriarArco(rede.ObterTransicao(3)!, (rede.ObterLugar(6), 1));
            rede.CriarArco(rede.ObterTransicao(6)!, (rede.ObterLugar(6), 1));

            //relacionados com lugar 7
            rede.CriarArco(rede.ObterLugar(7)!, (rede.ObterTransicao(4), 1), TipoArco.Reset);

            //relacionados com lugar 8 
            rede.CriarArco(rede.ObterLugar(8)!, (rede.ObterTransicao(4), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(8)!, (rede.ObterTransicao(7), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(5)!, (rede.ObterLugar(8), 1));

            //relacionados com lugar 9
            rede.CriarArco(rede.ObterLugar(9)!, (rede.ObterTransicao(7), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(5)!, (rede.ObterLugar(9), 1));

            //relacionados com lugar 10
            rede.CriarArco(rede.ObterLugar(10)!, (rede.ObterTransicao(6), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(5)!, (rede.ObterLugar(10), 1));

            //relacionados com lugar 11
            rede.CriarArco(rede.ObterLugar(11)!, (rede.ObterTransicao(7), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(4)!, (rede.ObterLugar(11), 1));

            //relacionados com lugar 12
            rede.CriarArco(rede.ObterTransicao(7)!, (rede.ObterLugar(12), 1));

            //relacionados com lugar 13
            rede.CriarArco(rede.ObterLugar(13)!, (rede.ObterTransicao(6), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(7)!, (rede.ObterLugar(13), 1));

            return rede;
        }

        public static RedePetri ExemploEnunciado()
        {
            var rede = new RedePetri();
            rede.CriarLugar(1, 2);
            rede.CriarLugar(2);
            rede.CriarLugar(3, 2);
            rede.CriarLugar(4);
            rede.CriarLugar(5, 5);
            rede.CriarLugar(6);
            rede.CriarLugar(7);
            rede.CriarLugar(8);

            rede.CriarTransicao(1);
            rede.CriarTransicao(2);
            rede.CriarTransicao(3);
            rede.CriarTransicao(4);

            rede.CriarArco(rede.ObterLugar(1)!, (rede.ObterTransicao(1), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(2)!, (rede.ObterTransicao(2), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(3)!, (rede.ObterTransicao(2), 2), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(5)!, (rede.ObterTransicao(2), 3), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(4)!, (rede.ObterTransicao(3), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(6)!, (rede.ObterTransicao(4), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(7)!, (rede.ObterTransicao(4), 1), TipoArco.Normal);

            rede.CriarArco(rede.ObterTransicao(1)!, (rede.ObterLugar(2), 1));
            rede.CriarArco(rede.ObterTransicao(2)!, (rede.ObterLugar(4), 1));
            rede.CriarArco(rede.ObterTransicao(3)!, (rede.ObterLugar(3), 2));
            rede.CriarArco(rede.ObterTransicao(3)!, (rede.ObterLugar(7), 1));
            rede.CriarArco(rede.ObterTransicao(3)!, (rede.ObterLugar(6), 1));
            rede.CriarArco(rede.ObterTransicao(4)!, (rede.ObterLugar(8), 1));
            rede.CriarArco(rede.ObterTransicao(4)!, (rede.ObterLugar(5), 3));

            return rede;
        }

        public static RedePetri Padrao()
        {
            var rede = new RedePetri();
            rede.CriarLugar(1, 2);
            rede.CriarLugar(2);
            rede.CriarLugar(3);

            rede.CriarTransicao(1);
            rede.CriarTransicao(2);

            rede.CriarArco(rede.ObterLugar(1)!, (rede.ObterTransicao(1), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(1)!, (rede.ObterLugar(2), 1));

            rede.CriarArco(rede.ObterLugar(2)!, (rede.ObterTransicao(2), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(2)!, (rede.ObterLugar(3), 1));
            return rede;
        }

        public static RedePetri ResolucaoConcorrencia()
        {
            var rede = new RedePetri();
            rede.CriarLugar(1, 1);
            rede.CriarLugar(2);
            rede.CriarLugar(3);

            rede.CriarTransicao(1);
            rede.CriarTransicao(2);

            rede.CriarArco(rede.ObterLugar(1)!, (rede.ObterTransicao(1), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(1)!, (rede.ObterTransicao(2), 1), TipoArco.Normal);

            rede.CriarArco(rede.ObterTransicao(1)!, (rede.ObterLugar(2), 1));
            rede.CriarArco(rede.ObterTransicao(2)!, (rede.ObterLugar(3), 1));
            return rede;
        }

        public static RedePetri ArcoInibidor()
        {
            var rede = new RedePetri();
            rede.CriarLugar(1, 1);
            rede.CriarLugar(2, 1);
            rede.CriarLugar(3);

            rede.CriarTransicao(1);

            rede.CriarArco(rede.ObterLugar(1)!, (rede.ObterTransicao(1), 1), TipoArco.Inibidor);
            rede.CriarArco(rede.ObterLugar(2)!, (rede.ObterTransicao(1), 1), TipoArco.Normal);

            rede.CriarArco(rede.ObterTransicao(1)!, (rede.ObterLugar(3), 1));
            return rede;
        }

        public static RedePetri ArcoReset()
        {
            var rede = new RedePetri();
            rede.CriarLugar(1, 11);
            rede.CriarLugar(2, 1);
            rede.CriarLugar(3);

            rede.CriarTransicao(1);

            rede.CriarArco(rede.ObterLugar(1)!, (rede.ObterTransicao(1), 1), TipoArco.Reset);
            rede.CriarArco(rede.ObterLugar(2)!, (rede.ObterTransicao(1), 1), TipoArco.Normal);

            rede.CriarArco(rede.ObterTransicao(1)!, (rede.ObterLugar(3), 1));
            return rede;
        }
    }
}
