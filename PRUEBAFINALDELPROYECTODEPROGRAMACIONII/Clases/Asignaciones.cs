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
    // En esta parte es toda la programación de la clase asignaciones, para que esta parte del programa funcione correctamente
    public class Asignaciones
    {
        // En esta parte son los codigos donde se almacena los datos digitados en la clase asignaciones
        public int AsignacionID { get; set; }

        public int ReparacionID { get; set; }

        public int TecnicoID { get; set; }

        public string FechaAsignacion { get; set; }

        // En esta parte es un constructor de la clase asignaciones con datos
        public Asignaciones(int reparacionID, int tecnicoID, string fechaAsignacion)
        {
            ReparacionID = reparacionID;
            TecnicoID = tecnicoID;
            FechaAsignacion = fechaAsignacion;
        }

        // En esta parte es un constructor de la clase asignacione sin datos
        public Asignaciones()
        {
        }

        // En esta parte es un constructor para que funcione correctamente, la consulta de los datos digitados de la clase asignaciones
        public Asignaciones(int asignacionID, int reparacionID, int tecnicoID, string fechaAsignacion)
        {
            AsignacionID = asignacionID;
            ReparacionID = reparacionID;
            TecnicoID = tecnicoID;
            FechaAsignacion = fechaAsignacion;
        }

        // En esta parte tiene la funcion para agregar nuevos datos en la clase asignaciones
        public static int Agregar(int ReparacionID, int TecnicoID, string FechaAsignacion)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Agregarasignaciones", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", ReparacionID));
                    cmd.Parameters.Add(new SqlParameter("@TECNICOID", TecnicoID));
                    cmd.Parameters.Add(new SqlParameter("@FECHAASIGNACION", FechaAsignacion));

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

        // En esta parte tiene la funcion para borrar los datos en la clase asignaciones
        public static int Borrar(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Borrarasignaciones", Conn)
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

        // En esta parte tiene la funcion para actualizar los datos en la clase asignaciones
        public static int Actualizar(int codigo, int reparacionid, int tecnicoid, string fechaasignacion)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Actualizarasignaciones", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@REPARACIONID", reparacionid));
                    cmd.Parameters.Add(new SqlParameter("@TECNICOID", tecnicoid));
                    cmd.Parameters.Add(new SqlParameter("@FECHAASIGNACION", fechaasignacion));

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

        // En esta parte tiene la funcion para consultar los datos en la clase asignaciones
        public static List<Asignaciones> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Asignaciones> Asignaciones = new List<Asignaciones>();
            try
            {

                using (Conn = DBConn.obtenerConexion2())
                {
                    SqlCommand cmd = new SqlCommand("Consultar_filtroasignaciones", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Asignaciones Asignacion = new Asignaciones(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3));  // instancia
                            Asignaciones.Add(Asignacion);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Asignaciones;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Asignaciones;
        }

        // En esta parte tiene es la segunda programación para que al momento de consultar los datos en la clase asignaciones funcione
        public static List<Asignaciones> ObtenerAsignaciones()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Asignaciones> Asignaciones = new List<Asignaciones>();
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
                            Asignaciones Asignacion = new Asignaciones(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3));
                            Asignaciones.Add(Asignacion);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Asignaciones;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Asignaciones;
        }
    }
}