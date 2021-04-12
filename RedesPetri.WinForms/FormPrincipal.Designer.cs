
namespace RedesPetri.WinForms
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btCriarLugar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numeroDeMarcas = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIdNovaTransicao = new System.Windows.Forms.TextBox();
            this.btCriarTransicao = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btCriarTransicaoSaida = new System.Windows.Forms.Button();
            this.pesoTransicaoSaida = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboLugares2 = new System.Windows.Forms.ComboBox();
            this.comboTransicoes2 = new System.Windows.Forms.ComboBox();
            this.listViewConexoes = new System.Windows.Forms.ListView();
            this.btExecutarCiclo = new System.Windows.Forms.Button();
            this.comboLugares = new System.Windows.Forms.ComboBox();
            this.comboTransicoes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pesoTransicaoEntrada = new System.Windows.Forms.NumericUpDown();
            this.btCriarConexao = new System.Windows.Forms.Button();
            this.comboBoxTipoCon = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxConexao = new System.Windows.Forms.GroupBox();
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.simulacaoStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novaSimulacaoStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.executarTodosCiclosStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exemplosStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeroDeMarcas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pesoTransicaoSaida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pesoTransicaoEntrada)).BeginInit();
            this.groupBoxConexao.SuspendLayout();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 352);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1467, 493);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 66);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 36);
            this.textBox1.TabIndex = 1;
            // 
            // btCriarLugar
            // 
            this.btCriarLugar.Location = new System.Drawing.Point(170, 108);
            this.btCriarLugar.Margin = new System.Windows.Forms.Padding(4);
            this.btCriarLugar.Name = "btCriarLugar";
            this.btCriarLugar.Size = new System.Drawing.Size(92, 41);
            this.btCriarLugar.TabIndex = 2;
            this.btCriarLugar.Text = "Criar";
            this.btCriarLugar.UseVisualStyleBackColor = true;
            this.btCriarLugar.Click += new System.EventHandler(this.btCriarLugar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numeroDeMarcas);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btCriarLugar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(282, 159);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lugar";
            // 
            // numeroDeMarcas
            // 
            this.numeroDeMarcas.Location = new System.Drawing.Point(167, 65);
            this.numeroDeMarcas.Margin = new System.Windows.Forms.Padding(4);
            this.numeroDeMarcas.Name = "numeroDeMarcas";
            this.numeroDeMarcas.Size = new System.Drawing.Size(93, 36);
            this.numeroDeMarcas.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Marcas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIdNovaTransicao);
            this.groupBox2.Controls.Add(this.btCriarTransicao);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(310, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 159);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transição";
            // 
            // txtIdNovaTransicao
            // 
            this.txtIdNovaTransicao.Location = new System.Drawing.Point(6, 66);
            this.txtIdNovaTransicao.Name = "txtIdNovaTransicao";
            this.txtIdNovaTransicao.Size = new System.Drawing.Size(149, 36);
            this.txtIdNovaTransicao.TabIndex = 1;
            // 
            // btCriarTransicao
            // 
            this.btCriarTransicao.Location = new System.Drawing.Point(63, 109);
            this.btCriarTransicao.Name = "btCriarTransicao";
            this.btCriarTransicao.Size = new System.Drawing.Size(92, 41);
            this.btCriarTransicao.TabIndex = 2;
            this.btCriarTransicao.Text = "Criar";
            this.btCriarTransicao.UseVisualStyleBackColor = true;
            this.btCriarTransicao.Click += new System.EventHandler(this.btCriarTransicao_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Id";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btCriarTransicaoSaida);
            this.groupBox3.Controls.Add(this.pesoTransicaoSaida);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.comboLugares2);
            this.groupBox3.Controls.Add(this.comboTransicoes2);
            this.groupBox3.Location = new System.Drawing.Point(917, 37);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 159);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Conexão (Transição -> Lugar)";
            // 
            // btCriarTransicaoSaida
            // 
            this.btCriarTransicaoSaida.Location = new System.Drawing.Point(322, 111);
            this.btCriarTransicaoSaida.Name = "btCriarTransicaoSaida";
            this.btCriarTransicaoSaida.Size = new System.Drawing.Size(92, 41);
            this.btCriarTransicaoSaida.TabIndex = 2;
            this.btCriarTransicaoSaida.Text = "Criar";
            this.btCriarTransicaoSaida.UseVisualStyleBackColor = true;
            this.btCriarTransicaoSaida.Click += new System.EventHandler(this.btCriarTransicaoSaida_Click);
            // 
            // pesoTransicaoSaida
            // 
            this.pesoTransicaoSaida.Location = new System.Drawing.Point(321, 67);
            this.pesoTransicaoSaida.Margin = new System.Windows.Forms.Padding(4);
            this.pesoTransicaoSaida.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pesoTransicaoSaida.Name = "pesoTransicaoSaida";
            this.pesoTransicaoSaida.Size = new System.Drawing.Size(93, 36);
            this.pesoTransicaoSaida.TabIndex = 6;
            this.pesoTransicaoSaida.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 29);
            this.label7.TabIndex = 7;
            this.label7.Text = "Peso";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 29);
            this.label8.TabIndex = 5;
            this.label8.Text = "Id Lugar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 29);
            this.label9.TabIndex = 4;
            this.label9.Text = "Id Transição";
            // 
            // comboLugares2
            // 
            this.comboLugares2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLugares2.FormattingEnabled = true;
            this.comboLugares2.Location = new System.Drawing.Point(163, 66);
            this.comboLugares2.Name = "comboLugares2";
            this.comboLugares2.Size = new System.Drawing.Size(151, 37);
            this.comboLugares2.TabIndex = 1;
            // 
            // comboTransicoes2
            // 
            this.comboTransicoes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTransicoes2.FormattingEnabled = true;
            this.comboTransicoes2.Location = new System.Drawing.Point(6, 66);
            this.comboTransicoes2.Name = "comboTransicoes2";
            this.comboTransicoes2.Size = new System.Drawing.Size(151, 37);
            this.comboTransicoes2.TabIndex = 0;
            // 
            // listViewConexoes
            // 
            this.listViewConexoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewConexoes.HideSelection = false;
            this.listViewConexoes.Location = new System.Drawing.Point(13, 203);
            this.listViewConexoes.Name = "listViewConexoes";
            this.listViewConexoes.Size = new System.Drawing.Size(1468, 142);
            this.listViewConexoes.TabIndex = 9;
            this.listViewConexoes.UseCompatibleStateImageBehavior = false;
            this.listViewConexoes.View = System.Windows.Forms.View.List;
            // 
            // btExecutarCiclo
            // 
            this.btExecutarCiclo.Location = new System.Drawing.Point(1264, 852);
            this.btExecutarCiclo.Name = "btExecutarCiclo";
            this.btExecutarCiclo.Size = new System.Drawing.Size(216, 32);
            this.btExecutarCiclo.TabIndex = 10;
            this.btExecutarCiclo.Text = "Executar ciclo";
            this.btExecutarCiclo.UseVisualStyleBackColor = true;
            this.btExecutarCiclo.Click += new System.EventHandler(this.btExecutarCiclo_Click);
            // 
            // comboLugares
            // 
            this.comboLugares.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLugares.FormattingEnabled = true;
            this.comboLugares.Location = new System.Drawing.Point(6, 66);
            this.comboLugares.Name = "comboLugares";
            this.comboLugares.Size = new System.Drawing.Size(151, 37);
            this.comboLugares.TabIndex = 0;
            // 
            // comboTransicoes
            // 
            this.comboTransicoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTransicoes.FormattingEnabled = true;
            this.comboTransicoes.Location = new System.Drawing.Point(163, 66);
            this.comboTransicoes.Name = "comboTransicoes";
            this.comboTransicoes.Size = new System.Drawing.Size(151, 37);
            this.comboTransicoes.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Id Lugar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 29);
            this.label5.TabIndex = 5;
            this.label5.Text = "Id Transição";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 34);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 29);
            this.label6.TabIndex = 7;
            this.label6.Text = "Peso";
            // 
            // pesoTransicaoEntrada
            // 
            this.pesoTransicaoEntrada.Location = new System.Drawing.Point(321, 67);
            this.pesoTransicaoEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.pesoTransicaoEntrada.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pesoTransicaoEntrada.Name = "pesoTransicaoEntrada";
            this.pesoTransicaoEntrada.Size = new System.Drawing.Size(93, 36);
            this.pesoTransicaoEntrada.TabIndex = 6;
            this.pesoTransicaoEntrada.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btCriarConexao
            // 
            this.btCriarConexao.Location = new System.Drawing.Point(322, 111);
            this.btCriarConexao.Name = "btCriarConexao";
            this.btCriarConexao.Size = new System.Drawing.Size(92, 41);
            this.btCriarConexao.TabIndex = 2;
            this.btCriarConexao.Text = "Criar";
            this.btCriarConexao.UseVisualStyleBackColor = true;
            this.btCriarConexao.Click += new System.EventHandler(this.btCriarConexao_Click);
            // 
            // comboBoxTipoCon
            // 
            this.comboBoxTipoCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoCon.FormattingEnabled = true;
            this.comboBoxTipoCon.Location = new System.Drawing.Point(163, 112);
            this.comboBoxTipoCon.Name = "comboBoxTipoCon";
            this.comboBoxTipoCon.Size = new System.Drawing.Size(151, 37);
            this.comboBoxTipoCon.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 29);
            this.label10.TabIndex = 9;
            this.label10.Text = "Tipo Conexão";
            // 
            // groupBoxConexao
            // 
            this.groupBoxConexao.Controls.Add(this.label10);
            this.groupBoxConexao.Controls.Add(this.comboBoxTipoCon);
            this.groupBoxConexao.Controls.Add(this.btCriarConexao);
            this.groupBoxConexao.Controls.Add(this.pesoTransicaoEntrada);
            this.groupBoxConexao.Controls.Add(this.label6);
            this.groupBoxConexao.Controls.Add(this.label5);
            this.groupBoxConexao.Controls.Add(this.label4);
            this.groupBoxConexao.Controls.Add(this.comboTransicoes);
            this.groupBoxConexao.Controls.Add(this.comboLugares);
            this.groupBoxConexao.Location = new System.Drawing.Point(489, 37);
            this.groupBoxConexao.Name = "groupBoxConexao";
            this.groupBoxConexao.Size = new System.Drawing.Size(422, 159);
            this.groupBoxConexao.TabIndex = 7;
            this.groupBoxConexao.TabStop = false;
            this.groupBoxConexao.Text = "Conexão (Lugar -> Transição)";
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulacaoStripMenuItem,
            this.exemplosStripMenuItem});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(1492, 33);
            this.menuPrincipal.TabIndex = 17;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // simulacaoStripMenuItem
            // 
            this.simulacaoStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novaSimulacaoStripMenuItem,
            this.toolStripSeparator6,
            this.executarTodosCiclosStripMenuItem});
            this.simulacaoStripMenuItem.Name = "simulacaoStripMenuItem";
            this.simulacaoStripMenuItem.Size = new System.Drawing.Size(109, 29);
            this.simulacaoStripMenuItem.Text = "&Simulação";
            // 
            // novaSimulacaoStripMenuItem
            // 
            this.novaSimulacaoStripMenuItem.Name = "novaSimulacaoStripMenuItem";
            this.novaSimulacaoStripMenuItem.Size = new System.Drawing.Size(303, 34);
            this.novaSimulacaoStripMenuItem.Text = "Nova";
            this.novaSimulacaoStripMenuItem.Click += new System.EventHandler(this.novaSimulacaoStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(300, 6);
            // 
            // executarTodosCiclosStripMenuItem
            // 
            this.executarTodosCiclosStripMenuItem.Name = "executarTodosCiclosStripMenuItem";
            this.executarTodosCiclosStripMenuItem.Size = new System.Drawing.Size(303, 34);
            this.executarTodosCiclosStripMenuItem.Text = "Executar todos os ciclos";
            this.executarTodosCiclosStripMenuItem.Click += new System.EventHandler(this.executarTodosCiclosStripMenuItem_Click);
            // 
            // exemplosStripMenuItem
            // 
            this.exemplosStripMenuItem.Name = "exemplosStripMenuItem";
            this.exemplosStripMenuItem.Size = new System.Drawing.Size(104, 29);
            this.exemplosStripMenuItem.Text = "&Exemplos";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 894);
            this.Controls.Add(this.menuPrincipal);
            this.Controls.Add(this.btExecutarCiclo);
            this.Controls.Add(this.listViewConexoes);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxConexao);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rede de Petri";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeroDeMarcas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pesoTransicaoSaida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pesoTransicaoEntrada)).EndInit();
            this.groupBoxConexao.ResumeLayout(false);
            this.groupBoxConexao.PerformLayout();
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btCriarLugar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numeroDeMarcas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIdNovaTransicao;
        private System.Windows.Forms.Button btCriarTransicao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btCriarTransicaoSaida;
        private System.Windows.Forms.NumericUpDown pesoTransicaoSaida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboLugares2;
        private System.Windows.Forms.ComboBox comboTransicoes2;
        private System.Windows.Forms.ListView listViewConexoes;
        private System.Windows.Forms.Button btExecutarCiclo;
        private System.Windows.Forms.ComboBox comboLugares;
        private System.Windows.Forms.ComboBox comboTransicoes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown pesoTransicaoEntrada;
        private System.Windows.Forms.Button btCriarConexao;
        private System.Windows.Forms.ComboBox comboBoxTipoCon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBoxConexao;
        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem novaSimulacaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulacaoStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novaSimulacaoStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem executarTodosCiclosStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exemplosStripMenuItem;
    }
}

