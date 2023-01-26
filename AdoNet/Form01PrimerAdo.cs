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
    public partial class Form01PrimerAdo : Form
    {
        string connectionString;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public Form01PrimerAdo()
        {
            InitializeComponent();
            this.connectionString =
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            //siempre connection string en el constructor
            this.cn = new SqlConnection(this.connectionString);
            this.com = new SqlCommand();
            this.cn.StateChange += Cn_StateChange;
        }

        private void Cn_StateChange(object sender, StateChangeEventArgs e)
        {
            this.lblMensaje.Text = " La conexion está cambiando de "
                + e.OriginalState + " a " + e.CurrentState;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cn.State == ConnectionState.Closed)
                {
                    this.cn.Open();
                }
                this.lblMensaje.BackColor = Color.LightGreen;
            }
            catch(Exception ex)
            {
                this.lblMensaje.Text = "Error al conectar con bbdd. " + ex;
            }

        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            this.cn.Close();
            this.lblMensaje.BackColor = Color.LightCoral;
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM EMP";
            //indicamos al comando la conexion a utilizar
            this.com.Connection = this.cn;
            //indicamos el tipo de cosnulta
            this.com.CommandType = CommandType.Text;
            //inidcamos la consulta
            this.com.CommandText = sql;
            //con todo configurado, para ejecutar la consulta
            //debemos tener una conexion abierta
            //ejecutamos la consulta y extraemos el reader
            this.reader = this.com.ExecuteReader();
            for (int i = 0; i<this.reader.FieldCount; i++)
            {
                //dibujamos la primera columna de la tabla
                string columna = this.reader.GetName(i);
                //dibujamos el tipo de la primera columna de la tabla
                string tipo = this.reader.GetDataTypeName(i);
                this.lstColumnas.Items.Add(columna);
                this.lstTipoDato.Items.Add(tipo);
            }
            
            //para acceder a los datos debemos leer
            //Read() devuelve bool, asi que para leer todos los datos
            //se utiliza un while
            while (this.reader.Read())
            {
                //vamos a recuperar un apellido
                string apellido = this.reader["APELLIDO"].ToString();
                this.lstApellidos.Items.Add(apellido);
            }

            this.reader.Close();
        }
    }
}
