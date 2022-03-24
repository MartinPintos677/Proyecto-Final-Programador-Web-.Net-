using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class AgregarPronostico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                NegCiudad negCiudades = new NegCiudad();
                Session["TodasCiudades"] = negCiudades.TodasCiudades();
                grvCiudades.DataSource = Session["TodasCiudades"];
                grvCiudades.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
        }
    }

    private void Limpiar()
    {
        txtFechaHora.Text = string.Empty;
        txtProbLluvia.Text = string.Empty;
        txtProbTormenta.Text = string.Empty;
        txtTempMaxima.Text = string.Empty;
        txtTempMinima.Text = string.Empty;
        txtVelViento.Text = string.Empty;
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            int codigo = 1;
            int PLluvia = Convert.ToInt32(txtProbLluvia.Text);
            int PTormenta = Convert.ToInt32(txtProbTormenta.Text);
            int TMaxima = Convert.ToInt32(txtTempMaxima.Text);
            int TMinima = Convert.ToInt32(txtTempMinima.Text);
            int VelViento = Convert.ToInt32(txtVelViento.Text);
            string Cielo = ddlCielo.SelectedValue;
            DateTime FechaHora = Convert.ToDateTime(txtFechaHora.Text);

            Usuario usuario = (Usuario)Session["UsuarioMP"];

            Ciudad ciudad = (Ciudad)Session["Ciudad"];

            Pronostico pronostico = new Pronostico(codigo, TMaxima, TMinima, VelViento, Cielo, PLluvia,
                PTormenta, FechaHora, usuario, ciudad);

            NegPronostico negPronostico = new NegPronostico();
            negPronostico.Registrar(pronostico);

            lblMensaje.Text = "Pronóstico registrado exitosamente.";
            lblMensaje.CssClass = "alert alert-success d-flex align-items-center";
            Limpiar();
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.CssClass = "alert alert-warning d-flex align-items-center";
        }
    }

    protected void grvCiudades_SelectedIndexChanged(object sender, EventArgs e)
    {
        Ciudad ciudad = ((List<Ciudad>)Session["TodasCiudades"])[grvCiudades.SelectedIndex];

        Session["Ciudad"] = ciudad;
    }
}
