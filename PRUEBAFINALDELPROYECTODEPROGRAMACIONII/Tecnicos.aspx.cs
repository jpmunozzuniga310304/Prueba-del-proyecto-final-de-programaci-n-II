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
    // En esta parte es la programación de la parte tecnicos de la pagina web para que funcione correctamente
    public partial class Tecnicos : System.Web.UI.Page
    {
        // En esta parte es donde se carga la parte tecnicos de la pagina web correctamente
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        // En esta parte es para transferir los datos de los tecnicos del sql server management studio al visual studio en C#  
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Tecnicos"))
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

        // En esta parte son las alertas cuya funcion es cuando el usuario digita un numero es para saber si lo ingreso correctamente o no en la parte tecnicos
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        // En esta parte es para que el boton agregar funcione correctamente en la parte de tecnicos de la pagina web
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Clases.Tecnicos.Agregar(tNombre.Text, tEspecialidad.Text) > 0)
            {
                LlenarGrid();
                alertas("Nombre del tecnico ingresado con exito");
            }
            else
            {
                alertas("Error al ingresar el nombre del tecnico");
            }
        }

        // En esta parte es para que el boton borrar funcione correctamente en la parte de tecnicos de la pagina web
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Clases.Tecnicos.Borrar(int.Parse(tTecnicoID.Text)) > 0)
            {
                LlenarGrid();
                alertas("Nombre del tecnico borrado con exito");
            }
            else
            {
                alertas("Error al borrar el nombre del tecnico");
            }
        }

        // En esta parte es para que el boton actualizar funcione correctamente en la parte de tecnicos de la pagina web
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Clases.Tecnicos.Actualizar(int.Parse(tTecnicoID.Text), tNombre.Text, tEspecialidad.Text) > 0)
            {
                LlenarGrid();
                alertas("Nombre del tecnico actualizadas con exito");
            }
            else
            {
                alertas("Error al actualizar el nombre del tecnico");
            }
        }

        // En esta parte es para que el boton de consultar funcione correctamente en la parte de tecnicos de la pagina web
        protected void Button2_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tTecnicoID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos WHERE TecnicoID ='" + codigo + "'"))


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

        // En esta parte es para que el boton de mostrar todo funcione correctamente en la parte de tecnicos de la pagina web
        protected void Button5_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}