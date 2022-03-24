using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Persistencia;

namespace Negocio
{
    public class NegPais
    {
        private PerPais perPais = new PerPais();
        public Pais Buscar(string codigo)
        {
            Pais pais = perPais.Buscar(codigo);

            return pais;
        }

        public void Registrar(Pais pais)
        {
            perPais.Registrar(pais);
        }

        public void Eliminar(Pais pais)
        {
            perPais.Eliminar(pais);
        }

        public void Modificar(Pais pais)
        {
            perPais.Modificar(pais);
        }

        public List<Pais> Todos()
        {
            return perPais.Todos();
        }
    }
}
