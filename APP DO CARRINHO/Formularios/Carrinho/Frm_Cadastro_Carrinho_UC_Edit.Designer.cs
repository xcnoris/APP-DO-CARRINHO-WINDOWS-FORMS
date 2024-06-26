namespace APP_DO_CARRINHO.Formularios.Carrinho
{
    partial class Frm_Cadastro_Carrinho_UC_Edit
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
            this.Tbc_Cad_Carrinho = new System.Windows.Forms.TabControl();
            this.Btn_Fechar = new System.Windows.Forms.Button();
            this.Btn_Salvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tbc_Cad_Carrinho
            // 
            this.Tbc_Cad_Carrinho.Dock = System.Windows.Forms.DockStyle.Top;
            this.Tbc_Cad_Carrinho.Location = new System.Drawing.Point(0, 0);
            this.Tbc_Cad_Carrinho.Name = "Tbc_Cad_Carrinho";
            this.Tbc_Cad_Carrinho.SelectedIndex = 0;
            this.Tbc_Cad_Carrinho.Size = new System.Drawing.Size(684, 192);
            this.Tbc_Cad_Carrinho.TabIndex = 0;
            // 
            // Btn_Fechar
            // 
            this.Btn_Fechar.Location = new System.Drawing.Point(356, 200);
            this.Btn_Fechar.Name = "Btn_Fechar";
            this.Btn_Fechar.Size = new System.Drawing.Size(88, 31);
            this.Btn_Fechar.TabIndex = 40;
            this.Btn_Fechar.Text = "Fechar";
            this.Btn_Fechar.UseVisualStyleBackColor = true;
            this.Btn_Fechar.Click += new System.EventHandler(this.Btn_Fechar_Click);
            // 
            // Btn_Salvar
            // 
            this.Btn_Salvar.Location = new System.Drawing.Point(237, 200);
            this.Btn_Salvar.Name = "Btn_Salvar";
            this.Btn_Salvar.Size = new System.Drawing.Size(88, 31);
            this.Btn_Salvar.TabIndex = 39;
            this.Btn_Salvar.Text = "Salvar";
            this.Btn_Salvar.UseVisualStyleBackColor = true;
            this.Btn_Salvar.Click += new System.EventHandler(this.Btn_Confirmar_Click);
            // 
            // Frm_Cadastro_Carrinho_UC_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 244);
            this.Controls.Add(this.Btn_Fechar);
            this.Controls.Add(this.Btn_Salvar);
            this.Controls.Add(this.Tbc_Cad_Carrinho);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 283);
            this.MinimumSize = new System.Drawing.Size(700, 283);
            this.Name = "Frm_Cadastro_Carrinho_UC_Edit";
            this.Text = "Cadadastro Carrinho";
            this.Load += new System.EventHandler(this.Frm_Cadastro_Carrinho_UC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tbc_Cad_Carrinho;
        private System.Windows.Forms.Button Btn_Fechar;
        private System.Windows.Forms.Button Btn_Salvar;
    }
}