
namespace Slc_Mercado
{
    partial class FLogin
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
            this.login = new System.Windows.Forms.Button();
            this.pass = new System.Windows.Forms.TextBox();
            this.dni = new System.Windows.Forms.TextBox();
            this.registro = new System.Windows.Forms.Button();
            this.configurar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(316, 359);
            this.login.Margin = new System.Windows.Forms.Padding(2);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(111, 46);
            this.login.TabIndex = 0;
            this.login.Text = "Iniciar Sesion";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(374, 295);
            this.pass.Margin = new System.Windows.Forms.Padding(2);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(110, 23);
            this.pass.TabIndex = 1;
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(374, 227);
            this.dni.Margin = new System.Windows.Forms.Padding(2);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(110, 23);
            this.dni.TabIndex = 2;
            // 
            // registro
            // 
            this.registro.Location = new System.Drawing.Point(448, 359);
            this.registro.Margin = new System.Windows.Forms.Padding(2);
            this.registro.Name = "registro";
            this.registro.Size = new System.Drawing.Size(111, 46);
            this.registro.TabIndex = 3;
            this.registro.Text = "Registrarse";
            this.registro.UseVisualStyleBackColor = true;
            this.registro.Click += new System.EventHandler(this.registro_Click);
            // 
            // configurar
            // 
            this.configurar.Location = new System.Drawing.Point(784, 359);
            this.configurar.Margin = new System.Windows.Forms.Padding(2);
            this.configurar.Name = "configurar";
            this.configurar.Size = new System.Drawing.Size(111, 46);
            this.configurar.TabIndex = 4;
            this.configurar.Text = "Configurar";
            this.configurar.UseVisualStyleBackColor = true;
            this.configurar.Visible = false;
            this.configurar.Click += new System.EventHandler(this.configurar_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(371, 198);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ingrese usuario (n° DNI)";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(371, 267);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ingrese contraseña";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(796, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 46);
            this.button1.TabIndex = 7;
            this.button1.Text = "salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 692);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.configurar);
            this.Controls.Add(this.registro);
            this.Controls.Add(this.dni);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLogin";
            this.Load += new System.EventHandler(this.FLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Button registro;
        private System.Windows.Forms.Button configurar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}