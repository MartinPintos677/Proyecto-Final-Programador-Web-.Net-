<%@ Page Title="ABM de Países" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMdePaises.aspx.cs" Inherits="ABMdePaises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .stylePaises{
            height: 34px;
            width: 374px;
            font-size: 33px;
            color: #3e3d3d;
            text-shadow: 1px 1px #000000;
        }
        .auto-style5 {
            width: 280px;
        }
        .auto-style6 {
            width: 661px;
        }
        .auto-style7 {
            text-align: right;
            width: 661px;
        }
        .auto-style9 {
            height: 34px;
            font-size: 33px;
            color: #3e3d3d;
            text-shadow: 1px 1px #000000;
            text-align: center;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9" colspan="3"><strong>Mantenimiento de Países</strong></td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"><strong>Código de País:</strong></td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCodigoPais" runat="server" MaxLength="3" Width="201px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-dark" Text="Buscar" OnClick="btnBuscar_Click" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7"><strong>Nombre de País:</strong></td>
            <td class="auto-style5">
                <asp:TextBox ID="txtNombrePais" runat="server" MaxLength="100" Width="201px" Enabled="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-light" Enabled="False" OnClick="btnLimpiar_Click" Text="Limpiar / Deshacer" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">
                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Text="Registrar" Enabled="False" OnClick="btnRegistrar_Click" />
                <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-secondary" Text="Modificar" Enabled="False" OnClick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" Enabled="False" OnClick="btnEliminar_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

