using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarvelDBProject
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuarios { get; set; }
        public NegocioUsuario negocioU = new NegocioUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaUsuarios = negocioU.GetAllUsers();
            LabelsVisibility("false");

            if (this.Session["activeUser"] != null)
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            txtUsername.CssClass = "inputs";
            txtMail.CssClass = "inputs";
            txtDNI.CssClass = "inputs";
            TextBox1.CssClass = "inputs";
            txtFullName.CssClass = "inputs";
            TextBox1.CssClass = "inputs";
            txtPassword.CssClass = "inputs";

            Regex rex = new Regex(@"^[a-zA-Z\s]+$");

            bool canCreateUser = true;
            Usuario newUser = new Usuario();
            newUser.Username = txtUsername.Text;
            newUser.FullName = txtFullName.Text;
            newUser.Email = txtMail.Text;

            if (int.TryParse(txtDNI.Text, out int RealDNI))
            {
                newUser.DNI = RealDNI;
            }
            else
            {
                txtDNI.CssClass = "wrongInput";
                lblWrongDNI.Visible = true;
            }

            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text, salt);

            newUser.Salt = salt;
            newUser.HashPass = hashedPassword;

            if (string.IsNullOrEmpty(newUser.Username))
            {
                lblMissing.Visible = true;
                lblWrongUser.Text = "Debe ingresar un usuario";
                lblWrongUser.Visible = true;
                txtUsername.CssClass = "wrongInput";
                canCreateUser = false;
            }

            if (string.IsNullOrEmpty(newUser.FullName) || !rex.IsMatch(newUser.FullName))
            {
                txtFullName.CssClass = "wrongInput";
                canCreateUser = false;
                lblWrongFullName.Visible = true;
            }

            if (string.IsNullOrEmpty(newUser.Email))
            {
                lblWrongMail.Visible = true;
                txtMail.CssClass = "wrongInput";
                canCreateUser = false;
            }

            if (string.IsNullOrEmpty(newUser.HashPass) || txtPassword.Text != TextBox1.Text)
            {
                txtPassword.CssClass = "wrongInput";
                TextBox1.CssClass = "wrongInput";
                canCreateUser = false;
                lblWrongPass2.Visible = true;
            }

            if (txtPassword.Text != TextBox1.Text)
            {
                lblWrongPass2.Visible = true;
                canCreateUser = false;
                TextBox1.CssClass = "wrongInput";
            }

            //CREACION DEL USUARIO
            if (canCreateUser && negocioU.IsUsernameAvailable(newUser.Username) 
                              && negocioU.IsEmailAvailable(newUser.Email)
                              && negocioU.IsFullNameAvailable(newUser.FullName)
               )
            {
                negocioU.CreateUser(newUser);
                lblIsUserCreated.Text = "Usuario creado";
                lblIsUserCreated.Visible = true;
                Session.Add("activeUser", newUser);
                Session.Add("isUser", true);

                //EmailService mail = new EmailService();
                //mail.armarCorreo(newUser.Email, "Bienvenido!", "Hola " + newUser.Username + "! \r\n" +
                //    "¡Gracias por registrarte en BuyEverything! Esperamos que tengas una gran experiencia en nuestro" +
                //    " sitio de compras y ventas.\r\n      En BuyEverything, puedes comprar una amplia variedad de productos y también vender tus propios artículos. ¡Explora las ofertas y encuentra lo que necesitas!\r\n      Si tienes alguna pregunta o necesitas ayuda, no dudes en ponerte en contacto con nuestro equipo de soporte.\r\n\n\n¡Disfruta de tu experiencia en BuyEverything!", true);
                //mail.enviarEmail();

                //In the future it should redirect to a MyProfile page
                Response.Redirect("HomeDefault.aspx", false);
            }
            else
            {
                lblIsUserCreated.Text = "No fue posible crear el usuario";
                lblIsUserCreated.Visible = true;
            }
        }

        private void LabelsVisibility(string t)
        {
            if (t == "false")
            {
                lblMissing.Visible = false;
                lblWrongMail.Visible = false;
                lblWrongPass2.Visible = false;
                lblWrongUser.Visible = false;
                lblIsUserCreated.Visible = false;
                lblWrongFullName.Visible = false;
                lblWrongDNI.Visible = false;
            }
            else
            {
                lblMissing.Visible = true;
                lblWrongMail.Visible = true;
                lblWrongPass2.Visible = true;
                lblWrongUser.Visible = true;
                lblIsUserCreated.Visible = true;
                lblWrongFullName.Visible = true;
                lblWrongDNI.Visible = true;
            }
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
    }
}