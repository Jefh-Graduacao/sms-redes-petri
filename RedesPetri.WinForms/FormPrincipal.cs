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

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            comboLugares.DataSource = _listaLugares;
            comboTransicoes.DataSource = _listaTransicoes;            
        }

        private void btCriarLugar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out var id))
                return;

            if (numericUpDown1.Value < 0)
                return;
            
            bool lugarCriado = _rede.CriarLugar(id, Convert.ToInt32(numericUpDown1.Value));
            if(lugarCriado)
                _listaLugares.Add(id);

            RedesenharGrid();
        }

        private void btCriarTransicao_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdNovaTransicao.Text, out var id))
                return;

            _rede.CriarTransicao(id);
            _listaTransicoes.Add(id);

            RedesenharGrid();
        }

        private void btCriarConexao_Click(object sender, EventArgs e)
        {
            var lugar = _rede.ObterLugar((int)comboLugares.SelectedValue);
            var transicao = _rede.ObterTransicao((int)comboTransicoes.SelectedValue);
            var peso = Convert.ToInt32(numericUpDown2.Value);            

             if (peso <= 0)
                return;

            _rede.CriarConexao(lugar, (transicao, peso));

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
            foreach (var id in _rede.LugaresTransicoes.Select(lt => lt.id))
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = id,
                    HeaderText = id
                });
            }

            dataGridView1.Rows.Add(_rede.LugaresTransicoes.Select(lt => lt.valor).ToArray());
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
    }
}
