<%@ Page Title="ABM de Ciudades" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMdeCiudad.aspx.cs" Inherits="ABMdeCiudad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .styleCiudad{
            height: 34px;
            width: 374px;
            font-size: 33px;
            color: #3e3d3d;
            text-shadow: 1px 1px #000000;
        }
        .auto-style5 {
            width: 287px;
        }
        .auto-style6 {
            height: 34px;
            width: 374px;
            font-size: 33px;
            color: #3e3d3d;
            text-shadow: 1px 1px #000000;
            text-align: center;
            text-decoration: underline;
        }
        .auto-style7 {
            width: 661px;
        }
        .auto-style8 {
            text-align: right;
            width: 661px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6" colspan="3"><strong>Mantenimiento de Ciudades</strong></td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"><strong>País (Código):</strong></td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlPaises" runat="server" CssClass="btn btn-secondary dropdown-toggle">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"><strong>Código de Ciudad:</strong></td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCodigoCiudad" runat="server" Width="201px" MaxLength="3"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-dark" Text="Buscar" OnClick="btnBuscar_Click" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"><strong>Nombre de Ciudad:</strong></td>
            <td class="auto-style5">
                <asp:TextBox ID="txtNombreCiudad" runat="server" Width="201px" Enabled="False" MaxLength="100"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-light" Enabled="False" OnClick="btnLimpiar_Click" Text="Limpiar / Deshacer" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">
                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Enabled="False" Text="Registrar" OnClick="btnRegistrar_Click" />
                <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-secondary" Enabled="False" Text="Modificar" OnClick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Enabled="False" Text="Eliminar" OnClick="btnEliminar_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

