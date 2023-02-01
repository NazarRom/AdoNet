﻿using System;
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
                string nombreOficio = this.cmbOficios.SelectedItem.ToString();
                List<Empleado> empleados = this.repo.GetEmpleadosDatos(nombreOficio);
                this.lstvEmpleados.Items.Clear();
                foreach(Empleado empleado in empleados)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = empleado.Apellido.ToString();
                    item.SubItems.Add(empleado.Oficio.ToString());
                    item.SubItems.Add(empleado.Salario.ToString());
                    item.SubItems.Add(empleado.IdEmpleado.ToString());//SI NO HAY COLUMNA NO HAY DIBUJO
                    this.lstvEmpleados.Items.Add(item);
                }


            }
        }

        private void ListaEmpleados() { }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.lstvEmpleados.SelectedItems[0].SubItems[3].Text);
            int borrados = this.repo.DeleteEmpleado(id);
            MessageBox.Show("borrados" + borrados);
            
        }
    }
}
