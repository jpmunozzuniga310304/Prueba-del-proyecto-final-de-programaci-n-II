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
    // En esta parte es toda la programación de la clase reporteequipos, para que esta parte del programa funcione correctamente
    public class Reporteequipos
    {
        // En esta parte son los codigos donde se almacena la datos digitados en la clase reporteequipos
        public int EquipoID { get; set; }
        public string Nombre { get; set; }
        public int AsignacionID { get; set; }
        public string FechaAsignacion { get; set; }
        public int ReparacionID { get; set; }
        public string FechaSolicitud { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }
        public string Nombre1 { get; set; }
        public string CorreoElectronico { get; set; }

        // En esta parte es un constructor de la clase reporteequipos con datos
        public Reporteequipos(string nombre, int asignacionID, string fechaAsignacion, int reparacionID, string fechaSolicitud, string estado, string descripcion, string tipoEquipo, string modelo, string nombre1, string correoElectronico)
        {
            Nombre = nombre;
            AsignacionID = asignacionID;
            FechaAsignacion = fechaAsignacion;
            ReparacionID = reparacionID;
            FechaSolicitud = fechaSolicitud;
            Estado = estado;
            Descripcion = descripcion;
            TipoEquipo = tipoEquipo;
            Modelo = modelo;
            Nombre1 = nombre1;
            CorreoElectronico = correoElectronico;
        }

        // En esta parte es un constructor para que funcione correctamente, la consulta de los datos digitados de la clase reporteequipos
        public Reporteequipos(int equipoID, string nombre, int asignacionID, string fechaAsignacion, int reparacionID, string fechaSolicitud, string estado, string descripcion, string tipoEquipo, string modelo, string nombre1, string correoElectronico)
        {
            EquipoID = equipoID;
            Nombre = nombre;
            AsignacionID = asignacionID;
            FechaAsignacion = fechaAsignacion;
            ReparacionID = reparacionID;
            FechaSolicitud = fechaSolicitud;
            Estado = estado;
            Descripcion = descripcion;
            TipoEquipo = tipoEquipo;
            Modelo = modelo;
            Nombre1 = nombre1;
            CorreoElectronico = correoElectronico;
        }

        // En esta parte es un constructor de la clase reporteequipos sin datos
        public Reporteequipos()
        {
        }

        // En esta parte tiene la funcion para consultar los datos en la clase reporteequipos
        public static List<Reporteequipos> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Reporteequipos> Reporteequipos = new List<Reporteequipos>();
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
                            Reporteequipos Reporteequipo = new Reporteequipos(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3),
                                reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11));
                            Reporteequipos.Add(Reporteequipo);

                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Reporteequipos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Reporteequipos;
        }

        // En esta parte es la segunda programación para que al momento de consultar los datos en la clase reporteequipos funcione
        public static List<Reporteequipos> ObtenerReporteequipos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<Reporteequipos> Reporteequipos = new List<Reporteequipos>();
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
                            Reporteequipos Reporteequipo = new Reporteequipos(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3),
                                reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11));
                            Reporteequipos.Add(Reporteequipo);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return Reporteequipos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return Reporteequipos;
        }
    }
}