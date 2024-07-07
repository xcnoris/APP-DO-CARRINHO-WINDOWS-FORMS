namespace APP_DO_CARRINHO.Formularios.Agendamento
{
    partial class Frm_CadastroAgendamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CadastroAgendamento));
            this.Tbc_Cad_Agendamento = new System.Windows.Forms.TabControl();
            this.Btn_Fechar = new System.Windows.Forms.Button();
            this.Btn_Confirmar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tbc_Cad_Agendamento
            // 
            this.Tbc_Cad_Agendamento.Location = new System.Drawing.Point(14, 33);
            this.Tbc_Cad_Agendamento.Name = "Tbc_Cad_Agendamento";
            this.Tbc_Cad_Agendamento.SelectedIndex = 0;
            this.Tbc_Cad_Agendamento.Size = new System.Drawing.Size(681, 477);
            this.Tbc_Cad_Agendamento.TabIndex = 1;
            // 
            // Btn_Fechar
            // 
            this.Btn_Fechar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Btn_Fechar.BackgroundImage")));
            this.Btn_Fechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Btn_Fechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Fechar.Location = new System.Drawing.Point(351, 16);
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
            this.Btn_Confirmar.Location = new System.Drawing.Point(227, 16);
            this.Btn_Confirmar.Name = "Btn_Confirmar";
            this.Btn_Confirmar.Size = new System.Drawing.Size(118, 32);
            this.Btn_Confirmar.TabIndex = 41;
            this.Btn_Confirmar.Text = "   Confirmar";
            this.Btn_Confirmar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.Btn_Fechar);
            this.panel1.Controls.Add(this.Btn_Confirmar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 520);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 60);
            this.panel1.TabIndex = 43;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(575, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 32);
            this.button1.TabIndex = 44;
            this.button1.Text = "   Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(451, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 32);
            this.button2.TabIndex = 45;
            this.button2.Text = "   Confirmar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Frm_CadastroAgendamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 580);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Tbc_Cad_Agendamento);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(723, 619);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(723, 619);
            this.Name = "Frm_CadastroAgendamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_CadastroAgendamento";
            this.Load += new System.EventHandler(this.Frm_CadastroAgendamento_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tbc_Cad_Agendamento;
        private System.Windows.Forms.Button Btn_Fechar;
        private System.Windows.Forms.Button Btn_Confirmar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}