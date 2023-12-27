using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    // En esta parte es toda la programación de la clase iniciar sesion, para que esta parte del programa funcione correctamente
    public class Clspersona
    {
        // En esta parte sirve son los codigos para poder iniciar sesion

        private static int Id;
        private static string Clave;
        private static string Correo;
        private static string Nombre;
        public static string nombrerol;

        // En esta parte es para que funcione correctamente el SetId
        public int GetId()
        {
            return Id;
        }

        // En esta parte es para detectar el id de la persona que accedio a la pagina web
        public void SetID(int id)
        {
            Id = id;
        }

        // En esta parte es para que funcione correctamente el SetClave
        public static string GetClave()
        {
            return Clave;
        }

        // En esta parte es para digitar la clave para poder acceder a la pagina web
        public void SetClave(string clave)
        {
            Clave = clave;
        }

        // En esta parte es para que funcione correctamente el SetCorreo
        public static string GetCorreo()
        {
            return Correo;
        }

        // En esta parte es para digitar es el correo para poder acceder a la pagina web
        public void SetCorreo(string correo)
        {
            Correo = correo;
        }

        // En esta parte es para que funcione correctamente el SetNombre
        public static string GetNombre()
        {
            return Nombre;
        }

        // En esta parte es donde se muestra el nombre del usuario que digito su nombre a la pagina web
        public void SetNombre(string nombre)
        {
            Nombre = nombre;
        }

        // En esta parte para que funcione correctamente el iniciar sesion 
        public static int ValidarLogin()
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Validapersona", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Correo", Correo));
                    cmd.Parameters.Add(new SqlParameter("@Clave", Clave));

                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            retorno = 1;
                        }
                        else
                        {
                            retorno = -1;
                        }

                    }


                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }
    }
}