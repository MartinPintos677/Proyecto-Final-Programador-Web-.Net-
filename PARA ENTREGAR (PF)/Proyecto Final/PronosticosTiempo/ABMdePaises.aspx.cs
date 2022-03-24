using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class ABMdePaises : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LimpioRME();
    }

    private void LimpioRME()
    {
        txtCodigoPais.Text = string.Empty;
        txtNombrePais.Text = string.Empty;
        
        btnLimpiar.Enabled = false;
        btnBuscar.Enabled = true;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
        btnBuscar.Enabled = true;
        btnRegistrar.Enabled = false;
        txtCodigoPais.Enabled = true;
        txtNombrePais.Enabled = false;

        txtCodigoPais.Focus();
    }

    private void BEncontrado()
    {
        btnLimpiar.Enabled = true;
        btnRegistrar.Enabled = false;
        btnModificar.Enabled = true;
        btnBuscar.Enabled = false;
        btnEliminar.Enabled = true;
        txtCodigoPais.Enabled = true;
        txtNombrePais.Enabled = true;
        lblMensaje.Text = string.Empty;
        lblMensaje.CssClass = null;
    }

    private void BNoEncontrado()
    {
        btnLimpiar.Enabled = true;
        txtNombrePais.Text = string.Empty;
        btnBuscar.Enabled = false;
        btnRegistrar.Enabled = true;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
        txtCodigoPais.Enabled = true;
        txtNombrePais.Enabled = true;
        txtCodigoPais.Enabled = true;
        txtNombrePais.Enabled = true;
        lblMensaje.Text = string.Empty;
        lblMensaje.CssClass = null;
        txtNombrePais.Focus();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {                  
            NegPais negPais = new NegPais();

            if (txtCodigoPais.Text.Trim() == string.Empty)
            {
                lblMensaje.Text = "Debe ingresar el código de País.";
                lblMensaje.CssClass = "alert alert-warning d-flex align-items-center";
                txtCodigoPais.Focus();
            }
            else
            {
                Pais pais = negPais.Buscar(txtCodigoPais.Text.Trim());

                if (pais != null)
                {
                    Session["PaisABM"] = pais;                    
                    txtNombrePais.Text = pais.NombrePais;
                    
                    BEncontrado();
                }
                else
                {
                    Session["PaisABM"] = null;                    

                    BNoEncontrado();
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
            Pais pais = new Pais(txtCodigoPais.Text.Trim(), txtNombrePais.Text.Trim());

            NegPais negPais = new NegPais();

            negPais.Registrar(pais);

            lblMensaje.Text = "País registrado con éxito.";
            lblMensaje.CssClass = "alert alert-success d-flex align-items-center";

            LimpioRME();            
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
            Pais pais = (Pais)Session["PaisABM"];
            
            pais.NombrePais = txtNombrePais.Text.Trim();

            NegPais negPais = new NegPais();

            negPais.Modificar(pais);

            lblMensaje.Text = "Modificación exitosa.";
            lblMensaje.CssClass = "alert alert-success d-flex align-items-center";

            LimpioRME();            
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.CssClass = "alert alert-danger d-flex align-items-center";            
        }        
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Pais pais = (Pais)Session["PaisABM"];
            
            NegPais negPais = new NegPais();            

            negPais.Eliminar(pais);

            lblMensaje.Text = "País eliminado del sistema.";
            lblMensaje.CssClass = "alert alert-success d-flex align-items-center";

            LimpioRME();            
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.CssClass = "alert alert-danger d-flex align-items-center";
        }        
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioRME();
        lblMensaje.Text = string.Empty;
        lblMensaje.CssClass = null;
    }
}