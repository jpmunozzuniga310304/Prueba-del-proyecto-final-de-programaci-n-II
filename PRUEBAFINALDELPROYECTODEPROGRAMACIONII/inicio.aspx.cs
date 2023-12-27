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
    // En esta parte es la programación de la parte inicio de la pagina web
    public partial class inicio : System.Web.UI.Page
    {
        // En esta parte es donde el usuario digita su correo electronico la su contraseña para acceder a la pagina web correctamente
        protected void Page_Load(object sender, EventArgs e)
        {
            lpersona.Text = Clspersona.GetCorreo();
        }
    }
}