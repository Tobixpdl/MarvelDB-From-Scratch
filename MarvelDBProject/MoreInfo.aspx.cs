using dominio;
using negocio;
using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"];

            if (int.TryParse(id, out int idValue))
            {
                Character = ng.ListarXID(idValue);
            }
        }

    }
}