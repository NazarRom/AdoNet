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
    public partial class Form05DepartamentosEmpleados : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form05DepartamentosEmpleados()
        {
            InitializeComponent();
            string connectionString =
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadDepartamentos();
        }

        private void LoadDepartamentos()
        {
            string sql = "select dnombre  from dept";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstDepartamentos.Items.Clear();
            while (this.reader.Read())
            {
                string dept = this.reader["dnombre"].ToString();
                this.lstDepartamentos.Items.Add(dept);
            }
            this.cn.Close();
            this.reader.Close();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.lstEmpleados.SelectedIndex != -1)
            {
                string sql = "UPDATE EMP SET SALARIO=@SALARIO, OFICIO=@OFICIO " + " WHERE APELLIDO=@APELLIDO";
                string apellido = this.lstEmpleados.SelectedItem.ToString();
                string oficio = this.txtOficio.Text;
                int salario = int.Parse(this.txtSalario.Text);
                SqlParameter pamapellido = new SqlParameter("@APELLIDO", apellido);
                SqlParameter pamoficio = new SqlParameter("@OFICIO", oficio);
                SqlParameter pamsalario = new SqlParameter("@SALARIO", salario);
                this.com.Parameters.Add(pamapellido);
                this.com.Parameters.Add(pamoficio);
                this.com.Parameters.Add(pamsalario);
                this.com.CommandType = CommandType.Text;
                this.com.CommandText = sql;
                this.cn.Open();
                int modificados = this.com.ExecuteNonQuery();
                this.cn.Close();
                this.com.Parameters.Clear();
                MessageBox.Show("Registros modificados " + modificados);
            }

        }

        private void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreDepartamneto = this.lstDepartamentos.SelectedItem.ToString();
            string sql = "select emp.APELLIDO from emp inner join DEPT on emp.DEPT_NO = DEPT.DEPT_NO where DEPT.DNOMBRE = @NOMBREDEPARTAMENTO";
            SqlParameter pamnombre = new SqlParameter("@NOMBREDEPARTAMENTO", nombreDepartamneto);
            this.com.Parameters.Add(pamnombre);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstEmpleados.Items.Clear();
            while (this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEmpleados.Items.Add(apellido);
            }
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
        }

        private void lstEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstEmpleados.SelectedIndex != -1)
            {
                string sql = "SELECT OFICIO, SALARIO FROM EMP WHERE APELLIDO=@APELLIDO";
                string apellido = this.lstEmpleados.SelectedItem.ToString();
                SqlParameter pamapellido = new SqlParameter("@APELLIDO", apellido);
                this.com.Parameters.Add(pamapellido);
                this.com.CommandType = CommandType.Text;
                this.com.CommandText = sql;
                this.cn.Open();
                this.reader = this.com.ExecuteReader();
                this.reader.Read();
                string oficio = this.reader["OFICIO"].ToString();
                string salario = this.reader["SALARIO"].ToString();
                this.txtOficio.Text = oficio;
                this.txtSalario.Text = salario;
                this.reader.Close();
                this.cn.Close();
                this.com.Parameters.Clear();
            }

        }
    }
}
