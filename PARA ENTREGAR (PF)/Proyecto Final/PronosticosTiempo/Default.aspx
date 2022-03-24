<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet"/> 
    <script src="Scripts/bootstrap.min.js"></script>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Default</title>
    <style type="text/css">
        body{
            background-color: black;
            font-family: sans-serif;
        }
        .auto-style3 {
            width: 196px;
        }
        .auto-style4 {
            text-align: left;
        }
        .auto-style6 {
            text-align: right;
            height: 25px;
        }
        .auto-style7 {
            height: 25px;
        }
        .auto-style8 {
            width: 600px;
            height: 137px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img alt="Logo" class="auto-style8" longdesc="LogoInicio" src="img/accuweather-logo-white.png" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">
                    <asp:GridView ID="grvPronosticoDelDia" runat="server" AutoGenerateColumns="False" CssClass="table table-dark table-hover">
                        <Columns>
                            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                            <asp:BoundField DataField="TemperaturaMinima" HeaderText="Temp. Mínima" />
                            <asp:BoundField DataField="TemperaturaMaxima" HeaderText="Temp. Máxima" />
                            <asp:BoundField DataField="TipoCielo" HeaderText="Cielo" />
                            <asp:BoundField DataField="ProbabilidadLluvia" HeaderText="Prob. Lluvia" />
                            <asp:BoundField DataField="ProbabilidadTormenta" HeaderText="Prob. Tormenta" />
                            <asp:BoundField DataField="VelocidadViento" HeaderText="Viento" />
                            <asp:BoundField DataField="FechaHora" HeaderText="Fecha" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6" colspan="2">
                    <asp:LinkButton ID="btnLogueo" runat="server" CssClass="btn btn-light" PostBackUrl="~/Logueo.aspx">Iniciar Sesión</asp:LinkButton>
                </td>
                <td class="auto-style7"></td>
            </tr>
        </table>
    </form>
</body>
</html>
