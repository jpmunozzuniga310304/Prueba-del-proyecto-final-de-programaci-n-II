using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRUEBAFINALDELPROYECTODEPROGRAMACIONII
{
    public partial class DetallesReparacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        // En esta parte es para transferir los datos de los detallesreparacion del sql server management studio al visual studio en C#
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM DetallesReparacion"))
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

        // En esta parte son las alertas cuya funcion es cuando el usuario digita un numero es para saber si lo ingreso correctamente o no en la parte detallesreparacion
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

        // En esta parte es para que el boton agregar funcione correctamente en la parte de detallesreparacion de la pagina web
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Clases.DetallesReparacion.Agregar(int.Parse(tTextBox1.Text), tDescripcion.Text, tFechaInicio.Text, tFechaFin.Text) > 0)
            {
                LlenarGrid();
                alertas("DetallesReparacion ingresados con exito");
            }
            else
            {
                alertas("Error al ingresar los DetallesReparacion");
            }
        }

        // En esta parte es para que el boton borrar funcione correctamente en la parte de detallesreparacion de la pagina web
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Clases.DetallesReparacion.Borrar(int.Parse(tDetalleID.Text)) > 0)
            {
                LlenarGrid();
                alertas("Detallesreparacion borrados con exito");
            }
            else
            {
                alertas("Error al borrar los detallesreparacion");
            }
        }

        // En esta parte es para que el boton actualizar funcione correctamente en la parte de detallesreparacion de la pagina web
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Clases.DetallesReparacion.Actualizar(int.Parse(tDetalleID.Text), int.Parse(tTextBox1.Text), tDescripcion.Text, tFechaInicio.Text, tFechaFin.Text) > 0)
            {
                LlenarGrid();
                alertas("DetallesReparacion han sido actualizados con exito");
            }
            else
            {
                alertas("Error al actualizar los DetallesReparacion");
            }
        }

        // En esta parte es para que el boton de consultar funcione correctamente en la parte de detallesreparacion de la pagina web
        protected void Button2_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tDetalleID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DetallesReparacion WHERE DetalleID ='" + codigo + "'"))


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

        // En esta parte es para que el boton de mostrar todo funcione correctamente en la parte de detallesreparacion de la pagina web
        protected void Button5_Click(object sender, EventArgs e)
        {
            LlenarGrid();
        }
    }
}