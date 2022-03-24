using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class ABMdeCiudad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            NegPais negPais = new NegPais();
            Session["ListaPaises"] = negPais.Todos();
            ddlPaises.DataSource = Session["ListaPaises"];
            ddlPaises.DataValueField = "CodigoPais";
            ddlPaises.DataTextField = "DatoPais";            
            ddlPaises.DataBind();

            LimpiarRME();
        }
    }

    private void LimpiarRME()
    {
        btnBuscar.Enabled = true;
        btnLimpiar.Enabled = false;
        btnRegistrar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        txtCodigoCiudad.Enabled = true;
        txtNombreCiudad.Enabled = false;
        txtCodigoCiudad.Text = string.Empty;
        txtNombreCiudad.Text = string.Empty;        
        txtCodigoCiudad.Focus();        
    }

    private void BuscarEncontrado()
    {
        btnBuscar.Enabled = false;
        btnLimpiar.Enabled = true;
        btnRegistrar.Enabled = false;
        btnModificar.Enabled = true;
        btnEliminar.Enabled = true;
        txtCodigoCiudad.Enabled = true;
        txtNombreCiudad.Enabled = true;
        lblMensaje.Text = string.Empty;
        lblMensaje.CssClass = null;
    }

    private void BuscarNoEncontrado()
    {
        btnBuscar.Enabled = false;
        txtNombreCiudad.Text = string.Empty;
        btnLimpiar.Enabled = true;
        btnRegistrar.Enabled = true;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
        txtCodigoCiudad.Enabled = true;
        txtNombreCiudad.Enabled = true;
        lblMensaje.Text = string.Empty;
        lblMensaje.CssClass = null;
        txtNombreCiudad.Focus();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {                  
            NegCiudad negCiudad = new NegCiudad();

            if (txtCodigoCiudad.Text.Trim() == string.Empty)
            {
                lblMensaje.Text = "Debe ingresar el código de Ciudad.";
                lblMensaje.CssClass = "alert alert-warning d-flex align-items-center";
                txtCodigoCiudad.Focus();
            }
            else
            {
                Ciudad ciudad = negCiudad.Buscar(ddlPaises.SelectedValue, txtCodigoCiudad.Text.Trim());

                if (ciudad != null)
                {
                    Session["CiudadABM"] = ciudad;                    
                    txtNombreCiudad.Text = ciudad.NombreCiudad;

                    BuscarEncontrado();                    
                }
                else
                {
                    Session["CiudadABM"] = null;
                    
                    BuscarNoEncontrado();                    
                }                
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.CssClass = "alert alert-danger d-flex align-items-center";            
        }        
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        try
        {            
            Pais pais = ((List<Pais>)Session["ListaPaises"])[ddlPaises.SelectedIndex];

            NegCiudad negCiudad = new NegCiudad();           
            Ciudad ciudad = new Ciudad(txtCodigoCiudad.Text.Trim(), txtNombreCiudad.Text.Trim(), pais);
            
            negCiudad.Registrar(ciudad);

            lblMensaje.Text = "Ciudad registrada.";
            lblMensaje.CssClass = "alert alert-success d-flex align-items-center";

            LimpiarRME();            
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.CssClass = "alert alert-warning d-flex align-items-center";
        }        
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudad ciudad = (Ciudad)Session["CiudadABM"];
            
            ciudad.NombreCiudad = txtNombreCiudad.Text.Trim();  
            
            NegCiudad negCiudad = new NegCiudad();

            negCiudad.Modificar(ciudad);

            lblMensaje.Text = "Modificación exitosa.";
            lblMensaje.CssClass = "alert alert-success d-flex align-items-center";

            LimpiarRME();            
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.CssClass = "alert alert-warning d-flex align-items-center";            
        }        
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudad ciudad = (Ciudad)Session["CiudadABM"];
            
            NegCiudad negCiudad = new NegCiudad();
            
            negCiudad.Eliminar(ciudad);

            lblMensaje.Text = "Ciudad eliminada.";
            lblMensaje.CssClass = "alert alert-success d-flex align-items-center";

            LimpiarRME();            
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.CssClass = "alert alert-danger d-flex align-items-center";
        }        
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarRME();
        lblMensaje.Text = string.Empty;
        lblMensaje.CssClass = null;
    }
}