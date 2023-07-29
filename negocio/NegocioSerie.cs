using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioSerie
    {
        public List<Serie> Listar()
        {
            List<Serie> lista = new List<Serie>();
            AccesoDatos datos = new AccesoDatos();
            NegocioImagen negocioImagen = new NegocioImagen();
            NegocioEpisode negocioEpisode = new NegocioEpisode();

            try
            {
                datos.setearConsulta($@"
                SELECT s.series_id, s.name, s.description, s.episodes, s.phase, 
                s.ReleaseDate, s.seasons FROM Series s");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Serie aux = new Serie();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Name = (string)datos.Lector["name"];
                    aux.Description = (string)datos.Lector["description"];

                    aux.Episodes = negocioEpisode.Listar(aux.Id);

                    aux.Phase = (int)datos.Lector["Phase"];
                    aux.ReleaseDate = (DateTime)datos.Lector["ReleaseDate"];
                    aux.Seasons = (int)datos.Lector["seasons"];

                    aux.Images = negocioImagen.listFSeries(aux.Id);

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

        public Serie ListByID(int id)
        {
            Serie lista = new Serie();
            AccesoDatos datos = new AccesoDatos();
            NegocioImagen negocioImagen = new NegocioImagen();
            NegocioEpisode negocioEpisode = new NegocioEpisode();

            try
            {
                datos.setearConsulta($@"
                SELECT 
                    s.series_id,
                    s.name,
                    s.description,
                    s.episodes,
                    s.phase,
                    s.ReleaseDate,
                    s.seasons,
                    COALESCE(total_duration.total_duration, 0) AS total_duration
                FROM
                    Series s
                LEFT JOIN
                    (
                        SELECT
                            series_id,
                            SUM(duration) AS total_duration
                        FROM
                            Episodes
                        GROUP BY
                            series_id
                    ) total_duration ON s.series_id = total_duration.series_id
                WHERE
                    s.series_id = @id;
                ");

                datos.setearParametro("@id", id);
                datos.ejecutarLectura(); 

                if (datos.Lector.Read())
                {
                    Serie aux = new Serie();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Name = (string)datos.Lector["name"];
                    aux.Description = (string)datos.Lector["description"];

                    aux.Episodes = negocioEpisode.Listar(aux.Id);

                    aux.Phase = (int)datos.Lector["Phase"];
                    aux.ReleaseDate = (DateTime)datos.Lector["ReleaseDate"];
                    aux.Seasons = (int)datos.Lector["seasons"];
                    aux.FullDuration = (int)datos.Lector["total_duration"];

                    aux.Images = negocioImagen.listFSeries(aux.Id);
                    lista = aux;
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
