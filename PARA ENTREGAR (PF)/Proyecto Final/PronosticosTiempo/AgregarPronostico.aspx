<%@ Page Title="Agregar Pronósticos" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AgregarPronostico.aspx.cs" Inherits="AgregarPronostico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .stylePron{
            height: 34px;
            width: 374px;
            font-size: 33px;
            color: #3e3d3d;
            text-shadow: 1px 1px #000000;
            text-align: center;
            text-decoration: underline;
        }
        .auto-style5 {
            width: 512px;
        }
        .auto-style7 {
            --bs-table-bg: #f8f9fa;
            --bs-table-striped-bg: #ecedee;
            --bs-table-striped-color: #000;
            --bs-table-active-bg: #dfe0e1;
            --bs-table-active-color: #000;
            --bs-table-hover-bg: #e5e6e7;
            --bs-table-hover-color: #000;
            color: #000;
            border-color: #dfe0e1;
            margin-left: 0px;
        }
        .auto-style8 {
            width: 206px;
        }
        .auto-style10 {
            text-align: right;
            height: 30px;
        }
        .auto-style12 {
            text-align: left;
            height: 30px;
        }
        .auto-style13 {
            height: 30px;
        }
        .auto-style14 {
            text-align: right;
            height: 196px;
        }
        .auto-style15 {
            text-align: center;
            height: 196px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
    <tr>
        <td class="stylePron" colspan="4"><strong>Registrar Pronóstico</strong></td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style10" colspan="2"><strong>Temperatura máxima:</strong></td>
        <td class="auto-style12">
            <asp:TextBox ID="txtTempMaxima" runat="server" MaxLength="3"></asp:TextBox>
        </td>
        <td class="auto-style13"></td>
    </tr>
    <tr>
        <td class="auto-style10" colspan="2"><strong>Temperatura mínima:</strong></td>
        <td class="auto-style12">
            <asp:TextBox ID="txtTempMinima" runat="server" MaxLength="3"></asp:TextBox>
        </td>
        <td class="auto-style13"></td>
    </tr>
    <tr>
        <td class="text-end" colspan="2"><strong>Probabilidad de lluvia:</strong></td>
        <td class="text-start">
            <asp:TextBox ID="txtProbLluvia" runat="server" MaxLength="3"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-end" colspan="2"><strong>Probabilidad de tormenta:</strong></td>
        <td class="text-start">
            <asp:TextBox ID="txtProbTormenta" runat="server" MaxLength="3"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-end" colspan="2"><strong>Fecha y hora:</strong></td>
        <td class="text-start">
            <asp:TextBox ID="txtFechaHora" runat="server" MaxLength="20"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-end" colspan="2"><strong>Velocidad del viento:</strong></td>
        <td class="text-start">
            <asp:TextBox ID="txtVelViento" runat="server" MaxLength="3"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-end" colspan="2"><strong>Tipo de cielo:</strong></td>
        <td class="text-start">
            <asp:DropDownList ID="ddlCielo" runat="server" CssClass="btn btn-dark dropdown-toggle">
                <asp:ListItem>Despejado</asp:ListItem>
                <asp:ListItem>Parcialmente Nuboso</asp:ListItem>
                <asp:ListItem>Nuboso</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style5">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td class="text-center">
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style14" colspan="2"><strong>Seleccione la ciudad:</strong></td>
        <td class="auto-style15" colspan="2">
            <asp:GridView ID="grvCiudades" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" CssClass="auto-style7" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="grvCiudades_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="NombreCiudad" HeaderText="Ciudad" />
                    <asp:BoundField DataField="CodigoCiudad" HeaderText="Código de Ciudad" />
                    <asp:BoundField DataField="Pais.NombrePais" HeaderText="País" />
                    <asp:BoundField DataField="Pais.CodigoPais" HeaderText="Código de País" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
        <td class="text-center">
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
        <td class="text-start">
            <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-success" OnClick="btnRegistrar_Click" Text="Finalizar Registro" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
        <td class="text-center">
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

