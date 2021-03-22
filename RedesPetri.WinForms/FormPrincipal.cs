using RedesPetri.Entidades;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace RedesPetri.WinForms
{
    public partial class FormPrincipal : Form
    {
        private readonly RedePetri _rede = new();

        private readonly BindingList<int> _listaLugares = new();
        private readonly BindingList<int> _listaTransicoes = new();

        private int _cicloAtual = 0;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            /*
             * Padrão básico
            _rede.CriarLugar(1, 2);
            _rede.CriarLugar(2);
            _rede.CriarLugar(3);

            _rede.CriarTransicao(1);
            _rede.CriarTransicao(2);
            
            _rede.CriarConexao(_rede.ObterLugar(1), (_rede.ObterTransicao(1), 1));
            _rede.CriarConexao(_rede.ObterTransicao(1), (_rede.ObterLugar(2), 1));

            _rede.CriarConexao(_rede.ObterLugar(2), (_rede.ObterTransicao(2), 1));
            _rede.CriarConexao(_rede.ObterTransicao(2), (_rede.ObterLugar(3), 1));

            */

            /*
             * Resolução de concorrência
            _rede.CriarLugar(1, 1);
            _rede.CriarLugar(2);
            _rede.CriarLugar(3);

            _rede.CriarTransicao(1);
            _rede.CriarTransicao(2);

            _rede.CriarConexao(_rede.ObterLugar(1), (_rede.ObterTransicao(1), 1));
            _rede.CriarConexao(_rede.ObterLugar(1), (_rede.ObterTransicao(2), 1));

            _rede.CriarConexao(_rede.ObterTransicao(1), (_rede.ObterLugar(2), 1));
            _rede.CriarConexao(_rede.ObterTransicao(2), (_rede.ObterLugar(3), 1));
            */

            /* Exemplo do enunciado
            _rede.CriarLugar(1, 2);
            _rede.CriarLugar(2);
            _rede.CriarLugar(3, 2);
            _rede.CriarLugar(4);
            _rede.CriarLugar(5, 5);
            _rede.CriarLugar(6);
            _rede.CriarLugar(7);
            _rede.CriarLugar(8);

            _rede.CriarTransicao(1);
            _rede.CriarTransicao(2);
            _rede.CriarTransicao(3);
            _rede.CriarTransicao(4);

            _rede.CriarConexao(_rede.ObterLugar(1), (_rede.ObterTransicao(1), 1));
            _rede.CriarConexao(_rede.ObterLugar(2), (_rede.ObterTransicao(2), 1));
            _rede.CriarConexao(_rede.ObterLugar(3), (_rede.ObterTransicao(2), 2));
            _rede.CriarConexao(_rede.ObterLugar(5), (_rede.ObterTransicao(2), 3));
            _rede.CriarConexao(_rede.ObterLugar(4), (_rede.ObterTransicao(3), 1));
            _rede.CriarConexao(_rede.ObterLugar(6), (_rede.ObterTransicao(4), 1));
            _rede.CriarConexao(_rede.ObterLugar(7), (_rede.ObterTransicao(4), 1));

            _rede.CriarConexao(_rede.ObterTransicao(1), (_rede.ObterLugar(2), 1));
            _rede.CriarConexao(_rede.ObterTransicao(2), (_rede.ObterLugar(4), 1));
            _rede.CriarConexao(_rede.ObterTransicao(3), (_rede.ObterLugar(3), 2));
            _rede.CriarConexao(_rede.ObterTransicao(3), (_rede.ObterLugar(7), 1));
            _rede.CriarConexao(_rede.ObterTransicao(3), (_rede.ObterLugar(6), 1));
            _rede.CriarConexao(_rede.ObterTransicao(4), (_rede.ObterLugar(8), 1));
            _rede.CriarConexao(_rede.ObterTransicao(4), (_rede.ObterLugar(5), 3));
            */


            RedesenharGrid();
            AtualizarConexoes();

            comboLugares.DataSource = _listaLugares;
            comboTransicoes.DataSource = _listaTransicoes;

            comboLugares2.DataSource = _listaLugares;
            comboTransicoes2.DataSource = _listaTransicoes;
        }

        private void btCriarLugar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out var id))
                return;

            if (numeroDeMarcas.Value < 0)
                return;
            
            bool lugarCriado = _rede.CriarLugar(id, Convert.ToInt32(numeroDeMarcas.Value));
            if(lugarCriado)
                _listaLugares.Add(id);

            RedesenharGrid();
        }

        private void btCriarTransicao_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdNovaTransicao.Text, out var id))
                return;

            bool transicaoCriada = _rede.CriarTransicao(id);
            if(transicaoCriada)
                _listaTransicoes.Add(id);

            RedesenharGrid();
        }

        private void btCriarConexao_Click(object sender, EventArgs e)
        {
            var lugar = _rede.ObterLugar((int)comboLugares.SelectedValue);
            var transicao = _rede.ObterTransicao((int)comboTransicoes.SelectedValue);
            var peso = Convert.ToInt32(pesoTransicaoEntrada.Value);            

             if (peso < 1)
                return;

            _rede.CriarConexao(lugar, (transicao, peso));

            RedesenharGrid();
            AtualizarConexoes();
        }

        private void btCriarTransicaoSaida_Click(object sender, EventArgs e)
        {
            var lugar = _rede.ObterLugar((int)comboLugares2.SelectedValue);
            var transicao = _rede.ObterTransicao((int)comboTransicoes2.SelectedValue);
            var peso = Convert.ToInt32(pesoTransicaoSaida.Value);

            if (peso < 1)
                return;

            _rede.CriarConexao(transicao, (lugar, peso));

            RedesenharGrid();
            AtualizarConexoes();
        }

        private void LimparGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }

        private void RenderizarGrid()
        {
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Núm do Ciclo",
                Width = 200
            });
            
            foreach (var id in _rede.LugaresTransicoes.Select(lt => lt.id))
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = id,
                    HeaderText = id
                });
            }

            dataGridView1.Rows.Add((new[] { _cicloAtual.ToString() }).Concat(_rede.LugaresTransicoes.Select(lt => lt.valor)).ToArray());
        }

        private void RedesenharGrid()
        {
            LimparGrid();
            RenderizarGrid();
        }

        private void AtualizarConexoes()
        {
            var itensListView = _rede.Transicoes.SelectMany(transicao => transicao.TodasConexoes)
                .Select(conexao =>
                {
                    var descConexao = conexao.Direcao == DirecaoConexao.SaidaTransicao
                        ? $"T{conexao.Transicao.Id} -> L{conexao.Lugar.Id}"
                        : $"L{conexao.Lugar.Id} -> T{conexao.Transicao.Id}";

                    return new ListViewItem($"{descConexao} \t Peso ({conexao.Peso})");
                })
                .ToArray();

            listViewConexoes.Items.Clear();
            listViewConexoes.Items.AddRange(itensListView);
        }

        private void btExecutarCiclo_Click(object sender, EventArgs e)
        {
            var execucaoFeita = _rede.ExecutarCiclo();

            if (!execucaoFeita)
            {
                btExecutarCiclo.Enabled = false;
                MessageBox.Show("Não há mais ciclos de execução", "Simulação finalizada!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _cicloAtual += 1;
            dataGridView1.Rows.Add((new[] { _cicloAtual.ToString() }).Concat(_rede.LugaresTransicoes.Select(lt => lt.valor)).ToArray());
        }
    }
}
