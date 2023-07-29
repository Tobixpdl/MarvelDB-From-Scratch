using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarvelDBProject
{
    public partial class MoreInfo : System.Web.UI.Page
    {
        NegocioCharacter ng = new NegocioCharacter();
        public Character Character { get; set; }

        NegocioMovie nm = new NegocioMovie();
        public Movie Movie { get; set; }

        NegocioSerie ns = new NegocioSerie();
        public Serie Serie { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"];
            string movie_Id = Request.QueryString["movie_Id"];
            string serie_Id = Request.QueryString["serie_Id"];

            if (id != null)
            {
                int.TryParse(id, out int idValue);
                Character = ng.ListarXID(idValue);
            }
            else if (movie_Id != null)
            {
                List<Imagen> images = new List<Imagen>();
                int.TryParse(movie_Id, out int movieIdValue);
                Movie = nm.ListarXID(movieIdValue);
                images = Movie.Images;
                rprMovieImages.DataSource = images;
                rprMovieImages.DataBind();
            }
            else if (serie_Id != null)
            {
                List<Imagen> images = new List<Imagen>();
                int.TryParse(serie_Id, out int SerieIdValue);
                Serie = ns.ListByID(SerieIdValue);
                images = Serie.Images;
                rprSerieImages.DataSource = images;
                rprSerieImages.DataBind();
            }
        }
    }
}