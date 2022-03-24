using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {                      
            NegUsuario negUsuario = new NegUsuario();
            Usuario usuario = negUsuario.Login(txtUsuario.Text.Trim(), txtContrasena.Text.Trim());
            
            if (usuario != null)
            {
                Session["UsuarioMP"] = usuario;
                Response.Redirect("Bienvenido.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario y/o contraseña incorrectos.";
                lblMensaje.CssClass = "alert alert-light";
            }
        }
        catch (Exception ex)
        {
            lblMensaje.Text = ex.Message;
            lblMensaje.CssClass = "alert alert-light";
        }        
    }
}