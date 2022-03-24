using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class ListadoPronosticosFecha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void calCalendario_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            DateTime fecha = Convert.ToDateTime(calCalendario.SelectedDate.ToShortDateString());

            NegPronostico negPronostico = new NegPronostico();

            List<Pronostico> lista = negPronostico.PronosticosporFecha(fecha);            

            if (lista.Count == 0)
            {
                lblMensaje.Text = "Ningún pronóstico asociado a la fecha indicada.";
                lblMensaje.CssClass = "alert alert-warning d-flex align-items-center";
                grvPronosticos.DataSource = null;
                grvPronosticos.DataBind();
            }
            else
            {
                lblMensaje.Text = string.Empty;
                lblMensaje.CssClass = null;
                Session["PronosticoporFecha"] = lista;
                grvPronosticos.DataSource = Session["PronosticoporFecha"];
                grvPronosticos.DataBind();
            }                        
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }        
    }
}