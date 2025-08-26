using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class CuentaCorriente: Cuenta
    {
        public double LimiteDescubierto { get; set; }
        public override bool Extraer (double monto)
        {
            if (monto <= 0) return false;
            if (Saldo - monto < -LimiteDescubierto) return false;
            Saldo -= monto;
            RegistrarOperacion("Extraccion ", monto);
            return true;
        }
    }
} 
