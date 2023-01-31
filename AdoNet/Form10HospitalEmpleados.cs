using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Numerics;

namespace AdoNet
{
    #region VISTA

//    CREATE VIEW  HOSPITAL_DOC_PLANTILLA
//    AS
//SELECT APELLIDO, SALARIO, HOSPITAL_COD, EMPLEADO_NO  FROM PLANTILLA
//UNION
//SELECT APELLIDO, SALARIO, HOSPITAL_COD, DOCTOR_NO FROM DOCTOR
//GO

    #endregion
    public partial class Form10HospitalEmpleados : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        List<int> listaIdHospital;

        public Form10HospitalEmpleados()
        {
            InitializeComponent();
            this.listaIdHospital = new List<int>();
            string connectionString =
                @"Data Source=.\SQLEXPRESS;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadHospitales();
        }

        private void LoadHospitales()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_HOSPITALES";

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cmbHospitales.Items.Clear();
            while (this.reader.Read())
            {
                int id = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                string nombre = this.reader["NOMBRE"].ToString();
                this.cmbHospitales.Items.Add(nombre);
                this.listaIdHospital.Add(id);
            }
            this.cn.Close();
            this.reader.Close();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int index = this.cmbHospitales.SelectedIndex;
            int idHospital = this.listaIdHospital[index];

            SqlParameter pamid = new SqlParameter("@id", idHospital);
            this.com.Parameters.Add(pamid);
            //declaramos los parametros de salida

            SqlParameter pamsuma = new SqlParameter("SUMA",0);
            pamsuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamsuma);

            SqlParameter pammedia = new SqlParameter("@MEDIA", 0);
            pammedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pammedia);

            SqlParameter pampersonas = new SqlParameter("@PERSONAS",0);
            pampersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pampersonas);

            //LO DE COMMANTYPE Y LO DEMÁS
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_EMPLEADOS_HOSPITAL";
            //conexin

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                int salario = int.Parse(this.reader["SALARIO"].ToString());
                this.lstEmpleados.Items.Add(apellido + " - " + salario);

            }
            this.reader.Close();

            this.txtSuma.Text = pamsuma.Value.ToString();
            this.txtMedia.Text = pammedia.Value.ToString();
            this.txtPersonas.Text = pampersonas.Value.ToString();


            this.cn.Close();
            this.com.Parameters.Clear();

        }
    }
}
