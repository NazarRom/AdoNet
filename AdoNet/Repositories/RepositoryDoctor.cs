using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AdoNet.Helpers;
using AdoNet.Models;
using System.Data;
using System.Windows.Forms;
#region PROCEDURE
//CREATE PROCEDURE SP_ESPECIALIDAD
//AS
//SELECT DISTINCT ESPECIALIDAD FROM DOCTOR
//GO


//CREATE PROCEDURE SP_DOCTORES_SELECCIONADOS
//(@NOMBRE NVARCHAR(50))
//AS
//select * from DOCTOR where ESPECIALIDAD = @NOMBRE
//GO


//CREATE PROCEDURE  SP_DATOS_DOC_ESP
//(@NOMBRE NVARCHAR(60),
//@SUMA INT OUT,
//@MEDIA INT OUT,
//@PERSONAS INT OUT )
//AS
//SELECT @SUMA = ISNULL(SUM(SALARIO),0), @MEDIA = ISNULL(AVG(SALARIO), 0), @PERSONAS = COUNT(DOCTOR_NO)
//FROM DOCTOR WHERE ESPECIALIDAD = @NOMBRE
//GO

//se saca todo
#endregion
namespace AdoNet.Repositories
{
    public class RepositoryDoctor
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryDoctor()
        {
            string connectionString = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<string> LoadEspecialidad()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_ESPECIALIDAD";

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<string> especialidades = new List<string>();
            while (this.reader.Read())
            {
                string especialidad = this.reader["ESPECIALIDAD"].ToString();
                especialidades.Add(especialidad);
            }

            this.cn.Close();
            this.reader.Close();
            return especialidades;
        } 

        public List<Doctor> LoadDoctores(string nombre)
        {
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            this.com.Parameters.Add(pamnombre);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_DOCTORES_SELECCIONADOS";

            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                int id =int.Parse(this.reader["DOCTOR_NO"].ToString());
                string apellido = this.reader["APELLIDO"].ToString();
                string especialidad = this.reader["ESPECIALIDAD"].ToString();
                int salario =int.Parse(this.reader["SALARIO"].ToString());
                Doctor doctor = new Doctor();
                doctor.IdDoctor = id;
                doctor.Apllido = apellido;
                doctor.Especialidad = especialidad;
                doctor.Salario = salario;
                doctores.Add(doctor);
  
            }
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();

            return doctores;

        }


        public DatosDoctor GetCalculo(string nombre)
        {
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            this.com.Parameters.Add(pamnombre);

            //datos de salida
            SqlParameter pamsuma = new SqlParameter("@SUMA", 0);
            pamsuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamsuma);

            SqlParameter pammedia = new SqlParameter("@MEDIA", 0);
            pammedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pammedia);

            SqlParameter pampersonas = new SqlParameter("@PERSONAS", 0);
            pampersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pampersonas);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_DATOS_DOC_ESP";

            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            DatosDoctor datos = new DatosDoctor();
            datos.Suma = int.Parse(pamsuma.Value.ToString());
            datos.Media = int.Parse(pammedia.Value.ToString());
            datos.Personas = int.Parse(pampersonas.Value.ToString());

            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();

            return datos;
        }

    }
}
