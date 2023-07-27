using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarvelDBProject
{
    public partial class Movies : System.Web.UI.Page
    {
        NegocioMovie NegocioMovie = new NegocioMovie();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMovies();
            }
        }
        private void LoadMovies()
        {
            List<Movie> movies = NegocioMovie.Listar();

            rprCharacters.DataSource = movies;
            rprCharacters.DataBind();
        }
    }
}