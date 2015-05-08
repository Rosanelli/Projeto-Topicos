<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Cad_Cliente.aspx.cs" Inherits="projetoTopicos.paginas.Cad_Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="menu-left">
        <div>
            <asp:TextBox ID="txtNome" class="form-control" Style="width: 300px" placeholder="Nome" runat="server" />
            <br />
            <asp:TextBox ID="txtTelefone" class="form-control" type="tel"  Style="width: 300px" placeholder="Telefone" runat="server" />
            <br />
            <br />
            <asp:Label ID="lblSexo" Text="Sexo" runat="server" />
            <asp:RadioButtonList ID="radiolist_Sexo" runat="server">
                <asp:ListItem Text="masculino" />
                <asp:ListItem Text="feminino" />
            </asp:RadioButtonList>
            <br />
            
            <asp:Label ID="lblException" runat="server" />
            <br />

            <asp:Button ID="btnSalvar" class="btn btn-lg btn-primary" Text="Salvar" OnClick="btnSalvar_Click" runat="server" />
        </div>
    </div>


    <div class="menu-right">
        <asp:GridView ID="grvCliente"  runat="server" AllowPaging="True" Style="width: 500px;" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" BackColor="White" BorderStyle="Inset" BorderColor="Black" RowStyle-BorderStyle="Outset" HeaderStyle-BorderStyle="Outset" HeaderStyle-BorderColor="Black" RowStyle-VerticalAlign="Middle" HeaderStyle-BorderWidth="1pt" AlternatingRowStyle-BorderStyle="Outset" OnRowDataBound="grvUsuario_RowDataBound" PageSize="10" PagerSettings-Mode="Numeric" OnPageIndexChanging="grvUsuario_PageIndexChanging" HeaderStyle-BackColor="#CCCCCC">
            <AlternatingRowStyle BorderStyle="Outset"></AlternatingRowStyle>
            <Columns>

                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate>
                        <asp:Label ID="lblNome" Text='<%# Eval("_Nome")  %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Telefone">
                    <ItemTemplate>
                        <asp:Label ID="lblTelefone" Text='<%# Eval("_telefone")  %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Sexo">
                    <ItemTemplate>
                        <asp:Label ID="lblSexo" Text='<%# Eval("_Sexo")  %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnAltera" class="btn btn-lg btn-primary" Text="Alterar" Style="height: 35px;" runat="server" OnClick="btnAltera_Click" CommandArgument='<%# Eval("_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnExclui" class="btn btn-lg btn-danger" Text="Excluir" Style="height: 35px;" runat="server" OnClick="btnExclui_Click" CommandArgument='<%# Eval("_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

            <HeaderStyle BorderColor="Black" BorderWidth="1pt" BorderStyle="Outset"></HeaderStyle>

            <RowStyle VerticalAlign="Middle" BorderStyle="Outset"></RowStyle>
        </asp:GridView>
    </div>
</asp:Content>
