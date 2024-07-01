namespace APP_DO_CARRINHO.Formularios.User
{
    partial class Frm_Cadastro_Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Cadastro_Usuario));
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Nome = new System.Windows.Forms.TextBox();
            this.Btn_Fechar = new System.Windows.Forms.Button();
            this.Btn_Confirmar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_Id = new System.Windows.Forms.TextBox();
            this.Txt_Login = new System.Windows.Forms.TextBox();
            this.MSK_CPF = new System.Windows.Forms.MaskedTextBox();
            this.Cbox_Situacao = new System.Windows.Forms.ComboBox();
            this.Lbl_Situacao_Carrinho = new System.Windows.Forms.Label();
            this.Cbox_Tipo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // Txt_Nome
            // 
            this.Txt_Nome.Location = new System.Drawing.Point(99, 97);
            this.Txt_Nome.Name = "Txt_Nome";
            this.Txt_Nome.Size = new System.Drawing.Size(316, 20);
            this.Txt_Nome.TabIndex = 1;
            // 
            // Btn_Fechar
            // 
            this.Btn_Fechar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Fechar.BackgroundImage")));
            this.Btn_Fechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Fechar.Location = new System.Drawing.Point(245, 289);
            this.Btn_Fechar.MaximumSize = new System.Drawing.Size(118, 32);
            this.Btn_Fechar.MinimumSize = new System.Drawing.Size(118, 32);
            this.Btn_Fechar.Name = "Btn_Fechar";
            this.Btn_Fechar.Size = new System.Drawing.Size(118, 32);
            this.Btn_Fechar.TabIndex = 42;
            this.Btn_Fechar.Text = "  Cancelar";
            this.Btn_Fechar.UseVisualStyleBackColor = true;
            this.Btn_Fechar.Click += new System.EventHandler(this.Btn_Fechar_Click);
            // 
            // Btn_Confirmar
            // 
            this.Btn_Confirmar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Confirmar.BackgroundImage")));
            this.Btn_Confirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Confirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Confirmar.Location = new System.Drawing.Point(102, 289);
            this.Btn_Confirmar.Name = "Btn_Confirmar";
            this.Btn_Confirmar.Size = new System.Drawing.Size(118, 32);
            this.Btn_Confirmar.TabIndex = 41;
            this.Btn_Confirmar.Text = "   Confirmar";
            this.Btn_Confirmar.UseVisualStyleBackColor = true;
            this.Btn_Confirmar.Click += new System.EventHandler(this.Btn_Confirmar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(23, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "CPF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(23, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Nome";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(23, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.LimeGreen;
            this.label5.Location = new System.Drawing.Point(23, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Login";
            // 
            // Txt_Id
            // 
            this.Txt_Id.Location = new System.Drawing.Point(99, 28);
            this.Txt_Id.Name = "Txt_Id";
            this.Txt_Id.ReadOnly = true;
            this.Txt_Id.Size = new System.Drawing.Size(74, 20);
            this.Txt_Id.TabIndex = 48;
            // 
            // Txt_Login
            // 
            this.Txt_Login.Location = new System.Drawing.Point(99, 165);
            this.Txt_Login.Name = "Txt_Login";
            this.Txt_Login.Size = new System.Drawing.Size(168, 20);
            this.Txt_Login.TabIndex = 51;
            // 
            // MSK_CPF
            // 
            this.MSK_CPF.Location = new System.Drawing.Point(99, 63);
            this.MSK_CPF.Mask = "000,000,000-00";
            this.MSK_CPF.Name = "MSK_CPF";
            this.MSK_CPF.Size = new System.Drawing.Size(89, 20);
            this.MSK_CPF.TabIndex = 53;
            this.MSK_CPF.ValidatingType = typeof(System.DateTime);
            // 
            // Cbox_Situacao
            // 
            this.Cbox_Situacao.FormattingEnabled = true;
            this.Cbox_Situacao.Items.AddRange(new object[] {
            " "});
            this.Cbox_Situacao.Location = new System.Drawing.Point(294, 31);
            this.Cbox_Situacao.Name = "Cbox_Situacao";
            this.Cbox_Situacao.Size = new System.Drawing.Size(121, 21);
            this.Cbox_Situacao.TabIndex = 54;
            this.Cbox_Situacao.Text = "( Selecione )";
            // 
            // Lbl_Situacao_Carrinho
            // 
            this.Lbl_Situacao_Carrinho.AutoSize = true;
            this.Lbl_Situacao_Carrinho.ForeColor = System.Drawing.Color.LimeGreen;
            this.Lbl_Situacao_Carrinho.Location = new System.Drawing.Point(218, 34);
            this.Lbl_Situacao_Carrinho.Name = "Lbl_Situacao_Carrinho";
            this.Lbl_Situacao_Carrinho.Size = new System.Drawing.Size(61, 13);
            this.Lbl_Situacao_Carrinho.TabIndex = 55;
            this.Lbl_Situacao_Carrinho.Text = "SITUAÇÃO";
            // 
            // Cbox_Tipo
            // 
            this.Cbox_Tipo.FormattingEnabled = true;
            this.Cbox_Tipo.Items.AddRange(new object[] {
            " "});
            this.Cbox_Tipo.Location = new System.Drawing.Point(99, 130);
            this.Cbox_Tipo.Name = "Cbox_Tipo";
            this.Cbox_Tipo.Size = new System.Drawing.Size(168, 21);
            this.Cbox_Tipo.TabIndex = 56;
            this.Cbox_Tipo.Text = "( Selecione )";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(99, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 27);
            this.button1.TabIndex = 57;
            this.button1.Text = "Redefinir Senha";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Cbox_Tipo);
            this.groupBox1.Controls.Add(this.Txt_Nome);
            this.groupBox1.Controls.Add(this.Cbox_Situacao);
            this.groupBox1.Controls.Add(this.Lbl_Situacao_Carrinho);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.MSK_CPF);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Txt_Login);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Txt_Id);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 260);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro User";
            // 
            // Frm_Cadastro_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 330);
            this.Controls.Add(this.Btn_Fechar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Btn_Confirmar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(485, 369);
            this.MinimumSize = new System.Drawing.Size(485, 369);
            this.Name = "Frm_Cadastro_Usuario";
            this.Text = "Frm_Cadastro_Usuario";
            this.Load += new System.EventHandler(this.Frm_Cadastro_Usuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Nome;
        private System.Windows.Forms.Button Btn_Fechar;
        private System.Windows.Forms.Button Btn_Confirmar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txt_Id;
        private System.Windows.Forms.TextBox Txt_Login;
        private System.Windows.Forms.MaskedTextBox MSK_CPF;
        private System.Windows.Forms.ComboBox Cbox_Situacao;
        private System.Windows.Forms.Label Lbl_Situacao_Carrinho;
        private System.Windows.Forms.ComboBox Cbox_Tipo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}