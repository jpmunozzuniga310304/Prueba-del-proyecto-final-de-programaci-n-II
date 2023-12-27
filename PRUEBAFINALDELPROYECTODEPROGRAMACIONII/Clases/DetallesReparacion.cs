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
    // En esta parte es toda la programación de la clase detallesreparacion, para que esta parte del programa funcione correctamente
    public class DetallesReparacion
    {
        // En esta parte son los codigos donde se almacena los datos digitados en la clase detallesreparacion
        public int DetalleID { get; set; }

        public int ReparacionID { get; set; }

        public string Descripcion { get; set; }

        public string FechaInicio { get; set; }

        public string FechaFin { get; set; }

        // En esta parte es un constructor de la clase detallesreparacion con datos
        public DetallesReparacion(int reparacionID, string descripcion, string fechaInicio, string fechaFin)
        {
            ReparacionID = reparacionID;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        // En esta parte es un constructor de la clase detallesreparacion sin datos
        public DetallesReparacion()
        {
        }

        // En esta parte es un constructor para que funcione correctamente, la consulta de los datos digitados de la clase detallesreparacion
        public DetallesReparacion(int detalleID, int reparacionID, string descripcion, string fechaInicio, string fechaFin)
        {
            DetalleID = detalleID;
            ReparacionID = reparacionID;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        // En esta parte tiene la funcion para agregar nuevos datos en la clase detallesreparacion
        public static int Agregar(int reparacionID, string descripcion, string fechainicio, string fechafin)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Agregardetallesreparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionID));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", fechainicio));
                    cmd.Parameters.Add(new SqlParameter("@FECHAFIN", fechafin));

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

        // En esta parte tiene la funcion para borrar los datos en la clase detallesreparacion
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Borrardetallesreparacion", Conn)
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

        // En esta parte tiene la funcion para actualizar los datos de la clase detallesreparacion
        public static int Actualizar(int codigo, int reparacionid, string descripcion, string fechainicio, string fechafin)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Actualizardetallesreparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionid));
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", fechainicio));
                    cmd.Parameters.Add(new SqlParameter("@FECHAFIN", fechafin));


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

        // En esta parte tiene la funcion para consultar los datos en la clase detallesreparacion
        public static List<DetallesReparacion> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<DetallesReparacion> DetallesReparacion = new List<DetallesReparacion>();
            try
            {

                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Consultar_filtrodetallesreparacion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DetallesReparacion DetallesReparacionconsulta = new DetallesReparacion(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));  // instancia
                            DetallesReparacion.Add(DetallesReparacionconsulta);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return DetallesReparacion;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return DetallesReparacion;
        }

        // En esta parte es la segunda programación para que al momento de consultar los datos en la clase detallesreparacion funcione
        public static List<DetallesReparacion> ObtenerDetallesReparacion()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<DetallesReparacion> DetallesReparacion = new List<DetallesReparacion>();
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
                            DetallesReparacion DetallesReparacionconsulta = new DetallesReparacion(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                            DetallesReparacion.Add(DetallesReparacionconsulta);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return DetallesReparacion;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return DetallesReparacion;
        }
    }
}