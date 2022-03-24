using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Persistencia;

namespace Negocio
{
    public class NegPronostico
    {
        private PerPronostico perPronostico = new PerPronostico();

        public void Registrar(Pronostico pronostico)
        {
            if (pronostico.FechaHora < DateTime.Now)
            {
                throw new Exception("No se puede publicar un pronóstico para una fecha anterior a la actual.");
            }
            else
            {
                perPronostico.Registrar(pronostico);
            }
        }

        public List<Pronostico> PronosticosporCiudad(Ciudad ciudad)
        {
            return perPronostico.PronosticosporCiudad(ciudad);
        }

        public List<Pronostico> PronosticosporFecha(DateTime fecha)
        {
            return perPronostico.PronosticosporFecha(fecha);
        }
    }
}
