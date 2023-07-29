using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioEpisode
    {
        public List<Episode> Listar(int id)
        {
            List<Episode> lista = new List<Episode>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($@"
                SELECT e.episode_id, e.series_id, e.name, e.description,  e.duration, 
                e.season FROM Episodes e where e.series_id = @id");
                datos.setearParametro("@id", id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Episode aux = new Episode();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Series_Id = datos.Lector.GetInt32(1);
                    aux.Name = (string)datos.Lector["name"];
                    aux.Description = (string)datos.Lector["description"];
                    aux.Duration = (int)datos.Lector["duration"];
                    aux.Season = (int)datos.Lector["season"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
