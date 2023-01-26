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
    public partial class Fomr04ModificarSalas : Form
    {

        //declaro los objetos que voy a usar
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Fomr04ModificarSalas()
        {
            InitializeComponent();
            string connectionString =
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadSalas();
        }

        private void LoadSalas()
        {
            string sql = "select distinct nombre  from sala";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstSalas.Items.Clear();
            while (this.reader.Read())
            {
                string nombre = this.reader["nombre"].ToString();
                this.lstSalas.Items.Add(nombre);
            }
            this.cn.Close();
            this.reader.Close();
        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            int select = this.lstSalas.SelectedIndex;
            string nombreseleccionado = this.lstSalas.Items[select].ToString();
            string sql = "UPDATE SALA SET NOMBRE = @NOMBRENUEVO WHERE NOMBRE = @NOMBRESELECCIONADO";

            SqlParameter pamnombre = new SqlParameter("@NOMBRENUEVO", nombre);
            SqlParameter pannombreseleccionado = new SqlParameter("@NOMBRESELECCIONADO", nombreseleccionado);
            this.com.Parameters.Add(pannombreseleccionado);
            this.com.Parameters.Add(pamnombre);

            this.cn.Open();
            int mod = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            MessageBox.Show("Modificado");
            this.LoadSalas();




        }
    }
}
