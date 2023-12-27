using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

// Segundo Proyecto de Programación II
// Estudiantes: José Pablo Muñoz Zúñiga 
//              Karina Marina Marina Unfried Montoya
//              Dillan Josue Obando Samudio
// Carrera: Ingeniería Informática
// Materia: Programación II

namespace PRUEBAFINALDELPROYECTODEPROGRAMACIONII.Clases
{
    // En esta parte es toda la programación de la clase DBConn, para que esta parte del programa funcione correctamente
    public class DBConn
    {
        // En esta parte sirve para extraer todos los datos del sql server management studio al visual studio en C#
        public static SqlConnection obtenerConexion2()
        {
            string s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion2"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            return conexion;
        }
    }
}