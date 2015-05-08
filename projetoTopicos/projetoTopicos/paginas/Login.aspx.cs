using projetoTopicos.classes;
using projetoTopicos.classes.AD;
using projetoTopicos.classes.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projetoTopicos.paginas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUsuario.TabIndex = 0;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string senha = MD5.getMD5Hash(txtSenha.Text); // Realiza hash MD5 da senha

            UsuarioEN en = UsuarioAD.AutenticaUsuario(txtUsuario.Text, senha);

            if (en == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Usuario ou Senha incorretos!')", true);
            }
            else
            {
                Session["usuario"] = en;

                FormsAuthentication.RedirectFromLoginPage(en._nome, false);// implementar checkbox para persistir login
            }
        }
    }
}