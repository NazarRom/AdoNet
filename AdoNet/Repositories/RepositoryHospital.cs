using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AdoNet.Models;
using Microsoft.Extensions.Configuration;
using AdoNet.Helpers;
#region PRECEDURE Y VIEVS

//CREATE VIEW V_EMPLEADOS_HOSPITAL
//AS
//	SELECT  DOCTOR_NO AS IDEMPLEADO, APELLIDO, SALARIO, HOSPITAL_COD FROM DOCTOR
//	UNION
//	SELECT EMPLEADO_NO, APELLIDO, SALARIO, HOSPITAL_COD FROM PLANTILLA
//GO


//CREATE PROCEDURE SP_DATOS_HOSPITAL
//(@NOMBRE NVARCHAR (50),@SUMA INT OUT, @MEDIA INT OUT, @PERSONAS INT OUT)
//AS

//    DECLARE @IDHOSPITAL INT
//	SELECT @IDHOSPITAL = HOSPITAL_COD FROM HOSPITAL
//	WHERE NOMBRE = @NOMBRE

//	SELECT *  FROM V_EMPLEADOS_HOSPITAL
//	WHERE HOSPITAL_COD = @IDHOSPITAL

//	SELECT @SUMA = ISNULL(SUM(SALARIO),0), @MEDIA = ISNULL(AVG(SALARIO), 0), @PERSONAS = COUNT(IDEMPLEADO) FROM V_EMPLEADOS_HOSPITAL
//	WHERE HOSPITAL_COD = @IDHOSPITAL

//GO
#endregion
namespace AdoNet.Repositories
{
    public class RepositoryHospital
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryHospital()
        {
            string connectionString = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        //necesitamos un metodo para devilver todos los hospitales
        public List<string> GetHopsitales()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_HOSPITALES";
            List<string> hospitales = new List<string>();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                hospitales.Add(nombre);
            }
            this.reader.Close();
            this.cn.Close();
            return hospitales;
        }

        public DatosHopsital GetDatosHospital(string nombre)
        {
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            this.com.Parameters.Add(pamnombre);

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
            this.com.CommandText = "SP_DATOS_HOSPITAL";

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<EmpleadoHospital> empleados = new List<EmpleadoHospital>();
            while (this.reader.Read())
            {
                int idempleado = int.Parse(this.reader["IDEMPLEADO"].ToString());
                string apellido = this.reader["APELLIDO"].ToString();
                int salario = int.Parse(this.reader["SALARIO"].ToString());
                EmpleadoHospital empleado = new EmpleadoHospital();
                empleado.IdEmpleado = idempleado;
                empleado.Apellido = apellido;
                empleado.Salario = salario;
                empleados.Add(empleado);
            }
            this.reader.Close();
            DatosHopsital datos = new DatosHopsital();
            datos.Empleados = empleados;
            datos.SumaSalarial = int.Parse(pamsuma.Value.ToString());
            datos.MediaSalarial = int.Parse(pammedia.Value.ToString());
            datos.Personas = int.Parse(pampersonas.Value.ToString());

            this.cn.Close();
            this.com.Parameters.Clear();
            return datos;


        }
    }
}
