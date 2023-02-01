using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNet.Models;
using AdoNet.Repositories;

namespace AdoNet
{
    public partial class Form11EmpleadosOficios : Form
    {
        private RepositoryOficio repo;
        public Form11EmpleadosOficios()
        {
            InitializeComponent();
            this.repo = new RepositoryOficio();
            this.LoadOficios();
            this.LoadTodosEmpleados();
        }

        private void LoadTodosEmpleados()
        {
            List<Empleado> empleados = this.repo.GetAllEmpleados();
            this.lstvEmpleados.Items.Clear();
            foreach (Empleado empleado in empleados)
            {
                ListViewItem item = new ListViewItem();
                item.Text = empleado.Apellido.ToString();
                item.SubItems.Add(empleado.Oficio.ToString());
                item.SubItems.Add(empleado.Salario.ToString());
                this.lstvEmpleados.Items.Add(item);

            }

        }

        private void LoadOficios()
        {
            List<string> oficios = this.repo.GetOficio();
            foreach(string oficio in oficios)
            {
                this.cmbOficios.Items.Add(oficio);
            }
        }

        private void cmbOficios_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(this.cmbOficios.SelectedIndex != -1)
            {
                this.LoadEmpleados();
            }
        }

        private void LoadEmpleados()
        {
            string nombreOficio = this.cmbOficios.SelectedItem.ToString();
            List<Empleado> empleados = this.repo.GetEmpleadosDatos(nombreOficio);
            this.lstvEmpleados.Items.Clear();
            foreach (Empleado empleado in empleados)
            {
                ListViewItem item = new ListViewItem();
                item.Text = empleado.Apellido.ToString();
                item.SubItems.Add(empleado.Oficio.ToString());
                item.SubItems.Add(empleado.Salario.ToString());
                item.SubItems.Add(empleado.IdEmpleado.ToString());//SI NO HAY COLUMNA NO HAY DIBUJO
                this.lstvEmpleados.Items.Add(item);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.lstvEmpleados.SelectedItems[0].SubItems[3].Text);
            this.repo.DeleteEmpleado(id);
            this.LoadEmpleados();

        }

        private void bntIncrementar_Click(object sender, EventArgs e)
        {
            string oficio = this.cmbOficios.SelectedItem.ToString();
            int incremento = int.Parse(this.txtIncremento.Text);
            this.repo.IncrementarSalario(incremento, oficio);
            this.LoadEmpleados();
        }
    }
}
