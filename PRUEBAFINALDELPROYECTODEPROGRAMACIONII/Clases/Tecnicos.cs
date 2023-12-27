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
    // En esta parte es toda la programación de la clase tecnicos, para que esta parte del programa funcione correctamente
    public class Tecnicos
    {
        // En esta parte son los codigos donde se almacena la datos digitados en la clase tecnicos
        public int Id { get; set; }
        public string Nombre { get; set; }

        // En esta parte es un constructor para que funcione correctamente, la consulta de los datos digitados de la clase tecnicos
        public Tecnicos(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        // En esta parte es un constructor de la clase tecnicos con datos
        public Tecnicos(string nombre)
        {
            Nombre = nombre;
        }

        // En esta parte es un constructor de la clase tecnicos sin datos
        public Tecnicos()
        {
        }

        // En esta parte tiene la funcion para agregar nuevos datos en la clase tecnicos
        public static int Agregar(string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Agregartecnicos", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ESPECIALIDAD", especialidad));

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

        // En esta parte tiene la funcion para borrar los datos en la clase tecnicos
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Borrartecnicos", Conn)
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

        // En esta parte tiene la funcion para actualizar los datos en la clase tecnicos
        public static int Actualizar(int codigo, string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Actualizartecnicos", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ESPECIALIDAD", especialidad));

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

        // En esta parte tiene la funcion para consultar los datos en la clase tecnicos
        public static List<Tecnicos> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Tecnicos> Tecnicos = new List<Tecnicos>();
            try
            {

                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Consultar_filtrotecnicos", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tecnicos Tecnico = new Tecnicos(reader.GetInt32(0), reader.GetString(1));
                            Tecnicos.Add(Tecnico);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Tecnicos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Tecnicos;
        }

        // En esta parte es la segunda programación para que al momento de consultar los datos en la clase tecnicos funcione
        public static List<Tecnicos> ObtenerTecnicos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Tecnicos> Tecnicos = new List<Tecnicos>();
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
                            Tecnicos Tecnico = new Tecnicos(reader.GetInt32(0), reader.GetString(1));
                            Tecnicos.Add(Tecnico);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Tecnicos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Tecnicos;
        }
    }
}