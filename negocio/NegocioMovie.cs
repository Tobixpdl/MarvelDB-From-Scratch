using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioMovie
    {
        public List<Movie> Listar()
        {
            List<Movie> lista = new List<Movie>();
            AccesoDatos datos = new AccesoDatos();
            NegocioImagen negocioImagen = new NegocioImagen();

            try
            {
                datos.setearConsulta($@"
                SELECT m.movie_id, m.name, m.description, m.phase, m.duration,
                m.ReleaseDate FROM Movies m");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Movie aux = new Movie();
                    aux.Id = datos.Lector.GetInt32(0);
                    aux.Name = datos.Lector.GetString(1);
                    aux.Description = datos.Lector.GetString(2);
                    aux.Phase = (int)datos.Lector["Phase"];
                    aux.Duration = (int)datos.Lector["duration"];
                    aux.ReleaseDate = (DateTime)datos.Lector["ReleaseDate"];

                    aux.Images = negocioImagen.listFMovie(aux.Id);

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

        public Movie ListarXID(int id)
        {
            Movie lista = new Movie();
            AccesoDatos datos = new AccesoDatos();
            NegocioImagen negocioImagen = new NegocioImagen();

            try
            {
                datos.setearConsulta($@"
                SELECT m.movie_id, m.name, m.description, m.phase, m.duration,
                m.ReleaseDate FROM Movies m
                where m.movie_id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura(); ;

                while (datos.Lector.Read())
                {
                    lista.Id = datos.Lector.GetInt32(0);
                    lista.Name = datos.Lector.GetString(1);
                    lista.Description = datos.Lector.GetString(2);
                    lista.Phase = (int)datos.Lector["Phase"];
                    lista.Duration = (int)datos.Lector["duration"];
                    lista.ReleaseDate = (DateTime)datos.Lector["ReleaseDate"];

                    lista.Images = negocioImagen.listFMovie(lista.Id);
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
