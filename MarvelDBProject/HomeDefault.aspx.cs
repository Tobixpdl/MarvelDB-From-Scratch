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
        private int currentPage = 1;
        //NUMERO DE CARDS POR PAGINA
        private int pageSize = 9;
        private int pageNumber = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pageNumber = 1;
                currentPage = pageNumber;

                LoadCharacters(pageNumber);
                BindPagination();
            }
        }
        private void LoadCharacters(int pageNumber)
        {
            List<Character> characters = NegocioCharacter.Listar(pageNumber, pageSize);

            rprCharacters.DataSource = characters;
            rprCharacters.DataBind();
        }

        private void BindPagination()
        {
            int totalCharacters = NegocioCharacter.GetTotalCharacterCount();
            int totalPages = (int)Math.Ceiling((double)totalCharacters / pageSize);

            List<object> paginationData = new List<object>();
            for (int i = 1; i <= totalPages; i++)
            {
               paginationData.Add(new { PageNumber = i, CssClass = i == currentPage ? "active" : "" });
            }

            rprPagination.DataSource = paginationData;
            rprPagination.DataBind();
        }

        protected void rprPagination_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "PageNumber")
            {
                // Get the clicked link button
                LinkButton clickedButton = (LinkButton)e.CommandSource;

                // Get the page number from the CommandArgument of the clicked button
                pageNumber = int.Parse(clickedButton.CommandArgument);

                // Load the characters for the clicked page
                LoadCharacters(pageNumber);

                // Set the current page number
                currentPage = pageNumber;

                // Update the pagination links
                BindPagination();
            }
        }
    }
}