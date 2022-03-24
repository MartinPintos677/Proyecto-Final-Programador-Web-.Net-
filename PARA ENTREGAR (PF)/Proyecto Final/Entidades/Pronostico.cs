using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pronostico
    {
        private int _codigo;
        private int _temperaturaMinima;
        private int _temperaturaMaxima;
        private string _tipoCielo;
        private int _velocidadViento;
        private int _probabilidadLluvia;
        private int _probabilidadTormenta;
        private DateTime _fechaHora;

        private Usuario _usuario;
        private Ciudad _ciudad;

        public int Codigo
        {
            get { return _codigo; }
            set
            {
                if (value < 1)
                {
                    throw new Exception("Código incorrecto.");
                }
                _codigo = value;
            }
        }
        public int TemperaturaMinima
        {
            get { return _temperaturaMinima; }
            set
            {
                if (value < -70 || value > 70)
                {
                    throw new Exception("Debe ingresar una temperatura válida.");
                }                
                _temperaturaMinima = value;
            }
        }
        public int TemperaturaMaxima
        {
            get { return _temperaturaMaxima; }
            set
            {
                if (value < -70 || value > 70)
                {
                    throw new Exception("Debe ingresar una temperatura válida.");
                }
                _temperaturaMaxima = value;
            }
        }
        public string TipoCielo
        {
            get { return _tipoCielo; }
            set
            {
                if (value != "Despejado" && value != "Parcialmente Nuboso" && value != "Nuboso")
                {
                    throw new Exception("Debe indicar si el cielo está despejado, parcialmente nuboso o nuboso.");
                }
                _tipoCielo = value;
            }
        }
        public int VelocidadViento
        {
            get { return _velocidadViento; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("La velocidad del viento no puede ser menor a 0.");
                }
                _velocidadViento = value;
            }
        }
        public int ProbabilidadLluvia
        {
            get { return _probabilidadLluvia; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Debe ingresar un valor que sea de 0 a 100.");
                }
                _probabilidadLluvia = value;
            }
        }
        public int ProbabilidadTormenta
        {
            get { return _probabilidadTormenta; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Debe ingresar un valor que sea de 0 a 100.");
                }
                _probabilidadTormenta = value;
            }
        }
        public DateTime FechaHora
        {
            get { return _fechaHora; }
            set
            {
                _fechaHora = value;
            }
        }
        public Usuario Usuario
        {
            get { return _usuario; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Debe indicar un Usuario.");
                }
                _usuario = value;
            }
        }
        public Ciudad Ciudad
        {
            get { return _ciudad; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Debe indicar una Ciudad.");
                }
                _ciudad = value;
            }
        }
        
        public Pronostico(int codigo, int temperaturaMaxima, int temperaturaMinima, int velocidadViento,
            string tipoCielo, int probabilidadLluvia, int probabilidadTormenta, DateTime fechaHora,
            Usuario usuario, Ciudad ciudad)
        {
            Codigo = codigo;
            TemperaturaMaxima = temperaturaMaxima;
            TemperaturaMinima = temperaturaMinima;
            VelocidadViento = velocidadViento;
            TipoCielo = tipoCielo;
            ProbabilidadLluvia = probabilidadLluvia;
            ProbabilidadTormenta = probabilidadTormenta;
            FechaHora = fechaHora;
            Usuario = usuario;
            Ciudad = ciudad;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
