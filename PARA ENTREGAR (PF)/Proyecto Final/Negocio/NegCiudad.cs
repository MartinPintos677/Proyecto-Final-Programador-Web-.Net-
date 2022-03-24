using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Persistencia;

namespace Negocio
{
    public class NegCiudad
    {
        private PerCiudad perCiudad = new PerCiudad();

        public Ciudad Buscar(string codigoPais, string codigoCiudad)
        {
            Ciudad ciudad = perCiudad.Buscar(codigoPais, codigoCiudad);

            return ciudad;
        }

        public List<Ciudad> TodasCiudades()
        {
            return perCiudad.TodasCiudades();
        }

        public void Registrar(Ciudad ciudad)
        {
            perCiudad.Registrar(ciudad);            
        }

        public void Eliminar(Ciudad ciudad)
        {
            perCiudad.Eliminar(ciudad);            
        }

        public void Modificar(Ciudad ciudad)
        {
            perCiudad.Modificar(ciudad);
        }

        public List<Ciudad> CiudadesdePais(Pais codigoPais)
        {
            return perCiudad.CiudadesdePais(codigoPais);
        }
    }
}
