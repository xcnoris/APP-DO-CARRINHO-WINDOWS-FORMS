namespace APP_DO_CARRINHO.Formularios.User
{
    partial class Frm_Tela_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Tela_User));
            this.DGV_Dados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Filtrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Nome = new System.Windows.Forms.TextBox();
            this.Txt_Login = new System.Windows.Forms.TextBox();
            this.Cbox_Situacao = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cbox_TipoUser = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.c = new System.Windows.Forms.Button();
            this.Btn_Excluir_User = new System.Windows.Forms.Button();
            this.Btn_Alterar_User = new System.Windows.Forms.Button();
            this.Btn_Incluir_User = new System.Windows.Forms.Button();
            this.Txt_ID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Dados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_Dados
            // 
            this.DGV_Dados.AllowUserToAddRows = false;
            this.DGV_Dados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Dados.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Dados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Dados.Location = new System.Drawing.Point(12, 134);
            this.DGV_Dados.Name = "DGV_Dados";
            this.DGV_Dados.Size = new System.Drawing.Size(695, 262);
            this.DGV_Dados.TabIndex = 0;
            this.DGV_Dados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Dados_CellContentClick);
            this.DGV_Dados.DoubleClick += new System.EventHandler(this.DGV_Dados_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome";
            // 
            // Btn_Filtrar
            // 
            this.Btn_Filtrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Filtrar.Location = new System.Drawing.Point(562, 83);
            this.Btn_Filtrar.Name = "Btn_Filtrar";
            this.Btn_Filtrar.Size = new System.Drawing.Size(117, 23);
            this.Btn_Filtrar.TabIndex = 6;
            this.Btn_Filtrar.Text = "Filtrar ( Enter )";
            this.Btn_Filtrar.UseVisualStyleBackColor = true;
            this.Btn_Filtrar.Click += new System.EventHandler(this.Btn_Filtrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Login";
            // 
            // Txt_Nome
            // 
            this.Txt_Nome.Location = new System.Drawing.Point(68, 54);
            this.Txt_Nome.Name = "Txt_Nome";
            this.Txt_Nome.Size = new System.Drawing.Size(206, 20);
            this.Txt_Nome.TabIndex = 8;
            // 
            // Txt_Login
            // 
            this.Txt_Login.Location = new System.Drawing.Point(68, 80);
            this.Txt_Login.Name = "Txt_Login";
            this.Txt_Login.Size = new System.Drawing.Size(206, 20);
            this.Txt_Login.TabIndex = 9;
            // 
            // Cbox_Situacao
            // 
            this.Cbox_Situacao.FormattingEnabled = true;
            this.Cbox_Situacao.Location = new System.Drawing.Point(350, 26);
            this.Cbox_Situacao.Name = "Cbox_Situacao";
            this.Cbox_Situacao.Size = new System.Drawing.Size(121, 21);
            this.Cbox_Situacao.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Txt_ID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Cbox_TipoUser);
            this.groupBox1.Controls.Add(this.Txt_Nome);
            this.groupBox1.Controls.Add(this.Cbox_Situacao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Txt_Login);
            this.groupBox1.Controls.Add(this.Btn_Filtrar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 116);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Situacao";
            // 
            // Cbox_TipoUser
            // 
            this.Cbox_TipoUser.FormattingEnabled = true;
            this.Cbox_TipoUser.Location = new System.Drawing.Point(350, 56);
            this.Cbox_TipoUser.Name = "Cbox_TipoUser";
            this.Cbox_TipoUser.Size = new System.Drawing.Size(121, 21);
            this.Cbox_TipoUser.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(607, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 14;
            this.button1.Text = "Fechar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // c
            // 
            this.c.BackgroundImage = global::APP_DO_CARRINHO.Properties.Resources.chaves;
            this.c.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.c.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c.Location = new System.Drawing.Point(475, 402);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(126, 32);
            this.c.TabIndex = 58;
            this.c.Text = "Criar senha";
            this.c.UseVisualStyleBackColor = true;
            this.c.Click += new System.EventHandler(this.c_Click);
            // 
            // Btn_Excluir_User
            // 
            this.Btn_Excluir_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Excluir_User.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Excluir_User.BackgroundImage")));
            this.Btn_Excluir_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Excluir_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Excluir_User.Location = new System.Drawing.Point(224, 402);
            this.Btn_Excluir_User.Name = "Btn_Excluir_User";
            this.Btn_Excluir_User.Size = new System.Drawing.Size(100, 32);
            this.Btn_Excluir_User.TabIndex = 13;
            this.Btn_Excluir_User.Text = "Excluir";
            this.Btn_Excluir_User.UseVisualStyleBackColor = true;
            this.Btn_Excluir_User.Click += new System.EventHandler(this.Btn_Excluir_User_Click);
            // 
            // Btn_Alterar_User
            // 
            this.Btn_Alterar_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Alterar_User.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Alterar_User.BackgroundImage")));
            this.Btn_Alterar_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Alterar_User.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Alterar_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Alterar_User.Location = new System.Drawing.Point(118, 402);
            this.Btn_Alterar_User.Name = "Btn_Alterar_User";
            this.Btn_Alterar_User.Size = new System.Drawing.Size(100, 32);
            this.Btn_Alterar_User.TabIndex = 12;
            this.Btn_Alterar_User.Text = "  Alterar";
            this.Btn_Alterar_User.UseVisualStyleBackColor = true;
            this.Btn_Alterar_User.Click += new System.EventHandler(this.Btn_Alterar_User_Click);
            // 
            // Btn_Incluir_User
            // 
            this.Btn_Incluir_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Incluir_User.BackgroundImage = global::APP_DO_CARRINHO.Properties.Resources.adicionar__2_;
            this.Btn_Incluir_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Incluir_User.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Incluir_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Incluir_User.Location = new System.Drawing.Point(12, 402);
            this.Btn_Incluir_User.Name = "Btn_Incluir_User";
            this.Btn_Incluir_User.Size = new System.Drawing.Size(100, 32);
            this.Btn_Incluir_User.TabIndex = 11;
            this.Btn_Incluir_User.Text = "   Incluir";
            this.Btn_Incluir_User.UseVisualStyleBackColor = true;
            this.Btn_Incluir_User.Click += new System.EventHandler(this.Btn_Incluir_User_Click);
            // 
            // Txt_ID
            // 
            this.Txt_ID.Location = new System.Drawing.Point(68, 26);
            this.Txt_ID.Name = "Txt_ID";
            this.Txt_ID.Size = new System.Drawing.Size(105, 20);
            this.Txt_ID.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Id";
            // 
            // Frm_Tela_User
            // 
            this.AcceptButton = this.Btn_Filtrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 446);
            this.Controls.Add(this.c);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Btn_Excluir_User);
            this.Controls.Add(this.Btn_Alterar_User);
            this.Controls.Add(this.Btn_Incluir_User);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGV_Dados);
            this.MaximizeBox = false;
            this.Name = "Frm_Tela_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Frm_Tela_User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Dados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Dados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Filtrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Nome;
        private System.Windows.Forms.TextBox Txt_Login;
        private System.Windows.Forms.ComboBox Cbox_Situacao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Incluir_User;
        private System.Windows.Forms.Button Btn_Alterar_User;
        private System.Windows.Forms.Button Btn_Excluir_User;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Cbox_TipoUser;
        private System.Windows.Forms.Button c;
        private System.Windows.Forms.TextBox Txt_ID;
        private System.Windows.Forms.Label label5;
    }
}