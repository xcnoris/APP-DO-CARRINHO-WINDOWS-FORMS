namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    partial class Frm_Geral_Carrinho_UC
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
            this.Txt_Codigo_Carrinho = new System.Windows.Forms.TextBox();
            this.Txt_Congregacao_Nome = new System.Windows.Forms.TextBox();
            this.Txt_Nome = new System.Windows.Forms.TextBox();
            this.Txt_ID = new System.Windows.Forms.TextBox();
            this.Lbl_Situacao_Carrinho = new System.Windows.Forms.Label();
            this.Lbl_Cod_Carrinho = new System.Windows.Forms.Label();
            this.Lbl_Cod_Congregacao = new System.Windows.Forms.Label();
            this.Lbl_Nome_Carrinho = new System.Windows.Forms.Label();
            this.Lbl_Id_Carrinho = new System.Windows.Forms.Label();
            this.Txt_Congregacao_ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cbox_Situacao
            // 
            this.Cbox_Situacao.FormattingEnabled = true;
            this.Cbox_Situacao.Items.AddRange(new object[] {
            " ATIVO",
            " INATIVO"});
            this.Cbox_Situacao.Location = new System.Drawing.Point(533, 61);
            this.Cbox_Situacao.Name = "Cbox_Situacao";
            this.Cbox_Situacao.Size = new System.Drawing.Size(121, 21);
            this.Cbox_Situacao.TabIndex = 3;
            this.Cbox_Situacao.Text = "( Selecione )";
            // 
            // Txt_Codigo_Carrinho
            // 
            this.Txt_Codigo_Carrinho.Location = new System.Drawing.Point(139, 115);
            this.Txt_Codigo_Carrinho.MaxLength = 10;
            this.Txt_Codigo_Carrinho.Name = "Txt_Codigo_Carrinho";
            this.Txt_Codigo_Carrinho.Size = new System.Drawing.Size(100, 20);
            this.Txt_Codigo_Carrinho.TabIndex = 6;
            // 
            // Txt_Congregacao_Nome
            // 
            this.Txt_Congregacao_Nome.Location = new System.Drawing.Point(197, 89);
            this.Txt_Congregacao_Nome.MaxLength = 80;
            this.Txt_Congregacao_Nome.Name = "Txt_Congregacao_Nome";
            this.Txt_Congregacao_Nome.ReadOnly = true;
            this.Txt_Congregacao_Nome.Size = new System.Drawing.Size(234, 20);
            this.Txt_Congregacao_Nome.TabIndex = 5;
            this.Txt_Congregacao_Nome.Text = "Congregação Areias";
            // 
            // Txt_Nome
            // 
            this.Txt_Nome.Location = new System.Drawing.Point(139, 61);
            this.Txt_Nome.MaxLength = 80;
            this.Txt_Nome.Name = "Txt_Nome";
            this.Txt_Nome.Size = new System.Drawing.Size(292, 20);
            this.Txt_Nome.TabIndex = 2;
            // 
            // Txt_ID
            // 
            this.Txt_ID.Location = new System.Drawing.Point(138, 35);
            this.Txt_ID.MaxLength = 10;
            this.Txt_ID.Name = "Txt_ID";
            this.Txt_ID.ReadOnly = true;
            this.Txt_ID.Size = new System.Drawing.Size(100, 20);
            this.Txt_ID.TabIndex = 1;
            // 
            // Lbl_Situacao_Carrinho
            // 
            this.Lbl_Situacao_Carrinho.AutoSize = true;
            this.Lbl_Situacao_Carrinho.ForeColor = System.Drawing.Color.LimeGreen;
            this.Lbl_Situacao_Carrinho.Location = new System.Drawing.Point(457, 68);
            this.Lbl_Situacao_Carrinho.Name = "Lbl_Situacao_Carrinho";
            this.Lbl_Situacao_Carrinho.Size = new System.Drawing.Size(61, 13);
            this.Lbl_Situacao_Carrinho.TabIndex = 16;
            this.Lbl_Situacao_Carrinho.Text = "SITUAÇÃO";
            // 
            // Lbl_Cod_Carrinho
            // 
            this.Lbl_Cod_Carrinho.AutoSize = true;
            this.Lbl_Cod_Carrinho.ForeColor = System.Drawing.Color.LimeGreen;
            this.Lbl_Cod_Carrinho.Location = new System.Drawing.Point(22, 122);
            this.Lbl_Cod_Carrinho.Name = "Lbl_Cod_Carrinho";
            this.Lbl_Cod_Carrinho.Size = new System.Drawing.Size(109, 13);
            this.Lbl_Cod_Carrinho.TabIndex = 15;
            this.Lbl_Cod_Carrinho.Text = "CODIGO CARRINHO";
            this.Lbl_Cod_Carrinho.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Lbl_Cod_Congregacao
            // 
            this.Lbl_Cod_Congregacao.AutoSize = true;
            this.Lbl_Cod_Congregacao.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Cod_Congregacao.Location = new System.Drawing.Point(22, 96);
            this.Lbl_Cod_Congregacao.Name = "Lbl_Cod_Congregacao";
            this.Lbl_Cod_Congregacao.Size = new System.Drawing.Size(90, 13);
            this.Lbl_Cod_Congregacao.TabIndex = 14;
            this.Lbl_Cod_Congregacao.Text = "CONGREGAÇÃO";
            // 
            // Lbl_Nome_Carrinho
            // 
            this.Lbl_Nome_Carrinho.AutoSize = true;
            this.Lbl_Nome_Carrinho.ForeColor = System.Drawing.Color.LimeGreen;
            this.Lbl_Nome_Carrinho.Location = new System.Drawing.Point(22, 68);
            this.Lbl_Nome_Carrinho.Name = "Lbl_Nome_Carrinho";
            this.Lbl_Nome_Carrinho.Size = new System.Drawing.Size(39, 13);
            this.Lbl_Nome_Carrinho.TabIndex = 13;
            this.Lbl_Nome_Carrinho.Text = "NOME";
            this.Lbl_Nome_Carrinho.Click += new System.EventHandler(this.Lbl_Nome_Carrinho_Click);
            // 
            // Lbl_Id_Carrinho
            // 
            this.Lbl_Id_Carrinho.AutoSize = true;
            this.Lbl_Id_Carrinho.Location = new System.Drawing.Point(22, 42);
            this.Lbl_Id_Carrinho.Name = "Lbl_Id_Carrinho";
            this.Lbl_Id_Carrinho.Size = new System.Drawing.Size(18, 13);
            this.Lbl_Id_Carrinho.TabIndex = 12;
            this.Lbl_Id_Carrinho.Text = "ID";
            // 
            // Txt_Congregacao_ID
            // 
            this.Txt_Congregacao_ID.Location = new System.Drawing.Point(138, 89);
            this.Txt_Congregacao_ID.MaxLength = 10;
            this.Txt_Congregacao_ID.Name = "Txt_Congregacao_ID";
            this.Txt_Congregacao_ID.ReadOnly = true;
            this.Txt_Congregacao_ID.Size = new System.Drawing.Size(53, 20);
            this.Txt_Congregacao_ID.TabIndex = 4;
            this.Txt_Congregacao_ID.Text = "1";
            // 
            // Frm_Geral_Carrinho_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Txt_Congregacao_ID);
            this.Controls.Add(this.Cbox_Situacao);
            this.Controls.Add(this.Txt_Codigo_Carrinho);
            this.Controls.Add(this.Txt_Congregacao_Nome);
            this.Controls.Add(this.Txt_Nome);
            this.Controls.Add(this.Txt_ID);
            this.Controls.Add(this.Lbl_Situacao_Carrinho);
            this.Controls.Add(this.Lbl_Cod_Carrinho);
            this.Controls.Add(this.Lbl_Cod_Congregacao);
            this.Controls.Add(this.Lbl_Nome_Carrinho);
            this.Controls.Add(this.Lbl_Id_Carrinho);
            this.Name = "Frm_Geral_Carrinho_UC";
            this.Size = new System.Drawing.Size(695, 185);
            this.Load += new System.EventHandler(this.Frm_Geral_Carrinho_UC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cbox_Situacao;
        private System.Windows.Forms.TextBox Txt_Codigo_Carrinho;
        private System.Windows.Forms.TextBox Txt_Congregacao_Nome;
        private System.Windows.Forms.TextBox Txt_Nome;
        private System.Windows.Forms.TextBox Txt_ID;
        private System.Windows.Forms.Label Lbl_Situacao_Carrinho;
        private System.Windows.Forms.Label Lbl_Cod_Carrinho;
        private System.Windows.Forms.Label Lbl_Cod_Congregacao;
        private System.Windows.Forms.Label Lbl_Nome_Carrinho;
        private System.Windows.Forms.Label Lbl_Id_Carrinho;
        private System.Windows.Forms.TextBox Txt_Congregacao_ID;
    }
}
