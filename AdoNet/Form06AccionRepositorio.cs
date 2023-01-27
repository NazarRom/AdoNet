using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNet.Repositories;
using AdoNet.Models;
namespace AdoNet
{
    public partial class Form06AccionRepositorio : Form
    {
        RepositoryDepartamentos repo;
        List<Departamento> departamentos;
        public Form06AccionRepositorio()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentos();
            this.LoadDepartamentos();
            
        }
        private void LoadDepartamentos()
        {
            this.departamentos = this.repo.GetDepartamentos();
            this.lstDepartamentos.Items.Clear();
           for (int i = 0; i < this.departamentos.Count; i++)
            {
                this.lstDepartamentos.Items.Add(this.departamentos[i].Nombre + " - " + this.departamentos[i].IdDepartamento);
                
            } 

        }
        private void bntInseratr_Click(object sender, EventArgs e)
        {
            this.lstDepartamentos.Items.Clear();
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;

            this.repo.InsertDepartamento(id, nombre, localidad);
            this.LoadDepartamentos();

            this.txtId.Clear();
            this.txtNombre.Clear();
            this.txtLocalidad.Clear();


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int index = this.lstDepartamentos.SelectedIndex;
            int id = this.departamentos[index].IdDepartamento;
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;

            this.repo.UpdateDepartamneto(id, nombre, localidad);
            this.LoadDepartamentos();

            this.txtId.Clear();
            this.txtNombre.Clear();
            this.txtLocalidad.Clear();
        }

        private void bntBorrar_Click(object sender, EventArgs e)
        {   
            int index = this.lstDepartamentos.SelectedIndex;
            int id = this.departamentos[index].IdDepartamento;
            this.repo.DeleteDepartamento(id);
            this.LoadDepartamentos();
        }
    }
}
