using projetoTopicos.classes.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projetoTopicos
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        
        protected void btnSair_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["usuario"] = null;
            Response.Redirect("~/paginas/Principal.aspx");
        }
    }
}