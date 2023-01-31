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

#region PROCEDIMINETOS ALMACENADOS
//CREATE PROCEDURE SP_HOSPITALES
//AS 
//SELECT *FROM HOSPITAL
//GO

//create procedure sp_updatesalarioshospital
//(@NOMBRE NVARCHAR(50)) AS
//DECLARE @HOSPITALCOD INT
//DECLARE @SUMASALARIAL INT
//SELECT @HOSPITALCOD = HOSPITAL_COD FROM HOSPITAL
//WHERE NOMBRE = @NOMBRE
//SELECT @SUMASALARIAL = SUM(CAST(SALARIO AS INT)) FROM PLANTILLA 
//WHERE HOSPITAL_COD = @HOSPITALCOD
//IF (@SUMASALARIAL > 1000000)
//BEGIN
//    UPDATE PLANTILLA SET SALARIO = SALARIO - 10000
//    WHERE HOSPITAL_COD = @HOSPITALCOD
//    PRINT 'BAJANDO SALARIOS: ' + CAST(@SUMASALARIAL AS NVARCHAR)
//END
//ELSE
//BEGIN
//    UPDATE PLANTILLA SET SALARIO = SALARIO + 10000
//    WHERE HOSPITAL_COD = @HOSPITALCOD
//    PRINT 'SUBIENDO SALARIOS: ' + CAST(@SUMASALARIAL AS NVARCHAR)
//END
//	SELECT * FROM PLANTILLA WHERE HOSPITAL_COD = @HOSPITALCOD
//GO
#endregion
namespace AdoNet
{
    public partial class Form07ProcedimientoUpdatePlantilla : Form
    {
        SqlCommand com;
        SqlConnection cn;
        SqlDataReader reader;
        public Form07ProcedimientoUpdatePlantilla()
        {
            InitializeComponent();
            string connectionString =
                @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadHospitales();
        }

        private void LoadHospitales()
        {
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "SP_HOSPITALES";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cmbHospitales.Items.Clear();
            while (this.reader.Read())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                this.cmbHospitales.Items.Add(nombre);
            }
            this.reader.Close();
            this.cn.Close();
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = this.cmbHospitales.SelectedItem.ToString();
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            this.com.Parameters.Add(pamnombre);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = "sp_updatesalarioshospital";
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstPlantilla.Items.Clear();
            while (this.reader.Read())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                string function = this.reader["FUNCION"].ToString();
                string salario = this.reader["SALARIO"].ToString();
                this.lstPlantilla.Items.Add(apellido + " , " + function + " , " + salario);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
    }
}
