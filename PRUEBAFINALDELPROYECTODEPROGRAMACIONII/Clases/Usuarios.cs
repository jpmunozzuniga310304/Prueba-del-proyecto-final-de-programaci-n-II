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
    // En esta parte es toda la programación de la clase usuarios, para que esta parte del programa funcione correctamente
    public class Usuarios
    {
        // En esta parte son los codigos donde se almacena la datos digitados en la clase usuarios
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public int Telefono { get; set; }

        // En esta parte es un constructor para que funcione correctamente, la consulta de los datos digitados de la clase usuarios
        public Usuarios(int id, string nombre, string correoelectronico, int telefono)
        {
            Id = id;
            Nombre = nombre;
            CorreoElectronico = correoelectronico;
            Telefono = telefono;
        }

        // En esta parte es un constructor de la clase usuarios con datos
        public Usuarios(string nombre, string correoElectronico, int telefono)
        {
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Telefono = telefono;
        }

        // En esta parte es un constructor de la clase usuarios sin datos
        public Usuarios()
        {
        }

        // En esta parte tiene la funcion para agregar nuevos datos en la clase usuarios
        public static int Agregar(string nombre, string correoelectronico, int telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Agregarusuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREOELECTRONICO", correoelectronico));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", telefono));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        // En esta parte tiene la funcion para borrar los datos en la clase usuarios
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Borrarusuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        // En esta parte tiene la funcion para actualizar los datos en la clase usuarios
        public static int Actualizar(int codigo, string nombre, string correoelectronico, int telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Actualizarusuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREOELECTRONICO", correoelectronico));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", telefono));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        // En esta parte tiene la funcion para consultar los datos en la clase usuarios
        public static List<Usuarios> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Usuarios> Usuarios = new List<Usuarios>();
            try
            {

                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Consultar_filtrousuarios", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuarios Usuario = new Usuarios(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                            Usuarios.Add(Usuario);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Usuarios;
        }

        // En esta parte es la segunda programación para que al momento de consultar los datos en la clase usuarios funcione
        public static List<Usuarios> ObtenerUsuarios()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Usuarios> Usuarios = new List<Usuarios>();
            try
            {

                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("consultar ", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuarios Usuario = new Usuarios(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                            Usuarios.Add(Usuario);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Usuarios;
        }
    }
}