using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pais
    {
        private string _codigoPais;
        private string _nombrePais;

        public string CodigoPais
        {
            get { return _codigoPais; }
            set
            {
                if (value.Length != 3)
                {
                    throw new Exception("El código debe tener 3 letras.");
                }
                _codigoPais = value.ToUpper();
            }
        }
        public string NombrePais
        {
            get { return _nombrePais; }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Debe indicar el nombre del país.");
                }
                else if (value.Length > 100)
                {
                    throw new Exception("Nombre de país no debe tener más de 100 caracteres.");
                }
                _nombrePais = value;
            }
        }
        public Pais(string codigoPais, string nombrePais)
        {
            CodigoPais = codigoPais;
            NombrePais = nombrePais;
        }
        public string DatoPais
        {
            get { return ToString(); }
        }
        public override string ToString()
        {
            return NombrePais + " (" + CodigoPais + ")";
        }
    }
}
