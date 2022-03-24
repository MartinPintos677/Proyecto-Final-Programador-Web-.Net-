using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UsuarioMP"] = null;

        try
        {
            if (!IsPostBack)
            {
                NegPronostico negPronostico = new NegPronostico();
                List<Pronostico> lista = negPronostico.PronosticosporFecha(DateTime.Today);
                Session["PronosticosdelDia"] = lista;
                grvPronosticoDelDia.DataSource = Session["PronosticosdelDia"];
                grvPronosticoDelDia.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;                
        }
    }
}