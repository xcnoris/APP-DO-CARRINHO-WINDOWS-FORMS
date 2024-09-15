namespace APP_DO_CARRINHO.Formularios.Tela_Login
{
    partial class Frm_Tela_ConexoesDB
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
            this.Lbl_Servidor = new System.Windows.Forms.Label();
            this.Lbl_NomeBD = new System.Windows.Forms.Label();
            this.Lbl_UsuarioBD = new System.Windows.Forms.Label();
            this.Lbl_SenhaBD = new System.Windows.Forms.Label();
            this.Btn_Confirmar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Txt_Servidor = new System.Windows.Forms.TextBox();
            this.Txt_BD = new System.Windows.Forms.TextBox();
            this.Txt_UsuarioBD = new System.Windows.Forms.TextBox();
            this.Txt_SenhaBD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Lbl_Servidor
            // 
            this.Lbl_Servidor.AutoSize = true;
            this.Lbl_Servidor.Location = new System.Drawing.Point(69, 25);
            this.Lbl_Servidor.Name = "Lbl_Servidor";
            this.Lbl_Servidor.Size = new System.Drawing.Size(49, 13);
            this.Lbl_Servidor.TabIndex = 0;
            this.Lbl_Servidor.Text = "Servidor:";
            // 
            // Lbl_NomeBD
            // 
            this.Lbl_NomeBD.AutoSize = true;
            this.Lbl_NomeBD.Location = new System.Drawing.Point(28, 51);
            this.Lbl_NomeBD.Name = "Lbl_NomeBD";
            this.Lbl_NomeBD.Size = new System.Drawing.Size(90, 13);
            this.Lbl_NomeBD.TabIndex = 1;
            this.Lbl_NomeBD.Text = "Banco de Dados:";
            // 
            // Lbl_UsuarioBD
            // 
            this.Lbl_UsuarioBD.AutoSize = true;
            this.Lbl_UsuarioBD.Location = new System.Drawing.Point(54, 77);
            this.Lbl_UsuarioBD.Name = "Lbl_UsuarioBD";
            this.Lbl_UsuarioBD.Size = new System.Drawing.Size(64, 13);
            this.Lbl_UsuarioBD.TabIndex = 2;
            this.Lbl_UsuarioBD.Text = "Usuário BD:";
            // 
            // Lbl_SenhaBD
            // 
            this.Lbl_SenhaBD.AutoSize = true;
            this.Lbl_SenhaBD.Location = new System.Drawing.Point(59, 103);
            this.Lbl_SenhaBD.Name = "Lbl_SenhaBD";
            this.Lbl_SenhaBD.Size = new System.Drawing.Size(59, 13);
            this.Lbl_SenhaBD.TabIndex = 3;
            this.Lbl_SenhaBD.Text = "Senha BD:";
            // 
            // Btn_Confirmar
            // 
            this.Btn_Confirmar.Location = new System.Drawing.Point(72, 146);
            this.Btn_Confirmar.Name = "Btn_Confirmar";
            this.Btn_Confirmar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Confirmar.TabIndex = 4;
            this.Btn_Confirmar.Text = "Confirmar";
            this.Btn_Confirmar.UseVisualStyleBackColor = true;
            this.Btn_Confirmar.Click += new System.EventHandler(this.Btn_Confirmar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.Location = new System.Drawing.Point(185, 146);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancelar.TabIndex = 5;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = true;
            // 
            // Txt_Servidor
            // 
            this.Txt_Servidor.Location = new System.Drawing.Point(124, 22);
            this.Txt_Servidor.Name = "Txt_Servidor";
            this.Txt_Servidor.Size = new System.Drawing.Size(171, 20);
            this.Txt_Servidor.TabIndex = 6;
            // 
            // Txt_BD
            // 
            this.Txt_BD.Location = new System.Drawing.Point(124, 48);
            this.Txt_BD.Name = "Txt_BD";
            this.Txt_BD.Size = new System.Drawing.Size(171, 20);
            this.Txt_BD.TabIndex = 7;
            // 
            // Txt_UsuarioBD
            // 
            this.Txt_UsuarioBD.Location = new System.Drawing.Point(124, 74);
            this.Txt_UsuarioBD.Name = "Txt_UsuarioBD";
            this.Txt_UsuarioBD.Size = new System.Drawing.Size(171, 20);
            this.Txt_UsuarioBD.TabIndex = 8;
            // 
            // Txt_SenhaBD
            // 
            this.Txt_SenhaBD.Location = new System.Drawing.Point(124, 100);
            this.Txt_SenhaBD.Name = "Txt_SenhaBD";
            this.Txt_SenhaBD.Size = new System.Drawing.Size(171, 20);
            this.Txt_SenhaBD.TabIndex = 9;
            // 
            // Frm_Tela_ConexoesDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(324, 181);
            this.Controls.Add(this.Txt_SenhaBD);
            this.Controls.Add(this.Txt_UsuarioBD);
            this.Controls.Add(this.Txt_BD);
            this.Controls.Add(this.Txt_Servidor);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Confirmar);
            this.Controls.Add(this.Lbl_SenhaBD);
            this.Controls.Add(this.Lbl_UsuarioBD);
            this.Controls.Add(this.Lbl_NomeBD);
            this.Controls.Add(this.Lbl_Servidor);
            this.MaximizeBox = false;
            this.Name = "Frm_Tela_ConexoesDB";
            this.Text = "Conexão";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Servidor;
        private System.Windows.Forms.Label Lbl_NomeBD;
        private System.Windows.Forms.Label Lbl_UsuarioBD;
        private System.Windows.Forms.Label Lbl_SenhaBD;
        private System.Windows.Forms.Button Btn_Confirmar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.TextBox Txt_Servidor;
        private System.Windows.Forms.TextBox Txt_BD;
        private System.Windows.Forms.TextBox Txt_UsuarioBD;
        private System.Windows.Forms.TextBox Txt_SenhaBD;
    }
}