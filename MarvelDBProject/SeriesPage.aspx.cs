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
        }
        private void LoadSeries()
        {
            List<Serie> series = NegocioSerie.Listar();

            rprSeries.DataSource = series;
            rprSeries.DataBind();
        }
    }
}