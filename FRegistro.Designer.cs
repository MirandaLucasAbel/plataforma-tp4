using System;

namespace Slc_Mercado
{
    partial class FRegistro
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblTipoUsuario = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.TextBox();
            this.dni = new System.Windows.Forms.TextBox();
            this.nombre_ = new System.Windows.Forms.TextBox();
            this.apellido_ = new System.Windows.Forms.TextBox();
            this.tipoUsuario = new System.Windows.Forms.ComboBox();
            this.registrarUsuario = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            this.cuit = new System.Windows.Forms.TextBox();
            this.lblCuil_cuit = new System.Windows.Forms.Label();
            this.mail_ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Location = new System.Drawing.Point(50, 43);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(117, 27);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "Registro de Usuario";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(50, 115);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(117, 27);
            this.lblNombre.TabIndex = 11;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.Location = new System.Drawing.Point(50, 188);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(117, 27);
            this.lblApellido.TabIndex = 10;
            this.lblApellido.Text = "Apellido";
            // 
            // lblDNI
            // 
            this.lblDNI.Location = new System.Drawing.Point(50, 260);
            this.lblDNI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(253, 27);
            this.lblDNI.TabIndex = 9;
            this.lblDNI.Text = "DNI";
            // 
            // lblTipoUsuario
            // 
            this.lblTipoUsuario.Location = new System.Drawing.Point(359, 188);
            this.lblTipoUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoUsuario.Name = "lblTipoUsuario";
            this.lblTipoUsuario.Size = new System.Drawing.Size(240, 27);
            this.lblTipoUsuario.TabIndex = 8;
            this.lblTipoUsuario.Text = "Seleccione el tipo de usuario:";
            // 
            // lblPwd
            // 
            this.lblPwd.Location = new System.Drawing.Point(359, 256);
            this.lblPwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(359, 27);
            this.lblPwd.TabIndex = 7;
            this.lblPwd.Text = "Ingrese la contraseña";
            // 
            // lblMail
            // 
            this.lblMail.Location = new System.Drawing.Point(250, 466);
            this.lblMail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(117, 27);
            this.lblMail.TabIndex = 5;
            // 
            // pass
            // 
            this.pass.Location = new System.Drawing.Point(581, 256);
            this.pass.Margin = new System.Windows.Forms.Padding(2);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(116, 23);
            this.pass.TabIndex = 0;
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(148, 256);
            this.dni.Margin = new System.Windows.Forms.Padding(2);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(116, 23);
            this.dni.TabIndex = 0;
            // 
            // nombre_
            // 
            this.nombre_.Location = new System.Drawing.Point(148, 112);
            this.nombre_.Margin = new System.Windows.Forms.Padding(2);
            this.nombre_.Name = "nombre_";
            this.nombre_.Size = new System.Drawing.Size(116, 23);
            this.nombre_.TabIndex = 0;
            // 
            // apellido_
            // 
            this.apellido_.Location = new System.Drawing.Point(148, 183);
            this.apellido_.Margin = new System.Windows.Forms.Padding(2);
            this.apellido_.Name = "apellido_";
            this.apellido_.Size = new System.Drawing.Size(116, 23);
            this.apellido_.TabIndex = 0;
            // 
            // tipoUsuario
            // 
            this.tipoUsuario.Items.AddRange(new object[] {
            "Cliente Final",
            "Empresa"});
            this.tipoUsuario.Location = new System.Drawing.Point(581, 183);
            this.tipoUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tipoUsuario.Name = "tipoUsuario";
            this.tipoUsuario.Size = new System.Drawing.Size(116, 23);
            this.tipoUsuario.TabIndex = 4;
            // 
            // registrarUsuario
            // 
            this.registrarUsuario.Location = new System.Drawing.Point(624, 362);
            this.registrarUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.registrarUsuario.Name = "registrarUsuario";
            this.registrarUsuario.Size = new System.Drawing.Size(111, 46);
            this.registrarUsuario.TabIndex = 3;
            this.registrarUsuario.Text = "Registrar Usuario";
            this.registrarUsuario.UseVisualStyleBackColor = true;
            this.registrarUsuario.Click += new System.EventHandler(this.registrarUsuario_Click);
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(489, 362);
            this.volver.Margin = new System.Windows.Forms.Padding(2);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(111, 46);
            this.volver.TabIndex = 3;
            this.volver.Text = "Volver Atrás";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // cuit
            // 
            this.cuit.Location = new System.Drawing.Point(581, 112);
            this.cuit.Margin = new System.Windows.Forms.Padding(2);
            this.cuit.Name = "cuit";
            this.cuit.Size = new System.Drawing.Size(116, 23);
            this.cuit.TabIndex = 14;
            // 
            // lblCuil_cuit
            // 
            this.lblCuil_cuit.Location = new System.Drawing.Point(359, 115);
            this.lblCuil_cuit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCuil_cuit.Name = "lblCuil_cuit";
            this.lblCuil_cuit.Size = new System.Drawing.Size(163, 27);
            this.lblCuil_cuit.TabIndex = 15;
            this.lblCuil_cuit.Text = "Ingrese el CUIT/CUIL";
            // 
            // mail_
            // 
            this.mail_.Location = new System.Drawing.Point(148, 305);
            this.mail_.Margin = new System.Windows.Forms.Padding(2);
            this.mail_.Name = "mail_";
            this.mail_.Size = new System.Drawing.Size(116, 23);
            this.mail_.TabIndex = 16;
            this.mail_.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(50, 308);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 27);
            this.label1.TabIndex = 17;
            this.label1.Text = "mail";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // FRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 523);
            this.Controls.Add(this.mail_);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCuil_cuit);
            this.Controls.Add(this.cuit);
            this.Controls.Add(this.registrarUsuario);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.tipoUsuario);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.dni);
            this.Controls.Add(this.nombre_);
            this.Controls.Add(this.apellido_);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblTipoUsuario);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRegistro";
            this.Load += new System.EventHandler(this.FRegistro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button registrarUsuario;
        private System.Windows.Forms.Button volver;
        private System.Windows.Forms.ComboBox tipoUsuario;
        private System.Windows.Forms.TextBox pass;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.TextBox nombre_;
        private System.Windows.Forms.TextBox apellido_;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Label lblTipoUsuario;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox cuit;
        private System.Windows.Forms.Label lblCuil_cuit;
        private System.Windows.Forms.TextBox mail_;
        private System.Windows.Forms.Label label1;
    }
}