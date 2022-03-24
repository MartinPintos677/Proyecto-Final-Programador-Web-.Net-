<%@ Page Title="Listado de Ponósticos por Ciudad" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoPronosticosporCiudad.aspx.cs" Inherits="ListadoPronosticosporCiudad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .stylePron{
            height: 34px;
            width: 374px;
            font-size: 33px;
            color: #3e3d3d;
            text-shadow: 1px 1px #000000;
        }
        .auto-style5 {
        width: 544px;
    }
        .auto-style6 {
            width: 479px;
        }
        .auto-style7 {
            text-align: center;
            width: 479px;
        }
    .auto-style8 {
        height: 34px;
        width: 374px;
        font-size: 33px;
        color: #3e3d3d;
        text-shadow: 1px 1px #000000;
        text-decoration: underline;
        text-align: center;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style8" colspan="3"><strong>Listado de Pronósticos por Ciudad</strong></td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlPaises" runat="server" CssClass="btn btn-dark dropdown-toggle">
                </asp:DropDownList>
                <asp:Button ID="btnSeleccionar" runat="server" CssClass="btn btn-dark" Text="Seleccionar País" OnClick="btnSeleccionar_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style7">
                <asp:GridView ID="grvCiudadesdePaises" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grvCiudadesdePaises_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="NombreCiudad" HeaderText="Ciudad" />
                        <asp:BoundField DataField="CodigoCiudad" HeaderText="Código" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">
                <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="text-center" colspan="3">
                <asp:GridView ID="grvPronosticos" runat="server" CssClass="table table-hover" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grvPronosticos_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                        <asp:BoundField DataField="Codigo" HeaderText="ID" />
                        <asp:BoundField DataField="TemperaturaMinima" HeaderText="Temp. Mínima" />
                        <asp:BoundField DataField="TemperaturaMaxima" HeaderText="Temp. Máxima" />
                        <asp:BoundField DataField="TipoCielo" HeaderText="Cielo" />
                        <asp:BoundField DataField="ProbabilidadLluvia" HeaderText="Prob. Lluvia" />
                        <asp:BoundField DataField="ProbabilidadTormenta" HeaderText="Prob. Tormenta" />
                        <asp:BoundField DataField="VelocidadViento" HeaderText="Velocidad Viento" />
                        <asp:BoundField DataField="FechaHora" HeaderText="Fecha" />
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

