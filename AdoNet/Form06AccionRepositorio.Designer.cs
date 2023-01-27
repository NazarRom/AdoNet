namespace AdoNet
{
    partial class Form06AccionRepositorio
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
            this.lstDepartamentos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.bntInseratr = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.bntBorrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstDepartamentos
            // 
            this.lstDepartamentos.FormattingEnabled = true;
            this.lstDepartamentos.ItemHeight = 15;
            this.lstDepartamentos.Location = new System.Drawing.Point(74, 135);
            this.lstDepartamentos.Name = "lstDepartamentos";
            this.lstDepartamentos.Size = new System.Drawing.Size(120, 184);
            this.lstDepartamentos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Departamentos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(244, 91);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 23);
            this.txtId.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(244, 183);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 23);
            this.txtNombre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Localidad";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(248, 296);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 23);
            this.txtLocalidad.TabIndex = 7;
            // 
            // bntInseratr
            // 
            this.bntInseratr.Location = new System.Drawing.Point(396, 136);
            this.bntInseratr.Name = "bntInseratr";
            this.bntInseratr.Size = new System.Drawing.Size(75, 23);
            this.bntInseratr.TabIndex = 8;
            this.bntInseratr.Text = "Insertar";
            this.bntInseratr.UseVisualStyleBackColor = true;
            this.bntInseratr.Click += new System.EventHandler(this.bntInseratr_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(396, 206);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // bntBorrar
            // 
            this.bntBorrar.Location = new System.Drawing.Point(396, 277);
            this.bntBorrar.Name = "bntBorrar";
            this.bntBorrar.Size = new System.Drawing.Size(75, 23);
            this.bntBorrar.TabIndex = 10;
            this.bntBorrar.Text = "Borrar";
            this.bntBorrar.UseVisualStyleBackColor = true;
            this.bntBorrar.Click += new System.EventHandler(this.bntBorrar_Click);
            // 
            // Form06AccionRepositorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntBorrar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.bntInseratr);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstDepartamentos);
            this.Name = "Form06AccionRepositorio";
            this.Text = "Form06AccionRepositorio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstDepartamentos;
        private Label label1;
        private Label label2;
        private TextBox txtId;
        private Label label3;
        private TextBox txtNombre;
        private Label label4;
        private TextBox txtLocalidad;
        private Button bntInseratr;
        private Button btnModificar;
        private Button bntBorrar;
    }
}