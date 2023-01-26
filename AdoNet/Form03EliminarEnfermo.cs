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
    public partial class Form03EliminarEnfermo : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public Form03EliminarEnfermo()
        {
            InitializeComponent();
            string connctionString =
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            this.cn = new SqlConnection(connctionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadEnfermos();
        }

        private void LoadEnfermos()
        {
            string sql = "select * from enfermo";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstEnfermos.Items.Clear();
            while (this.reader.Read())
            {
                string inscripcion = this.reader["INSCRIPCION"].ToString();
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstEnfermos.Items.Add(inscripcion + " - " + apellido);

            }
            reader.Close();
            this.cn.Close();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int inscripcion = int.Parse(this.txtInscripcion.Text);
            string sql = "DELETE FROM ENFERMO WHERE INSCRIPCION= @INSCRIPCION";
            //creamos un nuveo objeto parameter
            SqlParameter paminscripcion = new SqlParameter("@INSCRIPCION", inscripcion);
            this.com.Parameters.Add(paminscripcion);
                        
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();//consulta de accion y tambien ejecuta todo
            this.cn.Close();
            this.com.Parameters.Clear();
            MessageBox.Show("Enfermos eliminados:" + eliminados);
            this.LoadEnfermos();
        }
    }
}
