namespace APP_DO_CARRINHO.Formularios.Agendamento
{
    partial class Frm_Geral_AgendamentoUC
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cbox_Situacao = new System.Windows.Forms.ComboBox();
            this.Txt_ID = new System.Windows.Forms.TextBox();
            this.Lbl_Situacao_Carrinho = new System.Windows.Forms.Label();
            this.Lbl_Id_Carrinho = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cbox_CategoriaAgendamento = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Cbox_Carrinhos = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DTP_Data = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DTP_Hora2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DTP_Hora1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Txt_Sigla_Uf = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Txt_Celular = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Txt_DDD_Celular = new System.Windows.Forms.TextBox();
            this.Txt_Endereco_Bairro = new System.Windows.Forms.TextBox();
            this.Txt_Endereco_Complemento = new System.Windows.Forms.TextBox();
            this.Txt_Telefone = new System.Windows.Forms.TextBox();
            this.Txt_EnderecoPessoa = new System.Windows.Forms.TextBox();
            this.Txt_DDD_Telefone = new System.Windows.Forms.TextBox();
            this.Txt_EmailPessoa = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Txt_NomePessoa = new System.Windows.Forms.TextBox();
            this.Txt_IdPessoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cbox_Situacao
            // 
            this.Cbox_Situacao.Enabled = false;
            this.Cbox_Situacao.FormattingEnabled = true;
            this.Cbox_Situacao.Items.AddRange(new object[] {
            " "});
            this.Cbox_Situacao.Location = new System.Drawing.Point(512, 28);
            this.Cbox_Situacao.Name = "Cbox_Situacao";
            this.Cbox_Situacao.Size = new System.Drawing.Size(121, 21);
            this.Cbox_Situacao.TabIndex = 19;
            this.Cbox_Situacao.Text = "( Selecione )";
            // 
            // Txt_ID
            // 
            this.Txt_ID.Location = new System.Drawing.Point(56, 27);
            this.Txt_ID.MaxLength = 10;
            this.Txt_ID.Name = "Txt_ID";
            this.Txt_ID.ReadOnly = true;
            this.Txt_ID.Size = new System.Drawing.Size(71, 20);
            this.Txt_ID.TabIndex = 17;
            this.Txt_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Lbl_Situacao_Carrinho
            // 
            this.Lbl_Situacao_Carrinho.AutoSize = true;
            this.Lbl_Situacao_Carrinho.ForeColor = System.Drawing.Color.LimeGreen;
            this.Lbl_Situacao_Carrinho.Location = new System.Drawing.Point(445, 31);
            this.Lbl_Situacao_Carrinho.Name = "Lbl_Situacao_Carrinho";
            this.Lbl_Situacao_Carrinho.Size = new System.Drawing.Size(61, 13);
            this.Lbl_Situacao_Carrinho.TabIndex = 27;
            this.Lbl_Situacao_Carrinho.Text = "SITUAÇÃO";
            // 
            // Lbl_Id_Carrinho
            // 
            this.Lbl_Id_Carrinho.AutoSize = true;
            this.Lbl_Id_Carrinho.Location = new System.Drawing.Point(17, 31);
            this.Lbl_Id_Carrinho.Name = "Lbl_Id_Carrinho";
            this.Lbl_Id_Carrinho.Size = new System.Drawing.Size(18, 13);
            this.Lbl_Id_Carrinho.TabIndex = 23;
            this.Lbl_Id_Carrinho.Text = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Cbox_CategoriaAgendamento);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.Lbl_Id_Carrinho);
            this.groupBox1.Controls.Add(this.Cbox_Situacao);
            this.groupBox1.Controls.Add(this.Lbl_Situacao_Carrinho);
            this.groupBox1.Controls.Add(this.Txt_ID);
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 251);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Gerais do Agendamento";
            // 
            // Cbox_CategoriaAgendamento
            // 
            this.Cbox_CategoriaAgendamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbox_CategoriaAgendamento.FormattingEnabled = true;
            this.Cbox_CategoriaAgendamento.Location = new System.Drawing.Point(255, 26);
            this.Cbox_CategoriaAgendamento.Name = "Cbox_CategoriaAgendamento";
            this.Cbox_CategoriaAgendamento.Size = new System.Drawing.Size(133, 21);
            this.Cbox_CategoriaAgendamento.TabIndex = 61;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(200, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "Categoria";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Cbox_Carrinhos);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(19, 138);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(614, 73);
            this.groupBox4.TabIndex = 59;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Carrinho";
            // 
            // Cbox_Carrinhos
            // 
            this.Cbox_Carrinhos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbox_Carrinhos.FormattingEnabled = true;
            this.Cbox_Carrinhos.Location = new System.Drawing.Point(141, 29);
            this.Cbox_Carrinhos.Name = "Cbox_Carrinhos";
            this.Cbox_Carrinhos.Size = new System.Drawing.Size(133, 21);
            this.Cbox_Carrinhos.TabIndex = 62;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.LimeGreen;
            this.label12.Location = new System.Drawing.Point(25, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 13);
            this.label12.TabIndex = 60;
            this.label12.Text = "Selecione o carrinho:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DTP_Data);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.DTP_Hora2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.DTP_Hora1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(19, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(614, 65);
            this.groupBox3.TabIndex = 58;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data e Hora";
            // 
            // DTP_Data
            // 
            this.DTP_Data.Location = new System.Drawing.Point(141, 26);
            this.DTP_Data.Name = "DTP_Data";
            this.DTP_Data.Size = new System.Drawing.Size(133, 20);
            this.DTP_Data.TabIndex = 50;
            this.DTP_Data.Value = new System.DateTime(2024, 7, 6, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(102, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 51;
            this.label4.Text = "Data";
            // 
            // DTP_Hora2
            // 
            this.DTP_Hora2.Location = new System.Drawing.Point(500, 23);
            this.DTP_Hora2.Name = "DTP_Hora2";
            this.DTP_Hora2.Size = new System.Drawing.Size(69, 20);
            this.DTP_Hora2.TabIndex = 56;
            this.DTP_Hora2.Value = new System.DateTime(2024, 7, 6, 11, 24, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Até";
            // 
            // DTP_Hora1
            // 
            this.DTP_Hora1.Location = new System.Drawing.Point(393, 22);
            this.DTP_Hora1.Name = "DTP_Hora1";
            this.DTP_Hora1.Size = new System.Drawing.Size(69, 20);
            this.DTP_Hora1.TabIndex = 49;
            this.DTP_Hora1.Value = new System.DateTime(2024, 7, 6, 11, 24, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.LimeGreen;
            this.label6.Location = new System.Drawing.Point(342, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 54;
            this.label6.Text = "Hora";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Txt_Sigla_Uf);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Txt_Celular);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.Txt_DDD_Celular);
            this.groupBox2.Controls.Add(this.Txt_Endereco_Bairro);
            this.groupBox2.Controls.Add(this.Txt_Endereco_Complemento);
            this.groupBox2.Controls.Add(this.Txt_Telefone);
            this.groupBox2.Controls.Add(this.Txt_EnderecoPessoa);
            this.groupBox2.Controls.Add(this.Txt_DDD_Telefone);
            this.groupBox2.Controls.Add(this.Txt_EmailPessoa);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.Txt_NomePessoa);
            this.groupBox2.Controls.Add(this.Txt_IdPessoa);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(16, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(648, 177);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados da Pessoa";
            // 
            // Txt_Sigla_Uf
            // 
            this.Txt_Sigla_Uf.Location = new System.Drawing.Point(312, 146);
            this.Txt_Sigla_Uf.Name = "Txt_Sigla_Uf";
            this.Txt_Sigla_Uf.Size = new System.Drawing.Size(25, 20);
            this.Txt_Sigla_Uf.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(366, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Celular";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Bairro";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(366, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Telefone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Complemento";
            // 
            // Txt_Celular
            // 
            this.Txt_Celular.Location = new System.Drawing.Point(459, 119);
            this.Txt_Celular.Name = "Txt_Celular";
            this.Txt_Celular.Size = new System.Drawing.Size(87, 20);
            this.Txt_Celular.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Endereço";
            // 
            // Txt_DDD_Celular
            // 
            this.Txt_DDD_Celular.Location = new System.Drawing.Point(422, 119);
            this.Txt_DDD_Celular.Name = "Txt_DDD_Celular";
            this.Txt_DDD_Celular.Size = new System.Drawing.Size(31, 20);
            this.Txt_DDD_Celular.TabIndex = 42;
            this.Txt_DDD_Celular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_Endereco_Bairro
            // 
            this.Txt_Endereco_Bairro.Location = new System.Drawing.Point(101, 146);
            this.Txt_Endereco_Bairro.Name = "Txt_Endereco_Bairro";
            this.Txt_Endereco_Bairro.Size = new System.Drawing.Size(203, 20);
            this.Txt_Endereco_Bairro.TabIndex = 30;
            // 
            // Txt_Endereco_Complemento
            // 
            this.Txt_Endereco_Complemento.Location = new System.Drawing.Point(101, 119);
            this.Txt_Endereco_Complemento.Name = "Txt_Endereco_Complemento";
            this.Txt_Endereco_Complemento.Size = new System.Drawing.Size(236, 20);
            this.Txt_Endereco_Complemento.TabIndex = 29;
            // 
            // Txt_Telefone
            // 
            this.Txt_Telefone.Location = new System.Drawing.Point(459, 89);
            this.Txt_Telefone.Name = "Txt_Telefone";
            this.Txt_Telefone.Size = new System.Drawing.Size(87, 20);
            this.Txt_Telefone.TabIndex = 41;
            // 
            // Txt_EnderecoPessoa
            // 
            this.Txt_EnderecoPessoa.Location = new System.Drawing.Point(101, 89);
            this.Txt_EnderecoPessoa.Name = "Txt_EnderecoPessoa";
            this.Txt_EnderecoPessoa.Size = new System.Drawing.Size(236, 20);
            this.Txt_EnderecoPessoa.TabIndex = 28;
            // 
            // Txt_DDD_Telefone
            // 
            this.Txt_DDD_Telefone.Location = new System.Drawing.Point(422, 89);
            this.Txt_DDD_Telefone.Name = "Txt_DDD_Telefone";
            this.Txt_DDD_Telefone.Size = new System.Drawing.Size(31, 20);
            this.Txt_DDD_Telefone.TabIndex = 40;
            this.Txt_DDD_Telefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_EmailPessoa
            // 
            this.Txt_EmailPessoa.Location = new System.Drawing.Point(101, 60);
            this.Txt_EmailPessoa.MaxLength = 80;
            this.Txt_EmailPessoa.Name = "Txt_EmailPessoa";
            this.Txt_EmailPessoa.Size = new System.Drawing.Size(445, 20);
            this.Txt_EmailPessoa.TabIndex = 39;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = global::APP_DO_CARRINHO.Properties.Resources.encontrar;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Location = new System.Drawing.Point(606, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 23);
            this.button3.TabIndex = 38;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = global::APP_DO_CARRINHO.Properties.Resources.encontrar;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(579, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 37;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::APP_DO_CARRINHO.Properties.Resources.encontrar;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(552, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 36;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // Txt_NomePessoa
            // 
            this.Txt_NomePessoa.Location = new System.Drawing.Point(160, 29);
            this.Txt_NomePessoa.MaxLength = 80;
            this.Txt_NomePessoa.Name = "Txt_NomePessoa";
            this.Txt_NomePessoa.Size = new System.Drawing.Size(386, 20);
            this.Txt_NomePessoa.TabIndex = 29;
            // 
            // Txt_IdPessoa
            // 
            this.Txt_IdPessoa.Location = new System.Drawing.Point(101, 29);
            this.Txt_IdPessoa.MaxLength = 10;
            this.Txt_IdPessoa.Name = "Txt_IdPessoa";
            this.Txt_IdPessoa.Size = new System.Drawing.Size(53, 20);
            this.Txt_IdPessoa.TabIndex = 28;
            this.Txt_IdPessoa.Text = "0";
            this.Txt_IdPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Pessoa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "E-mail";
            // 
            // Frm_Geral_AgendamentoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(681, 462);
            this.MinimumSize = new System.Drawing.Size(681, 462);
            this.Name = "Frm_Geral_AgendamentoUC";
            this.Size = new System.Drawing.Size(681, 462);
            this.Load += new System.EventHandler(this.Frm_Geral_AgendamentoUC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox Cbox_Situacao;
        private System.Windows.Forms.TextBox Txt_ID;
        private System.Windows.Forms.Label Lbl_Situacao_Carrinho;
        private System.Windows.Forms.Label Lbl_Id_Carrinho;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Txt_NomePessoa;
        private System.Windows.Forms.TextBox Txt_IdPessoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Txt_Celular;
        private System.Windows.Forms.TextBox Txt_DDD_Celular;
        private System.Windows.Forms.TextBox Txt_Telefone;
        private System.Windows.Forms.TextBox Txt_DDD_Telefone;
        private System.Windows.Forms.TextBox Txt_EmailPessoa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Txt_Endereco_Bairro;
        private System.Windows.Forms.TextBox Txt_Endereco_Complemento;
        private System.Windows.Forms.TextBox Txt_EnderecoPessoa;
        private System.Windows.Forms.TextBox Txt_Sigla_Uf;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker DTP_Data;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTP_Hora2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTP_Hora1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox Cbox_CategoriaAgendamento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox Cbox_Carrinhos;
    }
}
