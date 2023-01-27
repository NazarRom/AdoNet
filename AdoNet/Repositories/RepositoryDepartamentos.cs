using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AdoNet.Models;

namespace AdoNet.Repositories
{
    public class RepositoryDepartamentos
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;
         
        public RepositoryDepartamentos()
        {
            string connectionString =
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }
        public int UpdateDepartamneto(int id, string nombre, string localidad)
        {
            string sql = "update dept set dnombre=@nombre, loc=@localidad where dept_no = @id";
            SqlParameter pamnumero = new SqlParameter("@id", id);
            SqlParameter pamnombre = new SqlParameter("@nombre" ,nombre);
            SqlParameter pamlocalidad = new SqlParameter("@localidad", localidad);
            this.com.Parameters.Add(pamnumero);
            this.com.Parameters.Add(pamnombre);
            this.com.Parameters.Add(pamlocalidad);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int act = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return act;

        }
        public int InsertDepartamento(int id, string nombre, string localidad)
        {
            string sql = "INSERT INTO DEPT VALUES (@NUM, @NOM, @LOC)";
            SqlParameter parnum = new SqlParameter("@NUM", id);
            SqlParameter parnom = new SqlParameter("@NOM", nombre);
            SqlParameter parloc = new SqlParameter("@LOC", localidad);

            this.com.Parameters.Add(parnom);
            this.com.Parameters.Add(parnum);
            this.com.Parameters.Add(parloc);

            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;

            this.cn.Open();
            int insertar = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return insertar;
            
        }

        public List<Departamento> GetDepartamentos()
        {
            string sql = "select * from dept";
            List<Departamento> departamentos = new List<Departamento>();
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                int id = int.Parse(this.reader["DEPT_NO"].ToString());
                string nombre = this.reader["DNOMBRE"].ToString();
                string localidad = this.reader["LOC"].ToString();

                Departamento dept = new Departamento();
                dept.IdDepartamento = id;
                dept.Nombre = nombre;
                dept.Localidad = localidad;

                departamentos.Add(dept);
            }
            this.reader.Close();
            this.cn.Close();
            return departamentos;
        }

        public int DeleteDepartamento(int id)
        {
            string sql = "DELETE FROM DEPT WHERE DEPT_no=@NUMERO";
            SqlParameter pamnumero = new SqlParameter("@NUMERO",id);
            this.com.Parameters.Add(pamnumero);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int del = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return del;

        }
    }
}
