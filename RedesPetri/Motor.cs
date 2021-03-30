using RedesPetri.Entidades;
using System.Linq;

namespace RedesPetri
{
    public sealed class Motor
    {
        public Motor(RedePetri rede)
        {
            Rede = rede;
        }

        public int CicloAtual { get; private set; } = 0;
        public RedePetri Rede { get; }

        public bool ExecutarCiclo()
        {
            var idsTransicoesHabilitadas = Rede.Transicoes.Where(tr => tr.EstáHabilitada).Select(tr => tr.Id).ToArray();

            if (idsTransicoesHabilitadas.Length == 0)
                return false;

            foreach (var transicao in Rede.Transicoes.ToArray())
            {
                // Se a id da transicao estiver em um dos ids habilitados
                if (idsTransicoesHabilitadas.Any(tr => tr == transicao.Id))
                {
                    // Consome marcas enquanto a transição estiver habilitada no ciclo                    
                    while (transicao.EstáHabilitada)
                    {
                        transicao.ConsumirMarcas();
                    }
                }
            }

            CicloAtual += 1;
            OnCicloExecutado();
            return true;
        }

        private void OnCicloExecutado()
        {

        }
    }
}
