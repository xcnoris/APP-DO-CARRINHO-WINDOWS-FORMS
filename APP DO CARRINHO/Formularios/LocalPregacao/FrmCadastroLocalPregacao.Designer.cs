namespace APP_DO_CARRINHO.Formularios.FrmLocalPregacao
{
    partial class FrmCadastroLocalPregacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroLocalPregacao));
            this.Tbc_Cad_Carrinho = new System.Windows.Forms.TabControl();
            this.Btn_Fechar = new System.Windows.Forms.Button();
            this.Btn_Confirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tbc_Cad_Carrinho
            // 
            this.Tbc_Cad_Carrinho.Location = new System.Drawing.Point(12, 12);
            this.Tbc_Cad_Carrinho.MinimumSize = new System.Drawing.Size(503, 286);
            this.Tbc_Cad_Carrinho.Name = "Tbc_Cad_Carrinho";
            this.Tbc_Cad_Carrinho.SelectedIndex = 0;
            this.Tbc_Cad_Carrinho.Size = new System.Drawing.Size(503, 314);
            this.Tbc_Cad_Carrinho.TabIndex = 1;
            // 
            // Btn_Fechar
            // 
            this.Btn_Fechar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Fechar.BackgroundImage")));
            this.Btn_Fechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Fechar.Location = new System.Drawing.Point(271, 339);
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
            this.Btn_Confirmar.Location = new System.Drawing.Point(126, 339);
            this.Btn_Confirmar.Name = "Btn_Confirmar";
            this.Btn_Confirmar.Size = new System.Drawing.Size(118, 32);
            this.Btn_Confirmar.TabIndex = 41;
            this.Btn_Confirmar.Text = "   Confirmar";
            this.Btn_Confirmar.UseVisualStyleBackColor = true;
            this.Btn_Confirmar.Click += new System.EventHandler(this.Btn_Confirmar_Click);
            // 
            // FrmCadastroLocalPregacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 383);
            this.Controls.Add(this.Btn_Fechar);
            this.Controls.Add(this.Btn_Confirmar);
            this.Controls.Add(this.Tbc_Cad_Carrinho);
            this.MaximizeBox = false;
            this.Name = "FrmCadastroLocalPregacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Local Pregação";
            this.Load += new System.EventHandler(this.FrmCadastroLocalPregacao_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tbc_Cad_Carrinho;
        private System.Windows.Forms.Button Btn_Fechar;
        private System.Windows.Forms.Button Btn_Confirmar;
    }
}