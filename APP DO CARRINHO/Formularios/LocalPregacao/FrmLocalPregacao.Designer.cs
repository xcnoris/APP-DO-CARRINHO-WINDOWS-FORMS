namespace APP_DO_CARRINHO.Formularios.LocalPregacao
{
    partial class FrmLocalPregacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocalPregacao));
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cbox_Bairros = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_Excluir_Pessoas = new System.Windows.Forms.Button();
            this.Btn_Alterar_Pessoas = new System.Windows.Forms.Button();
            this.Btn_Incluir_Pessoas = new System.Windows.Forms.Button();
            this.Btn_Fechar = new System.Windows.Forms.Button();
            this.DGV_Dados = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Btn_Filtrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Dados)).BeginInit();
            this.SuspendLayout();
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(57, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bairro";
            // 
            // Cbox_Bairros
            // 
            this.Cbox_Bairros.FormattingEnabled = true;
            this.Cbox_Bairros.Location = new System.Drawing.Point(202, 21);
            this.Cbox_Bairros.Name = "Cbox_Bairros";
            this.Cbox_Bairros.Size = new System.Drawing.Size(175, 21);
            this.Cbox_Bairros.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Btn_Filtrar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.Cbox_Bairros);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 88);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // Btn_Excluir_Pessoas
            // 
            this.Btn_Excluir_Pessoas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Excluir_Pessoas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Excluir_Pessoas.BackgroundImage")));
            this.Btn_Excluir_Pessoas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Excluir_Pessoas.Location = new System.Drawing.Point(224, 401);
            this.Btn_Excluir_Pessoas.Name = "Btn_Excluir_Pessoas";
            this.Btn_Excluir_Pessoas.Size = new System.Drawing.Size(100, 39);
            this.Btn_Excluir_Pessoas.TabIndex = 35;
            this.Btn_Excluir_Pessoas.Text = "Excluir";
            this.Btn_Excluir_Pessoas.UseVisualStyleBackColor = true;
            // 
            // Btn_Alterar_Pessoas
            // 
            this.Btn_Alterar_Pessoas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Alterar_Pessoas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Alterar_Pessoas.BackgroundImage")));
            this.Btn_Alterar_Pessoas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Alterar_Pessoas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Alterar_Pessoas.Location = new System.Drawing.Point(118, 401);
            this.Btn_Alterar_Pessoas.Name = "Btn_Alterar_Pessoas";
            this.Btn_Alterar_Pessoas.Size = new System.Drawing.Size(100, 39);
            this.Btn_Alterar_Pessoas.TabIndex = 34;
            this.Btn_Alterar_Pessoas.Text = "Alterar";
            this.Btn_Alterar_Pessoas.UseVisualStyleBackColor = true;
            // 
            // Btn_Incluir_Pessoas
            // 
            this.Btn_Incluir_Pessoas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Incluir_Pessoas.BackgroundImage = global::APP_DO_CARRINHO.Properties.Resources.adicionar__2_;
            this.Btn_Incluir_Pessoas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Incluir_Pessoas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Incluir_Pessoas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Incluir_Pessoas.Location = new System.Drawing.Point(12, 401);
            this.Btn_Incluir_Pessoas.Name = "Btn_Incluir_Pessoas";
            this.Btn_Incluir_Pessoas.Size = new System.Drawing.Size(100, 39);
            this.Btn_Incluir_Pessoas.TabIndex = 33;
            this.Btn_Incluir_Pessoas.Text = "   Incluir";
            this.Btn_Incluir_Pessoas.UseVisualStyleBackColor = true;
            // 
            // Btn_Fechar
            // 
            this.Btn_Fechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Fechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Fechar.Location = new System.Drawing.Point(681, 410);
            this.Btn_Fechar.Name = "Btn_Fechar";
            this.Btn_Fechar.Size = new System.Drawing.Size(100, 30);
            this.Btn_Fechar.TabIndex = 36;
            this.Btn_Fechar.Text = "Fechar";
            this.Btn_Fechar.UseVisualStyleBackColor = true;
            this.Btn_Fechar.Click += new System.EventHandler(this.Btn_Fechar_Click);
            // 
            // DGV_Dados
            // 
            this.DGV_Dados.AllowUserToAddRows = false;
            this.DGV_Dados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Dados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Dados.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV_Dados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Dados.Location = new System.Drawing.Point(12, 106);
            this.DGV_Dados.Name = "DGV_Dados";
            this.DGV_Dados.ReadOnly = true;
            this.DGV_Dados.Size = new System.Drawing.Size(769, 289);
            this.DGV_Dados.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nome";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(57, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(320, 20);
            this.textBox2.TabIndex = 9;
            // 
            // Btn_Filtrar
            // 
            this.Btn_Filtrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Filtrar.Location = new System.Drawing.Point(592, 47);
            this.Btn_Filtrar.Name = "Btn_Filtrar";
            this.Btn_Filtrar.Size = new System.Drawing.Size(135, 23);
            this.Btn_Filtrar.TabIndex = 36;
            this.Btn_Filtrar.Text = "Filtrar ( Enter )";
            this.Btn_Filtrar.UseVisualStyleBackColor = true;
            // 
            // FrmLocalPregacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 447);
            this.Controls.Add(this.DGV_Dados);
            this.Controls.Add(this.Btn_Fechar);
            this.Controls.Add(this.Btn_Excluir_Pessoas);
            this.Controls.Add(this.Btn_Alterar_Pessoas);
            this.Controls.Add(this.Btn_Incluir_Pessoas);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(809, 486);
            this.MinimumSize = new System.Drawing.Size(809, 486);
            this.Name = "FrmLocalPregacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLocalPregacao";
            this.Load += new System.EventHandler(this.FrmLocalPregacao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Dados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cbox_Bairros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Excluir_Pessoas;
        private System.Windows.Forms.Button Btn_Alterar_Pessoas;
        private System.Windows.Forms.Button Btn_Incluir_Pessoas;
        private System.Windows.Forms.Button Btn_Fechar;
        private System.Windows.Forms.DataGridView DGV_Dados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Btn_Filtrar;
    }
}