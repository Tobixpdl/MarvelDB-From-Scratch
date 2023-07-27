using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace MarvelDBProject
{
    public partial class Login : System.Web.UI.Page
    {
        public List<Usuario> UserList { get; set; }
        public int UserId { get; set; }

        NegocioUsuario negocioUser = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserList = negocioUser.GetAllUsers();

            if (this.Session["isUser"] != null)
            {
                Response.Redirect("HomeDefault.aspx", false);
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {

            if (negocioUser.LogUser(txtUsername.Text, txtPassword.Text))
            {
                Session.Add("activeUser", negocioUser.listByUsername(txtUsername.Text));
                Session.Add("isUser", true);

                Response.Redirect("HomeDefault.aspx", false);
            }
            else
            {
                string message = "Check the values!";
                lblMessage.Text = message;
                lblMessage.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
}