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
            if (Request.QueryString["Id"] != null)
            {
                string id = Request.QueryString["Id"];
                int.TryParse(id, out int idInteger);
                Usuario user = (Usuario)this.Session["activeUser"];

                if (user == null)
                {
                    Response.Redirect("Login.aspx", true);
                }
                else
                {
                    NegocioFavourites negocioFavourites = new NegocioFavourites();
                    negocioFavourites.addFavourite(idInteger, user, NegocioFavourites.Types.movie);
                }
            }
        }
        private void LoadMovies()
        {
            List<Movie> movies = NegocioMovie.Listar();

            rprMovies.DataSource = movies;
            rprMovies.DataBind();
        }
    }
}