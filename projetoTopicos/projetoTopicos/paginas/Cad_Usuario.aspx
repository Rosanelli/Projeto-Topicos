<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Cad_Usuario.aspx.cs" Inherits="projetoTopicos.paginas.cadastro.Cad_Usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="menu-left">
        <div>
            <asp:TextBox ID="txtNome" class="form-control" Style="width: 300px" placeholder="Nome" runat="server" />
            <br />
            <asp:TextBox ID="txtUsuario" class="form-control" Style="width: 300px" placeholder="Usuário" runat="server" />
            <br />
            <asp:TextBox ID="txtSenha" class="form-control" Style="width: 300px" placeholder="Senha" TextMode="Password" runat="server" />
            <br />
            <asp:Label Text="Tipo Usuário" runat="server" />
            <asp:RadioButtonList ID="radiolist_TipoUsuario" runat="server">
                <asp:ListItem Text="admin" />
                <asp:ListItem Text="comum" />
            </asp:RadioButtonList>

            <asp:Label ID="lblException" runat="server" />
            <br />

            <asp:Button ID="btnSalvar" class="btn btn-lg btn-primary" Text="Salvar" OnClick="btnSalvar_Click" runat="server" />
        </div>
    </div>


    <div class="menu-right">
        <asp:GridView ID="grvUsuario" runat="server" AllowPaging="True" Style="width: 500px;" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" BackColor="White" BorderStyle="Inset" BorderColor="Black" RowStyle-BorderStyle="Outset" HeaderStyle-BorderStyle="Outset" HeaderStyle-BorderColor="Black" RowStyle-VerticalAlign="Middle" HeaderStyle-BorderWidth="1pt" AlternatingRowStyle-BorderStyle="Outset" OnRowDataBound="grvUsuario_RowDataBound" PageSize="10" PagerSettings-Mode="Numeric" OnPageIndexChanging="grvUsuario_PageIndexChanging" HeaderStyle-BackColor="#CCCCCC">
            <AlternatingRowStyle BorderStyle="Outset"></AlternatingRowStyle>
            <Columns>

                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate>
                        <asp:Label ID="lblNome" Text='<%# Eval("_nome")  %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Usuário">
                    <ItemTemplate>
                        <asp:Label ID="lblUsuario" Text='<%# Eval("_usuario")  %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tipo">
                    <ItemTemplate>
                        <asp:Label ID="lblTipo" Text='<%# Eval("_tipo")  %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnAltera" class="btn btn-lg btn-primary" Text="Alterar" Style="height: 35px;" runat="server" OnClick="btnAltera_Click" CommandArgument='<%# Eval("_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnExclui" class="btn btn-lg btn-danger" Text="Excluir" Style="height: 35px;" runat="server" OnClick="btnExclui_Click" CommandArgument='<%# Eval("_id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

            <HeaderStyle BorderColor="Black" BorderWidth="1pt" BorderStyle="Outset"></HeaderStyle>

            <RowStyle VerticalAlign="Middle" BorderStyle="Outset"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>
