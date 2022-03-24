using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciudad
    {
        private string _codigoCiudad;
        private string _nombreCiudad;
        private Pais _pais;

        public string CodigoCiudad
        {
            get { return _codigoCiudad; }
            set
            {
                if (value.Length != 3)
                {
                    throw new Exception("El código de ciudad debe tener 3 letras.");
                }
                _codigoCiudad = value.ToUpper();
            }
        }
        public string NombreCiudad
        {
            get { return _nombreCiudad; }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Debe indicar el nombre de la ciudad.");
                }
                else if (value.Length > 100)
                {
                    throw new Exception("La ciudad no debe tener más de 100 caracteres.");
                }
                _nombreCiudad = value;
            }
        }
        public Pais Pais
        {
            get { return _pais; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Debe indicar un país.");
                }
                _pais = value;
            }
        }
        public Ciudad(string codigoCiudad, string nombreCiudad, Pais pais)
        {
            CodigoCiudad = codigoCiudad;
            NombreCiudad = nombreCiudad;
            Pais = pais;
        }
        public override string ToString()
        {
            return NombreCiudad + " (" + Pais.CodigoPais + ")";
        }
    }
}
