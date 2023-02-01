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
    public partial class FormRepasoDoctores : Form
    {
        RepositoryDoctor repo;
        public FormRepasoDoctores()
        {
            InitializeComponent();
            this.repo = new RepositoryDoctor();
            this.LoadEspecialidad();
        }

        private void LoadEspecialidad()
        {
            List<string> especialidades = this.repo.LoadEspecialidad();
            foreach(string especialidad in especialidades)
            {
                this.cmbEspecialidad.Items.Add(especialidad);
            }

        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbEspecialidad.SelectedIndex != -1)
            {
                string nombre = this.cmbEspecialidad.SelectedItem.ToString();
                List<Doctor> doctores = this.repo.LoadDoctores(nombre);
                this.lstvDoctores.Items.Clear();
                foreach(Doctor doctor in doctores)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = doctor.Apllido.ToString();
                    item.SubItems.Add(doctor.Especialidad.ToString());
                    item.SubItems.Add(doctor.Salario.ToString());
                    item.SubItems.Add(doctor.IdDoctor.ToString());
                    this.lstvDoctores.Items.Add(item);
                }

                DatosDoctor datos = this.repo.GetCalculo(nombre);
                this.txtSuma.Text = datos.Suma.ToString();
                this.txtMedia.Text = datos.Media.ToString();
                this.txtPersonas.Text = datos.Personas.ToString();
            }
        }
    }
}
