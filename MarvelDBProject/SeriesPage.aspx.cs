using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarvelDBProject
{
    public partial class SeriesPage : System.Web.UI.Page
    {
        NegocioSerie NegocioSerie = new NegocioSerie();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSeries();
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
                    negocioFavourites.addFavourite(idInteger, user, NegocioFavourites.Types.series);
                }
            }
        }
        private void LoadSeries()
        {
            List<Serie> series = NegocioSerie.Listar();

            rprSeries.DataSource = series;
            rprSeries.DataBind();
        }
    }
}