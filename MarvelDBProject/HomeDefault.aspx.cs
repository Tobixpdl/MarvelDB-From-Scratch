using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace MarvelDBProject
{
    public partial class HomeDefault : System.Web.UI.Page
    {
        NegocioCharacter NegocioCharacter = new NegocioCharacter();
        List<Character> characters = new List<Character>();
        protected void Page_Load(object sender, EventArgs e)
        {
            characters = NegocioCharacter.Listar();

            rprCharacters.DataSource = characters;
            rprCharacters.DataBind();
        }
    }
}