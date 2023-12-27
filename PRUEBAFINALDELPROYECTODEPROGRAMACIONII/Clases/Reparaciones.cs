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
    // En esta parte es toda la programación de la clase reparaciones, para que esta parte del programa funcione correctamente
    public class Reparaciones
    {
        public int ReparacionID { get; set; }

        public int EquipoID { get; set; }

        public string FechaSolicitud { get; set; }

        public string Estado { get; set; }

        // En esta parte es un constructor de la clase reparaciones con datos
        public Reparaciones(int equipoID, string fechaSolicitud, string estado)
        {
            EquipoID = equipoID;
            FechaSolicitud = fechaSolicitud;
            Estado = estado;
        }

        // En esta parte es un constructor para que funcione correctamente, la consulta de los datos digitados de la clase reparaciones
        public Reparaciones(int reparacionID, int equipoID, string fechaSolicitud, string estado)
        {
            ReparacionID = reparacionID;
            EquipoID = equipoID;
            FechaSolicitud = fechaSolicitud;
            Estado = estado;
        }

        // En esta parte es un constructor de la clase reparaciones sin datos
        public Reparaciones()
        {
        }

        // En esta parte tiene la funcion para agregar nuevos datos en la clase reparaciones
        public static int Agregar(int equipoID, string fechaSolicitud, string estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Agregarreparaciones", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOID", equipoID));
                    cmd.Parameters.Add(new SqlParameter("@FECHASOLICITUD", fechaSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", estado));

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

        // En esta parte tiene la funcion para borrar los datos en la clase reparaciones
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Borrarreparaciones", Conn)
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

        // En esta parte tiene la funcion para actualizar los datos en la clase reparaciones
        public static int Actualizar(int codigo, int equipoid, string fechasolicitud, string estado)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Actualizarreparaciones", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOID", equipoid));
                    cmd.Parameters.Add(new SqlParameter("@FECHASOLICITUD", fechasolicitud));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", estado));

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

        // En esta parte tiene la funcion para consultar los datos en la clase reparaciones
        public static List<Reparaciones> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Reparaciones> Reparaciones = new List<Reparaciones>();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Consultar_filtroreparaciones", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reparaciones Reparacion = new Reparaciones(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));
                            Reparaciones.Add(Reparacion);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Reparaciones;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Reparaciones;
        }

        // En esta parte es la segunda programación para que al momento de consultar los datos en la clase reparaciones funcione
        public static List<Reparaciones> ObtenerReparaciones()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Reparaciones> Reparaciones = new List<Reparaciones>();
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
                            Reparaciones Reparacion = new Reparaciones(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));  // instancia
                            Reparaciones.Add(Reparacion);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Reparaciones;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Reparaciones;
        }
    }
}