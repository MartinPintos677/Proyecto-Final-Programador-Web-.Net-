using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Persistencia;

namespace Negocio
{
    public class NegUsuario
    {
        private PerUsuario perUsuario = new PerUsuario();

        public Usuario Login(string logueo, string password)
        {
            Usuario usuario = perUsuario.Login(logueo, password);                   

            return usuario;
        }    
        
        public Usuario Buscar(string logueo)
        {
            Usuario usuario = perUsuario.Buscar(logueo);
            
            return usuario;
        }

        public void Registrar(Usuario usuario)
        {
            perUsuario.Registrar(usuario);
        }

        public void Eliminar(Usuario usuario)
        {
            perUsuario.Eliminar(usuario);          
        }

        public void Modificar(Usuario usuario)
        {
            perUsuario.Modificar(usuario);            
        }
        
        public bool BuscarbtnEliminar(Usuario usuario)
        {
            return perUsuario.BuscarbtnEliminar(usuario);            
        }
    }
}
