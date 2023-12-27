using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Segundo Proyecto de Programación II
// Estudiantes: José Pablo Muñoz Zúñiga 
//              Karina Marina Marina Unfried Montoya
//              Dillan Josue Obando Samudio
// Carrera: Ingeniería Informática
// Materia: Programación II

namespace PRUEBAFINALDELPROYECTODEPROGRAMACIONII
{
    // En esta parte es la programación de la parte equipos de la pagina web para que funcione correctamente
    public partial class Reporte_Equipos : System.Web.UI.Page
    {
        // En esta parte es donde se carga la parte equipos de la pagina web correctamente
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        // En esta parte es para transferir los datos de los reporte equipos del sql server management studio al visual studio en C#
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Reporteequipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();
                        }
                    }
                }
            }
        }

        // En esta parte es para que el boton de consultar funcione correctamente en la parte de reporteequipos de la pagina web
        protected void Button1_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tReporteequipos.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Reporteequipos WHERE EquipoID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();
                    }
                }
            }
        }

        // En esta parte es para que el boton de mostrar todo funcione correctamente en la parte de reporteequipos de la pagina web
        protected void Button2_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}