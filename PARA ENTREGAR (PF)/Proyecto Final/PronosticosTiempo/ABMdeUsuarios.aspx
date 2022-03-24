<%@ Page Title="ABM de Usuarios" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ABMdeUsuarios.aspx.cs" Inherits="ABMdeUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .styleUsuario{
            height: 34px;
            width: 374px;
            font-size: 33px;
            color: #3e3d3d;
            text-shadow: 1px 1px #000000;
            text-align: center;
            text-decoration: underline;
        }
        .auto-style5 {
            width: 287px;
        }
        .auto-style6 {
            width: 661px;
        }
        .auto-style7 {
            text-align: right;
            width: 661px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td colspan="3" class="styleUsuario"></td>
        </tr>
        <tr>
            <td colspan="3" class="styleUsuario"><strong>Mantenimiento de Usuarios</strong></td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"><strong>Usuario de Logueo:</strong></td>
            <td class="auto-style5">
                <asp:TextBox ID="txtLogueoUsuario" runat="server" Width="201px" MaxLength="20"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"><strong>Contraseña:</strong></td>
            <td class="auto-style5">
                <asp:TextBox ID="txtContrasena" runat="server" Width="201px" Enabled="False" MaxLength="15" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-dark" OnClick="btnBuscar_Click" Enabled="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"><strong>Nombre:</strong></td>
            <td class="auto-style5">
                <asp:TextBox ID="txtNombre" runat="server" Width="201px" Enabled="False" MaxLength="50"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnLimpiar" runat="server" CssClass="btn btn-light" OnClick="btnLimpiar_Click" Text="Limpiar / Deshacer" />
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7"><strong>Apellido:</strong></td>
            <td class="auto-style5">
                <asp:TextBox ID="txtApellido" runat="server" Width="201px" Enabled="False" MaxLength="50"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style5">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" Enabled="False" OnClick="btnRegistrar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-secondary" Enabled="False" OnClick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" Enabled="False" OnClick="btnEliminar_Click" />
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
    </table>
</asp:Content>

