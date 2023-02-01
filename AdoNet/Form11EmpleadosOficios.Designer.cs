namespace AdoNet
{
    partial class Form11EmpleadosOficios
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOficios = new System.Windows.Forms.ComboBox();
            this.lstvEmpleados = new System.Windows.Forms.ListView();
            this.columnApellido = new System.Windows.Forms.ColumnHeader();
            this.columnOficio = new System.Windows.Forms.ColumnHeader();
            this.columnSalario = new System.Windows.Forms.ColumnHeader();
            this.columnId = new System.Windows.Forms.ColumnHeader();
            this.lblEmpleados = new System.Windows.Forms.Label();
            this.txtIncremento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bntIncrementar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oficios";
            // 
            // cmbOficios
            // 
            this.cmbOficios.FormattingEnabled = true;
            this.cmbOficios.Location = new System.Drawing.Point(67, 84);
            this.cmbOficios.Name = "cmbOficios";
            this.cmbOficios.Size = new System.Drawing.Size(121, 23);
            this.cmbOficios.TabIndex = 1;
            this.cmbOficios.SelectedIndexChanged += new System.EventHandler(this.cmbOficios_SelectedIndexChanged);
            // 
            // lstvEmpleados
            // 
            this.lstvEmpleados.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnApellido,
            this.columnOficio,
            this.columnSalario,
            this.columnId});
            this.lstvEmpleados.Location = new System.Drawing.Point(56, 198);
            this.lstvEmpleados.Name = "lstvEmpleados";
            this.lstvEmpleados.Size = new System.Drawing.Size(244, 216);
            this.lstvEmpleados.TabIndex = 2;
            this.lstvEmpleados.UseCompatibleStateImageBehavior = false;
            this.lstvEmpleados.View = System.Windows.Forms.View.Details;
            // 
            // columnApellido
            // 
            this.columnApellido.Text = "Apellido";
            // 
            // columnOficio
            // 
            this.columnOficio.Text = "Oficio";
            // 
            // columnSalario
            // 
            this.columnSalario.Text = "Salario";
            // 
            // columnId
            // 
            this.columnId.Text = "ID";
            // 
            // lblEmpleados
            // 
            this.lblEmpleados.AutoSize = true;
            this.lblEmpleados.Location = new System.Drawing.Point(56, 171);
            this.lblEmpleados.Name = "lblEmpleados";
            this.lblEmpleados.Size = new System.Drawing.Size(65, 15);
            this.lblEmpleados.TabIndex = 3;
            this.lblEmpleados.Text = "Empleados";
            // 
            // txtIncremento
            // 
            this.txtIncremento.Location = new System.Drawing.Point(360, 98);
            this.txtIncremento.Name = "txtIncremento";
            this.txtIncremento.Size = new System.Drawing.Size(100, 23);
            this.txtIncremento.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(360, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Incrementar";
            // 
            // bntIncrementar
            // 
            this.bntIncrementar.Location = new System.Drawing.Point(360, 137);
            this.bntIncrementar.Name = "bntIncrementar";
            this.bntIncrementar.Size = new System.Drawing.Size(100, 23);
            this.bntIncrementar.TabIndex = 6;
            this.bntIncrementar.Text = "Incrementar";
            this.bntIncrementar.UseVisualStyleBackColor = true;
            this.bntIncrementar.Click += new System.EventHandler(this.bntIncrementar_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(360, 242);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(85, 38);
            this.btnMostrar.TabIndex = 7;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(360, 314);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(85, 34);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Form11EmpleadosOficios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.bntIncrementar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIncremento);
            this.Controls.Add(this.lblEmpleados);
            this.Controls.Add(this.lstvEmpleados);
            this.Controls.Add(this.cmbOficios);
            this.Controls.Add(this.label1);
            this.Name = "Form11EmpleadosOficios";
            this.Text = "Form11EmpleadosOficios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cmbOficios;
        private ListView lstvEmpleados;
        private Label lblEmpleados;
        private TextBox txtIncremento;
        private Label label3;
        private Button bntIncrementar;
        private Button btnMostrar;
        private Button btnEliminar;
        private ColumnHeader columnApellido;
        private ColumnHeader columnOficio;
        private ColumnHeader columnSalario;
        private ColumnHeader columnId;
    }
}