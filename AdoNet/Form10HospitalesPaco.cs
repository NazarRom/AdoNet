using AdoNet.Models;
using AdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet
{
    public partial class Form10HospitalesPaco : Form
    {
        private RepositoryHospital repo;
        public Form10HospitalesPaco()
        {
            InitializeComponent();
            this.repo = new RepositoryHospital();
            this.LoadHospitales();
        }

        private void LoadHospitales()
        {
            List<string> hospitales = this.repo.GetHopsitales();
            foreach (string hospital in hospitales)
            {
                this.cmbHospitales.Items.Add(hospital);
            }
        }

        private void cmbHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbHospitales.SelectedIndex != -1)
            {
                string nombreHospital = this.cmbHospitales.SelectedItem.ToString();
                DatosHopsital datos = this.repo.GetDatosHospital(nombreHospital);
                this.lstEmpleados.Items.Clear();
                foreach( EmpleadoHospital empleado in datos.Empleados)
                {
                    this.lstEmpleados.Items.Add(empleado.Apellido + " - " + empleado.Salario);
                }

                this.txtSuma.Text = datos.SumaSalarial.ToString();
                this.txtMedia.Text = datos.MediaSalarial.ToString();
                this.txtPersonas.Text = datos.Personas.ToString();

            }
        }
    }
}
