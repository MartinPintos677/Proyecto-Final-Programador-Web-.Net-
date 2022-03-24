using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!(Session["UsuarioMP"] is Usuario))
            {
                Response.Redirect("Logueo.aspx");
            }
            else
            {
                lblUsuario.Text = Session["UsuarioMP"].ToString();
            }
        }
        catch
        {
            Response.Redirect("Logueo.aspx");
        }
    }
    protected void btnSalir_Click(object sender, EventArgs e)
    {                
        Response.Redirect("Default.aspx");
    }
}
