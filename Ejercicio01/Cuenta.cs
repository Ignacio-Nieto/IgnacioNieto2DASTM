using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public abstract class Cuenta
    {
        public string Cod_Cli { get; set; } = string.Empty;
        public double Saldo { get; protected set; }

        public Cliente Titular { get; set; }
        public List<Operacion> operaciones { get; } = new List<Operacion>();

        public void depositar(double monto)
        {
            if (monto <= 0) throw new ArgumentException("monto invalido");
            Saldo += monto;
            RegistrarOperacion("Deposito", monto);

        }

        public abstract bool Extraer(double monto);
       
        protected void RegistrarOperacion (string tipo, double monto)
        {
            operaciones.Add(new Operacion
            {
                Tipo = tipo,
                monto = monto
            });
        }

    }
}
