using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioFavourites
    {
        public enum Types
        {
            character,
            series,
            movie
        }
        public void addFavourite(int id, Usuario user, Types type)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearConsulta("SELECT COUNT(*) FROM favourites WHERE userID = " + user.Id + " and " + type.ToString() + "_id = " + id + "");

            try
            {
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    int count = Convert.ToInt32(datos.Lector[0]);
                    datos.cerrarConexion();

                    if (count == 0)
                    {
                        datos.setearConsulta("INSERT into favourites(" + type.ToString() + "_id,UserID)" +
                                             " values ('" + id + "','" + user.Id + "')");
                        datos.ejecutarAccion();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
