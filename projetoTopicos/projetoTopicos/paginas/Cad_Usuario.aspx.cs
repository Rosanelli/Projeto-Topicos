using projetoTopicos.classes;
using projetoTopicos.classes.AD;
using projetoTopicos.classes.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projetoTopicos.paginas.cadastro
{
    public partial class Cad_Usuario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioEN user = (UsuarioEN)Session["usuario"];

            if (user._tipo != "admin")
            {
                Response.Redirect("~/paginas/Principal.aspx");
            }

            if (!IsPostBack)
            {
                radiolist_TipoUsuario.SelectedIndex = 0;
            }

            

            PopulaGridUsuario();

        }

        private void PopulaGridUsuario()
        {
            grvUsuario.DataSource = UsuarioAD.Busca_Todos_Usuario();
            grvUsuario.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioEN usuario_Modificar = (UsuarioEN)Session["usuario_Modificar"];

                if (Session["altera"] == null)
                    Session["altera"] = false;

                if ((bool)Session["altera"] == true)
                {
                    if (txtNome.Text != usuario_Modificar._nome)
                    {
                        usuario_Modificar._nome = txtNome.Text;
                        Session["modificado"] = true;
                    }
                    if (txtUsuario.Text != usuario_Modificar._usuario)
                    {
                        usuario_Modificar._usuario = txtUsuario.Text;
                        Session["modificado"] = true;
                    }
                    if (MD5.getMD5Hash(txtSenha.Text) != usuario_Modificar._senha)
                    {
                        usuario_Modificar._senha = MD5.getMD5Hash(txtSenha.Text);
                        Session["modificado"] = true;
                    }

                    if (radiolist_TipoUsuario.SelectedValue != usuario_Modificar._tipo)
                    {
                        usuario_Modificar._tipo = radiolist_TipoUsuario.SelectedValue;
                        Session["modificado"] = true;
                    }

                    if ((bool)Session["modificado"] == true)
                    {
                        UsuarioEN user_Alterado = new UsuarioEN();
                        user_Alterado._id = (int)Session["id"];
                        user_Alterado._nome = txtNome.Text;
                        user_Alterado._usuario = txtUsuario.Text;
                        user_Alterado._senha = MD5.getMD5Hash(txtSenha.Text);
                        user_Alterado._tipo = radiolist_TipoUsuario.SelectedValue;

                        UsuarioAD.AlteraUsuario(user_Alterado);

                        lblException.ForeColor = System.Drawing.Color.Green;
                        lblException.Text = "Alterado com Sucesso !";
                    }

                    Session["altera"] = false;
                    Session["modificado"] = false;

                    LimpaCampos();

                    PopulaGridUsuario();

                }
                else
                {
                    UsuarioEN en = new UsuarioEN();

                    en._nome = txtNome.Text;
                    en._usuario = txtUsuario.Text;
                    en._senha = MD5.getMD5Hash(txtSenha.Text);

                    if (radiolist_TipoUsuario.SelectedIndex == 0)
                        en._tipo = "admin";
                    else
                        en._tipo = "comum";

                    UsuarioAD.InseriUsuario(en);

                    lblException.ForeColor = System.Drawing.Color.Green;
                    lblException.Text = "Incluído com Sucesso !";

                    PopulaGridUsuario();
                }
            }
            catch (Exception ex)
            {
                lblException.ForeColor = System.Drawing.Color.Red;
                lblException.Text = ex.Message;
            }

        }

        private void LimpaCampos()
        {

            txtNome.Text = "";
            txtSenha.Text = "";
            txtUsuario.Text = "";

            radiolist_TipoUsuario.SelectedIndex = 0;
        }

        protected void btnAltera_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            int id = Convert.ToInt32(button.CommandArgument);

            try
            {
                Session["altera"] = true;

                UsuarioEN usuario_Modificar = UsuarioAD.BuscaUsuario(id);

                Session["usuario_Modificar"] = usuario_Modificar;

                Session["id"] = id;

                txtNome.Text = usuario_Modificar._nome;
                txtUsuario.Text = usuario_Modificar._usuario;
                txtSenha.Text = usuario_Modificar._senha;

                if (usuario_Modificar._tipo == "admin")
                    radiolist_TipoUsuario.SelectedIndex = 0;
                else
                    radiolist_TipoUsuario.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                lblException.ForeColor = System.Drawing.Color.Red;
                lblException.Text = ex.Message;
            }
        }

        protected void btnExclui_Click(object sender, EventArgs e)
        {
            try
            {
                var button = sender as Button;
                int id = Convert.ToInt32(button.CommandArgument);

                UsuarioAD.ExcluiUsuario(id);

                PopulaGridUsuario();

                lblException.ForeColor = System.Drawing.Color.Green;
                lblException.Text = "Excluido com Sucesso!";
            }
            catch (Exception ex)
            {
                lblException.ForeColor = System.Drawing.Color.Red;
                lblException.Text = ex.Message;
            }
        }

        protected void grvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvUsuario.PageIndex = e.NewPageIndex;
            PopulaGridUsuario();
        }

        protected void grvUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes.Add("onMouseOver", "this.style.backgroundColor='#778899'; this.style.cursor='hand';");

                e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor='#ffffff'");

            }
        }

    }
}