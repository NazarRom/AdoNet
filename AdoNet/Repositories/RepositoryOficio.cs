using AdoNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AdoNet.Helpers;
using System.Data;
#region PROCEDURE
//CREATE PROCEDURE SP_OFICIOS
//AS
//	SELECT DISTINCT OFICIO FROM EMP
//GO

//CREATE PROCEDURE SP_EMPLEADOS_OFICIO
//(@NOMBRE NVARCHAR)
//AS
//SELECT * FROM EMP WHERE OFICIO = @NOMBRE
//GO


//CREATE PROCEDURE SP_DELETE_OFICIO
//(@IDEMP INT)
//AS
//DELETE FROM EMP WHERE EMP_NO = 1111
//GO
#endregion
namespace AdoNet.Repositories
{
    public class RepositoryOficio
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryOficio()
        {
            string connectionString = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<string> GetOficio()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_OFICIOS";
            List<string> oficios = new List<string>();
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                string oficio = this.reader["OFICIO"].ToString();
                oficios.Add(oficio);
            }
            this.cn.Close();
            this.reader.Close();
            return oficios;
        }

        public List<Empleado> GetEmpleadosDatos(string nombre)
        {

            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            this.com.Parameters.Add(pamnombre);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_EMPLEADOS_OFICIO";

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Empleado> empleados = new List<Empleado>();
            while (this.reader.Read())
            {
                int id = int.Parse(this.reader["EMP_NO"].ToString());
                string apellido = this.reader["APELLIDO"].ToString();
                string ofiocio = this.reader["OFICIO"].ToString();
                int salario =int.Parse(this.reader["SALARIO"].ToString());
                Empleado empleado = new Empleado();
                empleado.IdEmpleado = id;
                empleado.Apellido = apellido;
                empleado.Oficio = ofiocio;
                empleado.Salario = salario;
                empleados.Add(empleado);

            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();

            return empleados;
            
        }

        public int DeleteEmpleado(int id)
        {
            SqlParameter pamid = new SqlParameter("@IDEMP", id);
            this.com.Parameters.Add(pamid);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_DELETE_OFICIO";

            this.cn.Open();
            int borrados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();

            return borrados;

        }

    }
}
