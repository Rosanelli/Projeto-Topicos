using projetoTopicos.classes.AD;
using projetoTopicos.classes.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projetoTopicos.paginas
{
    public partial class Cad_Cliente : System.Web.UI.Page
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
                radiolist_Sexo.SelectedIndex = 0;
            }

            PopulaGridCliente();
        }

        private void PopulaGridCliente()
        {
            grvCliente.DataSource = ClienteAD.Busca_Todos_Clientes();
            grvCliente.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteEN cliente_Modificar = (ClienteEN)Session["cliente_Modificar"];

                if (Session["altera"] == null)
                    Session["altera"] = false;

                if ((bool)Session["altera"] == true)
                {
                    if (txtNome.Text != cliente_Modificar._Nome)
                    {
                        cliente_Modificar._Nome = txtNome.Text;
                        Session["modificado"] = true;
                    }
                    if (txtTelefone.Text != cliente_Modificar._telefone)
                    {
                        cliente_Modificar._telefone = txtTelefone.Text;
                        Session["modificado"] = true;
                    }
                    if (radiolist_Sexo.SelectedValue != cliente_Modificar._Sexo)
                    {
                        cliente_Modificar._Sexo = radiolist_Sexo.SelectedValue;
                        Session["modificado"] = true;
                    }

                    if ((bool)Session["modificado"] == true)
                    {
                        ClienteEN cliente_Alterado = new ClienteEN();
                        cliente_Alterado._ID = (int)Session["id"];
                        cliente_Alterado._Nome = txtNome.Text;
                        cliente_Alterado._telefone = txtTelefone.Text;
                        cliente_Alterado._Sexo = radiolist_Sexo.SelectedValue;
                        
                        ClienteAD.AlteraCliente(cliente_Alterado);

                        lblException.ForeColor = System.Drawing.Color.Green;
                        lblException.Text = "Alterado com Sucesso !";
                    }

                    Session["altera"] = false;
                    Session["modificado"] = false;

                    LimpaCampos();

                    PopulaGridCliente();

                }
                else
                {
                    ClienteEN en = new ClienteEN();

                    en._Nome = txtNome.Text;
                    en._telefone = txtTelefone.Text;
                    
                    if (radiolist_Sexo.SelectedIndex == 0)
                        en._Sexo = "masculino";
                    else
                        en._Sexo = "feminino";

                    ClienteAD.InseriCliente(en);

                    lblException.ForeColor = System.Drawing.Color.Green;
                    lblException.Text = "Incluído com Sucesso !";

                    PopulaGridCliente();
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
            txtTelefone.Text = "";
            
            radiolist_Sexo.SelectedIndex = 0;
        }

        protected void btnExclui_Click(object sender, EventArgs e)
        {
            try
            {
                var button = sender as Button;
                int id = Convert.ToInt32(button.CommandArgument);

                ClienteAD.ExcluiCliente(id);

                PopulaGridCliente();

                lblException.ForeColor = System.Drawing.Color.Green;
                lblException.Text = "Excluido com Sucesso!";
            }
            catch (Exception ex)
            {
                lblException.ForeColor = System.Drawing.Color.Red;
                lblException.Text = ex.Message;
            }
        }

        protected void btnAltera_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            int id = Convert.ToInt32(button.CommandArgument);

            try
            {
                Session["altera"] = true;

                ClienteEN cliente_Modificar = ClienteAD.BuscaCliente(id);

                Session["cliente_Modificar"] = cliente_Modificar;

                Session["id"] = id;

                txtNome.Text = cliente_Modificar._Nome;
                txtTelefone.Text = cliente_Modificar._telefone;

                if (cliente_Modificar._Sexo == "masculino")
                    radiolist_Sexo.SelectedIndex = 0;
                else
                    radiolist_Sexo.SelectedIndex = 1;

            }
            catch (Exception ex)
            {
                lblException.ForeColor = System.Drawing.Color.Red;
                lblException.Text = ex.Message;
            }
        }

        protected void grvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCliente.PageIndex = e.NewPageIndex;
            PopulaGridCliente();
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