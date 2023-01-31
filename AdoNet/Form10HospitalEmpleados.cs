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
namespace AdoNet
{
    #region VISTA
//    select* from PLANTILLA

//select* from HOSPITAL

//select* from DOCTOR

//CREATE VIEW HOSPITAL_DOC_PLANTILLA
//AS
//    SELECT APELLIDO ,SALARIO, H.HOSPITAL_COD, DOCTOR_NO as EMPLEADO_COD
//    FROM HOSPITAL H

//    INNER JOIN  DOCTOR D

//    ON H.HOSPITAL_COD = D.HOSPITAL_COD
//    union

//    select APELLIDO, SALARIO, H.HOSPITAL_COD, EMPLEADO_NO as EMPLEADO_COD
//    from HOSPITAL H

//    INNER JOIN PLANTILLA P

//    ON H.HOSPITAL_COD = P.HOSPITAL_COD
//GO

//select * from HOSPITAL_DOC_PLANTILLA WHERE HOSPITAL_COD = 22

    #endregion
    public partial class Form10HospitalEmpleados : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public Form10HospitalEmpleados()
        {
            InitializeComponent();
            string connectionString =
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
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
                string nombre = this.reader["NOMBRE"].ToString();
                this.cmbHospitales.Items.Add(nombre);
            }
            this.cn.Close();
            this.reader.Close();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }
    }
}
