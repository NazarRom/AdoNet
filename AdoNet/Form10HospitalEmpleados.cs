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
    #region procedure

    //    CREATE VIEW  HOSPITAL_DOC_PLANTILLA
    //    AS
    //SELECT APELLIDO, SALARIO, HOSPITAL_COD, EMPLEADO_NO  FROM PLANTILLA
    //UNION
    //SELECT APELLIDO, SALARIO, HOSPITAL_COD, DOCTOR_NO FROM DOCTOR
    //GO


//    CREATE PROCEDURE SP_EMPLEADOS_HOSPITAL
//(@ID INT,
//@SUMA INT OUT,
//@MEDIA INT OUT,
//@PERSONAS INT OUT)
//AS
//DECLARE @EMPLEADO INT
//SELECT @EMPLEADO = EMPLEADO_NO FROM HOSPITAL_DOC_PLANTILLA WHERE HOSPITAL_COD = @ID
//SELECT APELLIDO, SALARIO FROM HOSPITAL_DOC_PLANTILLA WHERE HOSPITAL_COD = @ID
//SELECT @SUMA = SUM(SALARIO), @MEDIA = AVG(SALARIO), @PERSONAS = COUNT(@EMPLEADO) FROM HOSPITAL_DOC_PLANTILLA WHERE HOSPITAL_COD = @ID;
//    GO

    #endregion
    public partial class Form10HospitalEmpleados : Form
    {
        SqlConnection cn;//clase conexion
        SqlCommand com;//clase comandos
        SqlDataReader reader;//reader 
        List<int> listaIdHospital;//lista para los ids

        public Form10HospitalEmpleados()
        {
            InitializeComponent();
            this.listaIdHospital = new List<int>();//declaro la lista
            string connectionString =
                @"Data Source=.\SQLEXPRESS;Initial Catalog=Hospital;Persist Security Info=True;User ID=sa";//la conexion
            this.cn = new SqlConnection(connectionString);//realizo la conexion
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadHospitales();
        }

        private void LoadHospitales()
        {
            //como vamos a usar procedure no hace falta declarar ninguna query 
            //vamos directos al procedure

            this.com.CommandType = CommandType.StoredProcedure; //definimos el tipo de la query en este caso de la procedure
            this.com.CommandText = "SP_HOSPITALES";//aqui la procedure

            this.cn.Open();//abrimos la conexion
            this.reader = this.com.ExecuteReader();//ejecutamos el reader
            this.cmbHospitales.Items.Clear();//limpiamos el combobox para que no se nos guarde varias veces
            while (this.reader.Read())//el bucle para leer todos los datos y guardarlos
            {
                int id = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                string nombre = this.reader["NOMBRE"].ToString();
                this.cmbHospitales.Items.Add(nombre);//guardo el nombre en el combobox
                this.listaIdHospital.Add(id);//guardo el id de los hospitales 
            }
            this.cn.Close();
            this.reader.Close();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            //lo que hago aqui es basicamente que a la hora de guardar todo 
            //lo hago en 2 cosas distintas en una lista y un combo box 
            //pero comparten el mismo index
            //por lo tanto puedo recupersr los id
            int index = this.cmbHospitales.SelectedIndex;//selecciono el index del hospital seleccionado
            int idHospital = this.listaIdHospital[index];//con el index seleccionado recupero el id del hospital

            SqlParameter pamid = new SqlParameter("@id", idHospital);
            this.com.Parameters.Add(pamid);
            //declaramos los parametros de salida

            SqlParameter pamsuma = new SqlParameter("SUMA",0);//declaro el objeto con los parametros dento,
                                                              //los parametros de salida siempre tienen que
                                                              //tener un valor por eso le ponemos un 0
            pamsuma.Direction = ParameterDirection.Output;//declaramos la direccion de los parametros 
            this.com.Parameters.Add(pamsuma);//los añadimos a la lista

            SqlParameter pammedia = new SqlParameter("@MEDIA", 0);
            pammedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pammedia);

            SqlParameter pampersonas = new SqlParameter("@PERSONAS",0);
            pampersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pampersonas);


            //LO DE COMMANTYPE Y LO DEMÁS
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_EMPLEADOS_HOSPITAL";
            //conexion

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
