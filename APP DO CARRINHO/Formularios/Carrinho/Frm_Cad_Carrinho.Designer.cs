namespace APP_DO_CARRINHO
{
    partial class Frm_Cadastro_Carrinho
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lbl_Id_Carrinho = new System.Windows.Forms.Label();
            this.Lbl_Nome_Carrinho = new System.Windows.Forms.Label();
            this.Lbl_Cod_Congregacao = new System.Windows.Forms.Label();
            this.Lbl_Cod_Carrinho = new System.Windows.Forms.Label();
            this.Lbl_Situacao_Carrinho = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Btn_Confirmar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Lbl_Id_Carrinho
            // 
            this.Lbl_Id_Carrinho.AutoSize = true;
            this.Lbl_Id_Carrinho.Location = new System.Drawing.Point(12, 19);
            this.Lbl_Id_Carrinho.Name = "Lbl_Id_Carrinho";
            this.Lbl_Id_Carrinho.Size = new System.Drawing.Size(18, 13);
            this.Lbl_Id_Carrinho.TabIndex = 0;
            this.Lbl_Id_Carrinho.Text = "ID";
            // 
            // Lbl_Nome_Carrinho
            // 
            this.Lbl_Nome_Carrinho.AutoSize = true;
            this.Lbl_Nome_Carrinho.Location = new System.Drawing.Point(12, 45);
            this.Lbl_Nome_Carrinho.Name = "Lbl_Nome_Carrinho";
            this.Lbl_Nome_Carrinho.Size = new System.Drawing.Size(39, 13);
            this.Lbl_Nome_Carrinho.TabIndex = 1;
            this.Lbl_Nome_Carrinho.Text = "NOME";
            // 
            // Lbl_Cod_Congregacao
            // 
            this.Lbl_Cod_Congregacao.AutoSize = true;
            this.Lbl_Cod_Congregacao.Location = new System.Drawing.Point(12, 73);
            this.Lbl_Cod_Congregacao.Name = "Lbl_Cod_Congregacao";
            this.Lbl_Cod_Congregacao.Size = new System.Drawing.Size(90, 13);
            this.Lbl_Cod_Congregacao.TabIndex = 2;
            this.Lbl_Cod_Congregacao.Text = "CONGREGAÇÃO";
            // 
            // Lbl_Cod_Carrinho
            // 
            this.Lbl_Cod_Carrinho.AutoSize = true;
            this.Lbl_Cod_Carrinho.Location = new System.Drawing.Point(12, 99);
            this.Lbl_Cod_Carrinho.Name = "Lbl_Cod_Carrinho";
            this.Lbl_Cod_Carrinho.Size = new System.Drawing.Size(109, 13);
            this.Lbl_Cod_Carrinho.TabIndex = 3;
            this.Lbl_Cod_Carrinho.Text = "CODIGO CARRINHO";
            this.Lbl_Cod_Carrinho.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Lbl_Cod_Carrinho.Click += new System.EventHandler(this.label4_Click);
            // 
            // Lbl_Situacao_Carrinho
            // 
            this.Lbl_Situacao_Carrinho.AutoSize = true;
            this.Lbl_Situacao_Carrinho.Location = new System.Drawing.Point(447, 45);
            this.Lbl_Situacao_Carrinho.Name = "Lbl_Situacao_Carrinho";
            this.Lbl_Situacao_Carrinho.Size = new System.Drawing.Size(61, 13);
            this.Lbl_Situacao_Carrinho.TabIndex = 4;
            this.Lbl_Situacao_Carrinho.Text = "SITUAÇÃO";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(128, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(129, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(292, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(129, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(292, 20);
            this.textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(129, 92);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 8;
            // 
            // Btn_Confirmar
            // 
            this.Btn_Confirmar.Location = new System.Drawing.Point(225, 180);
            this.Btn_Confirmar.Name = "Btn_Confirmar";
            this.Btn_Confirmar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Confirmar.TabIndex = 9;
            this.Btn_Confirmar.Text = "Confirmar";
            this.Btn_Confirmar.UseVisualStyleBackColor = true;
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(364, 180);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 10;
            this.Btn_Cancelar.Text = "Fechar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(523, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 11;
            // 
            // Frm_Cadastro_Carrinho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(668, 223);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Confirmar);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Lbl_Situacao_Carrinho);
            this.Controls.Add(this.Lbl_Cod_Carrinho);
            this.Controls.Add(this.Lbl_Cod_Congregacao);
            this.Controls.Add(this.Lbl_Nome_Carrinho);
            this.Controls.Add(this.Lbl_Id_Carrinho);
            this.MaximumSize = new System.Drawing.Size(684, 262);
            this.MinimumSize = new System.Drawing.Size(684, 262);
            this.Name = "Frm_Cadastro_Carrinho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Carrinho";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Id_Carrinho;
        private System.Windows.Forms.Label Lbl_Nome_Carrinho;
        private System.Windows.Forms.Label Lbl_Cod_Congregacao;
        private System.Windows.Forms.Label Lbl_Cod_Carrinho;
        private System.Windows.Forms.Label Lbl_Situacao_Carrinho;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button Btn_Confirmar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

