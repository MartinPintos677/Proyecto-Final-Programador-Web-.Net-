<%@ Page Title="Bienvenido a AccuWeather" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bienvenido.aspx.cs" Inherits="Bienvenidoo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style4 {
            text-align: center;
            font-size: 50px;
            color: black;
            
        }
        .auto-style5 {
            width: 500px;
            height: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="3"><strong>¡Bienvenidos! </strong></td>
        </tr>
        <tr>
            <td class="text-center" colspan="3">
                <img alt="LogoBienvenida" class="auto-style5" longdesc="LogoBienvenida" src="img/otro%20logo.jpg" /></td>
        </tr>
    </table>
</asp:Content>

