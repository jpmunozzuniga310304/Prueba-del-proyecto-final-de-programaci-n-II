using PRUEBAFINALDELPROYECTODEPROGRAMACIONII.Clases;
using System;
using System.Collections.Generic;
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
    // En esta parte es la programación de la parte iniciar sesion de la pagina web
    public partial class Iniciar_sesion : System.Web.UI.Page
    {
        // En esta parte es donde se carga la parte iniciar sesion de la pagina web correctamente
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // En esta parte es la programación del boton de iniciar sesion para que se pueda acceder a la pagina web     correctamente
        protected void Button1_Click(object sender, EventArgs e)
        {
            Clases.Clspersona objpersona = new Clases.Clspersona();
            objpersona.SetCorreo(tcorreo.Text);
            objpersona.SetClave(tclave.Text);
            if (Clspersona.ValidarLogin() > 0)
            {
                Response.Redirect("inicio.aspx");
            }
        }
    }
}