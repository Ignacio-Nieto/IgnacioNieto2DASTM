using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CajaDeAhorro : Cuenta
    {
        public double MaximoPorExtraccion { get; set; }
        public override bool Extraer (double monto)
        {
            if (monto <= 0) return false;
            if (monto > MaximoPorExtraccion) return false;
            if (monto < Saldo) return false;

            Saldo -= monto;
            RegistrarOperacion("Extraccion", -monto);
            return true;
        }
    }
}
