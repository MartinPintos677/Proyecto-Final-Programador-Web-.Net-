<%@ Page Title="Listado de Pronósticos por Fecha" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListadoPronosticosFecha.aspx.cs" Inherits="ListadoPronosticosFecha" %>

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
            height: 34px;
            width: 374px;
            font-size: 33px;
            color: #3e3d3d;
            text-shadow: 1px 1px #000000;
            text-decoration: underline;
            text-align: center;
        }
        .auto-style6 {
            width: 567px;
        }
        .auto-style7 {
            text-align: right;
            width: 567px;
        }
        .auto-style8 {
            width: 422px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
    <tr>
        <td class="auto-style5" colspan="3"><strong>Listado de Pronósticos para el Día</strong></td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style7"><strong>Seleccione una fecha en el calendario:</strong></td>
        <td class="auto-style8">
            <asp:Calendar ID="calCalendario" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" OnSelectionChanged="calCalendario_SelectionChanged" TitleFormat="Month" Width="400px">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                <DayStyle Width="14%" />
                <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                <TodayDayStyle BackColor="#CCCC99" />
            </asp:Calendar>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style8">
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="text-center" colspan="3">
            <asp:GridView ID="grvPronosticos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover">
                <Columns>
                    <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                    <asp:BoundField DataField="TemperaturaMinima" HeaderText="Temp. Mínima" />
                    <asp:BoundField DataField="TemperaturaMaxima" HeaderText="Temp. Máxima" />
                    <asp:BoundField DataField="TipoCielo" HeaderText="Cielo" />
                    <asp:BoundField DataField="ProbabilidadLluvia" HeaderText="Prob. Lluvia" />
                    <asp:BoundField DataField="ProbabilidadTormenta" HeaderText="Prob. Tormenta" />
                    <asp:BoundField DataField="FechaHora" HeaderText="Fecha" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style6">&nbsp;</td>
        <td class="auto-style8">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

