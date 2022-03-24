using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class ABMdeUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LimpioRME();
    }

    private void LimpioRME()
    {
        btnBuscar.Enabled = true;
        btnLimpiar.Enabled = false;
        btnRegistrar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;

        txtContrasena.Enabled = false;
        txtNombre.Enabled = false;
        txtApellido.Enabled = false;
        txtLogueoUsuario.Enabled = true;
        
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtContrasena.Text = string.Empty;
        txtLogueoUsuario.Text = string.Empty;
        txtLogueoUsuario.Focus();
    }

    private void BEncontrado()
    {
        btnBuscar.Enabled = false;
        btnLimpiar.Enabled = true;
        btnRegistrar.Enabled = false;
        btnModificar.Enabled = true;
        txtNombre.Enabled = true;
        txtApellido.Enabled = true;
        txtContrasena.Enabled = true;
        txtLogueoUsuario.Enabled = true;
        lblMensaje.Text = string.Empty;
        lblMensaje.CssClass = null;
    }

    private void BNoEncontrado()
    {
        btnBuscar.Enabled = false;
        btnLimpiar.Enabled = true;
        btnRegistrar.Enabled = true;
        btnEliminar.Enabled = false;
        btnModificar.Enabled = false;
        txtNombre.Enabled = true; 
        txtApellido.Enabled = true;
        txtContrasena.Enabled = true;
        txtLogueoUsuario.Enabled = true;
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtContrasena.Text = string.Empty;
        lblMensaje.Text = string.Empty;
        lblMensaje.CssClass = null;
        txtContrasena.Focus();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {                  
            NegUsuario negUsuario = new NegUsuario();

            if (txtLogueoUsuario.Text.Trim() == string.Empty)
            {
                lblMensaje.Text = "Debe ingresar usuario de logueo.";
                lblMensaje.CssClass = "alert alert-warning d-flex align-items-center";
                txtLogueoUsuario.Focus();
            }
            else
            {
                Usuario usuario = negUsuario.Buscar(txtLogueoUsuario.Text.Trim());

                if (usuario != null)
                {
                    Session["UsuarioABM"] = usuario;
                                        
                    txtContrasena.Text = usuario.Contrasena;
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;

                    BEncontrado();

                    if (negUsuario.BuscarbtnEliminar(usuario))
                    {
                        btnEliminar.Enabled = false;
                    }
                    else
                    {
                        btnEliminar.Enabled = true;
                    }                    
                }
                else
                {
                    Session["UsuarioABM"] = null;
                    
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
            Usuario usuario = new Usuario(txtLogueoUsuario.Text.Trim(), txtContrasena.Text.Trim(),
                txtNombre.Text.Trim(), txtApellido.Text.Trim());

            NegUsuario negUsuario = new NegUsuario();
            negUsuario.Registrar(usuario);

            lblMensaje.Text = "Usuario Registrado.";
            lblMensaje.CssClass = "alert alert-success d-flex align-items-center";

            LimpioRME();
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
            Usuario usuario = (Usuario)Session["UsuarioABM"];
            
            NegUsuario negUsuario = new NegUsuario();
            
            negUsuario.Eliminar(usuario);

            lblMensaje.Text = "Usuario eliminado.";
            lblMensaje.CssClass = "alert alert-success d-flex align-items-center";

            LimpioRME();            
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.CssClass = "alert alert-danger d-flex align-items-center";
        }        
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario usuario = (Usuario)Session["UsuarioABM"];
            
            usuario.Nombre = txtNombre.Text.Trim();
            usuario.Apellido = txtApellido.Text.Trim();
            usuario.Contrasena = txtContrasena.Text.Trim();

            NegUsuario negUsuario = new NegUsuario();
            negUsuario.Modificar(usuario);

            lblMensaje.Text = "Modificación correcta.";
            lblMensaje.CssClass = "alert alert-success d-flex align-items-center";

            LimpioRME();            
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.CssClass = "alert alert-warning d-flex align-items-center";
        }       
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioRME();
        lblMensaje.Text = string.Empty;
        lblMensaje.CssClass = null;
    }
}