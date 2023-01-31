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
    #region procediminetos
    //    CREATE PROCEDURE SP_DEPARTAMENTOS
    //AS

    //    SELECT* FROM DEPARTAMENTOS
    //GO

//    ALTER PROCEDURE SP_INSERT_DEPARTAMENTO
//    (@ID INT, @NOMBRE NVARCHAR(50), @LOC NVARCHAR(50))
//AS
//--no queremos localidades en teruel
//if(@LOC = 'TERUEL')
//BEGIN
//PRINT 'TERUEL NO EXISTE'
//END
//ELSE
//BEGIN
// INSERT INTO DEPT VALUES(@ID , @NOMBRE , @LOC)
// END
//GO


    #endregion
    public partial class Form08MensajesServidor : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form08MensajesServidor()
        {
            InitializeComponent();
            string connectionString =
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.cn.InfoMessage += Cn_InfoMessage;                              
            this.LoadDepartamentos();
        }

        private void Cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.lblMensaje.Text = e.Message;
        }

        private void LoadDepartamentos()
        {
            
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_DEPARTAMENTOS";

            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstDepartamentos.Items.Clear();
            while (this.reader.Read())
            {
                int id = int.Parse(this.reader["DEPT_NO"].ToString());
                string nombre = this.reader["DNOMBRE"].ToString();
                string localidad = this.reader["LOC"].ToString();
                this.lstDepartamentos.Items.Add(id + " - " + nombre + " - " + localidad);
            }
            this.cn.Close();
            this.reader.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;
            SqlParameter pamid = new SqlParameter("@ID", id);
            SqlParameter pamnom = new SqlParameter("@NOMBRE", nombre);
            SqlParameter pamloc = new SqlParameter("@LOC", localidad);
            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamnom);
            this.com.Parameters.Add(pamloc);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_INSERT_DEPARTAMENTO";

            this.cn.Open();
            int ingresados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();

            this.LoadDepartamentos();

            
        }
    }
}
