using RedesPetri.Entidades;
using Shields.GraphViz.Components;
using Shields.GraphViz.Models;
using Shields.GraphViz.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedesPetri.WinForms
{
    public partial class FormPrincipal : Form
    {
        private RedePetri _rede = new();

        private BindingList<int> _listaLugares = new();
        private BindingList<int> _listaTransicoes = new();

        public FormPrincipal()
        {
            InitializeComponent();

            void clickMenuCarregarExemplo(object sender, EventArgs e)
            {
                if (sender is not ToolStripMenuItem { Text: { Length: > 0 } } menuItem)
                    return;

                _rede = ExemplosProntos.Redes[menuItem.Text];
                CarregarRedeNaTela();
            };

            exemplosStripMenuItem.DropDownItems.AddRange(
                 ExemplosProntos.Redes.Select(itemDicionario => new ToolStripMenuItem(itemDicionario.Key, null, clickMenuCarregarExemplo)).ToArray()
            );
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            comboBoxTipoCon.DataSource = new BindingList<TipoArco>(new[]
            {
                TipoArco.Normal,
                TipoArco.Inibidor,
                TipoArco.Reset
            });

            CarregarRedeNaTela();

            menuPrincipal.Visible = true;
        }

        private void CarregarRedeNaTela()
        {
            _listaLugares = new BindingList<int>(_rede.Lugares.Select(x => x.Id).ToList());
            _listaTransicoes = new BindingList<int>(_rede.Transicoes.Select(x => x.Id).ToList());

            comboLugares.DataSource = _listaLugares;
            comboTransicoes.DataSource = _listaTransicoes;

            comboLugares2.DataSource = _listaLugares;
            comboTransicoes2.DataSource = _listaTransicoes;

            RedesenharGrid();
            AtualizarConexoes();

            btExecutarCiclo.Enabled = true;
        }

        private void btCriarLugar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out var id))
                return;

            if (numeroDeMarcas.Value < 0)
                return;

            bool lugarCriado = _rede.CriarLugar(id, Convert.ToInt32(numeroDeMarcas.Value));
            if (lugarCriado)
                _listaLugares.Add(id);

            RedesenharGrid();
        }

        private void btCriarTransicao_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtIdNovaTransicao.Text, out var id))
                return;

            bool transicaoCriada = _rede.CriarTransicao(id);
            if (transicaoCriada)
                _listaTransicoes.Add(id);

            RedesenharGrid();
        }

        private void btCriarConexao_Click(object sender, EventArgs e)
        {
            var lugar = _rede.ObterLugar((int)comboLugares.SelectedValue);
            var transicao = _rede.ObterTransicao((int)comboTransicoes.SelectedValue);
            var peso = Convert.ToInt32(pesoTransicaoEntrada.Value);
            TipoArco tipoConexao = (TipoArco)comboBoxTipoCon.SelectedValue;

            if (peso < 1)
                return;

            _rede.CriarArco(lugar, (transicao, peso), tipoConexao);

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

            _rede.CriarArco(transicao, (lugar, peso));

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
                HeaderText = "Ciclo",
                Width = 100
            });

            foreach (var id in _rede.LugaresTransicoes.Select(lt => lt.id))
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = id,
                    HeaderText = id,
                    Width = 100
                });
            }

            dataGridView1.Rows.Add((new[] { _rede.CicloAtual.ToString() }).Concat(_rede.LugaresTransicoes.Select(lt => lt.valor)).ToArray());
        }

        private void RedesenharGrid()
        {
            LimparGrid();
            RenderizarGrid();
        }

        private void AtualizarConexoes()
        {
            var itensListView = _rede.Transicoes.SelectMany(transicao => transicao.TodasConexoes)
                .Select(arco =>
                {
                    var descConexao = arco.Direcao == DirecaoArco.SaidaTransicao
                        ? $"T{arco.Transicao.Id} -> L{arco.Lugar.Id}"
                        : $"L{arco.Lugar.Id} -> T{arco.Transicao.Id}";

                    var tipo = "";
                    if (arco.Direcao == DirecaoArco.EntradaTransicao)
                    {
                        if (arco.Tipo == TipoArco.Normal)
                            tipo = "(Tipo N)";
                        else if (arco.Tipo == TipoArco.Inibidor)
                            tipo = "(Tipo I)";
                        else if (arco.Tipo == TipoArco.Reset)
                            tipo = "(Tipo R)";
                    }

                    return new ListViewItem($"{descConexao} \t Peso {arco.Peso} {tipo}");
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

            AdicionarUltimoCicloNoGrid();
        }

        private void AdicionarUltimoCicloNoGrid() =>
            dataGridView1.Rows.Add((new[] { _rede.CicloAtual.ToString() }).Concat(_rede.LugaresTransicoes.Select(lt => lt.valor)).ToArray());
        
        private static async Task GerarImagem()
        {
            var graph = Graph.Directed
                .Add(EdgeStatement.For("a", "b"))
                .Add(EdgeStatement.For("a", "c"));

            var renderer = new Renderer("C:\\\\Program Files\\Graphviz\\bin");
            using var file = File.Create("C:\\\\Users\\bueno\\Desktop\\graph.png");
            await renderer.RunAsync(graph, file, RendererLayouts.Dot, RendererFormats.Png, CancellationToken.None);
        }

        private async void executarTodosCiclosStripMenuItem_Click(object sender, EventArgs e)
        {
            bool continuarExecucao = true;
            while (continuarExecucao)
            {
                continuarExecucao = _rede.ExecutarCiclo();
                if (continuarExecucao)
                    AdicionarUltimoCicloNoGrid();

                await Task.Delay(250);
            }
        }

        private void novaSimulacaoStripMenuItem_Click(object sender, EventArgs e)
        {
            _rede = new();
            CarregarRedeNaTela();
        }
    }
}
