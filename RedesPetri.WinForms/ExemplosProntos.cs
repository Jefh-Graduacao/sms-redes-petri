using RedesPetri.Entidades;
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
            ["Arco Reset"] = ArcoReset()
        };

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

            rede.CriarArco(rede.ObterLugar(1), (rede.ObterTransicao(1), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(2), (rede.ObterTransicao(2), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(3), (rede.ObterTransicao(2), 2), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(5), (rede.ObterTransicao(2), 3), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(4), (rede.ObterTransicao(3), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(6), (rede.ObterTransicao(4), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(7), (rede.ObterTransicao(4), 1), TipoArco.Normal);

            rede.CriarArco(rede.ObterTransicao(1), (rede.ObterLugar(2), 1));
            rede.CriarArco(rede.ObterTransicao(2), (rede.ObterLugar(4), 1));
            rede.CriarArco(rede.ObterTransicao(3), (rede.ObterLugar(3), 2));
            rede.CriarArco(rede.ObterTransicao(3), (rede.ObterLugar(7), 1));
            rede.CriarArco(rede.ObterTransicao(3), (rede.ObterLugar(6), 1));
            rede.CriarArco(rede.ObterTransicao(4), (rede.ObterLugar(8), 1));
            rede.CriarArco(rede.ObterTransicao(4), (rede.ObterLugar(5), 3));

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

            rede.CriarArco(rede.ObterLugar(1), (rede.ObterTransicao(1), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(1), (rede.ObterLugar(2), 1));

            rede.CriarArco(rede.ObterLugar(2), (rede.ObterTransicao(2), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterTransicao(2), (rede.ObterLugar(3), 1));
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

            rede.CriarArco(rede.ObterLugar(1), (rede.ObterTransicao(1), 1), TipoArco.Normal);
            rede.CriarArco(rede.ObterLugar(1), (rede.ObterTransicao(2), 1), TipoArco.Normal);

            rede.CriarArco(rede.ObterTransicao(1), (rede.ObterLugar(2), 1));
            rede.CriarArco(rede.ObterTransicao(2), (rede.ObterLugar(3), 1));
            return rede;
        }

        public static RedePetri ArcoInibidor()
        {
            var _rede = new RedePetri();
            _rede.CriarLugar(1, 1);
            _rede.CriarLugar(2, 1);
            _rede.CriarLugar(3);

            _rede.CriarTransicao(1);

            _rede.CriarArco(_rede.ObterLugar(1), (_rede.ObterTransicao(1), 1), TipoArco.Inibidor);
            _rede.CriarArco(_rede.ObterLugar(2), (_rede.ObterTransicao(1), 1), TipoArco.Normal);

            _rede.CriarArco(_rede.ObterTransicao(1), (_rede.ObterLugar(2), 1));
            return _rede;
        }

        public static RedePetri ArcoReset()
        {
            var _rede = new RedePetri();
            _rede.CriarLugar(1, 11);
            _rede.CriarLugar(2, 1);
            _rede.CriarLugar(3);

            _rede.CriarTransicao(1);

            _rede.CriarArco(_rede.ObterLugar(1), (_rede.ObterTransicao(1), 1), TipoArco.Reset);
            _rede.CriarArco(_rede.ObterLugar(2), (_rede.ObterTransicao(1), 1), TipoArco.Normal);

            _rede.CriarArco(_rede.ObterTransicao(1), (_rede.ObterLugar(3), 1));
            return _rede;
        }
    }
}
