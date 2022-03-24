using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class ListadoPronosticosporCiudad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NegPais negPais = new NegPais();
            Session["ListadoPaises"] = negPais.Todos();
            ddlPaises.DataSource = Session["ListadoPaises"];
            ddlPaises.DataValueField = "CodigoPais";            
            ddlPaises.DataTextField = "DatoPais";            
            ddlPaises.DataBind();
        }
    }

    protected void btnSeleccionar_Click(object sender, EventArgs e)
    {
        try
        {
            Pais pais = ((List<Pais>)Session["ListadoPaises"])[ddlPaises.SelectedIndex];

            NegCiudad negCiudad = new NegCiudad();

            List<Ciudad> ciudades = negCiudad.CiudadesdePais(pais);

            if (ciudades.Count == 0)
            {
                lblMensaje.Text = "El país seleccionado no tiene ciudades agregadas.";
                lblMensaje.CssClass = "alert alert-warning d-flex align-items-center";
                grvCiudadesdePaises.DataSource = null;
                grvCiudadesdePaises.DataBind();
            }
            else
            {
                Session["CiudadesdePais"] = ciudades;
                grvCiudadesdePaises.DataSource = Session["CiudadesdePais"];
                grvCiudadesdePaises.DataBind();
                lblMensaje.Text = string.Empty;
                lblMensaje.CssClass = null;
            }
            grvPronosticos.DataSource = null;
            grvPronosticos.DataBind();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }        
    }
    

    protected void grvCiudadesdePaises_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Ciudad ciudad = ((List<Ciudad>)Session["CiudadesdePais"])[grvCiudadesdePaises.SelectedIndex];
            
            NegPronostico negPronosticos = new NegPronostico();

            List<Pronostico> lista = negPronosticos.PronosticosporCiudad(ciudad);

            if (lista.Count == 0)
            {
                lblMensaje.Text = "La ciudad no tiene pronósticos asociados.";
                lblMensaje.CssClass = "alert alert-warning d-flex align-items-center";
                grvPronosticos.DataSource = null;
                grvPronosticos.DataBind();
            }
            else
            {
                lblMensaje.Text = string.Empty;
                lblMensaje.CssClass = null;
                Session["PronosticoporCiudad"] = lista;
                grvPronosticos.DataSource = Session["PronosticoporCiudad"];
                grvPronosticos.DataBind();
            }            
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;            
        }        
    }
    protected void grvPronosticos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvPronosticos.PageIndex = e.NewPageIndex;
            grvPronosticos.DataSource = Session["PronosticoporCiudad"];
            grvPronosticos.DataBind();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }
}