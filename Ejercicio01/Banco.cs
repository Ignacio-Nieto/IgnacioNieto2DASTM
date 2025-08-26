using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio01
{
    public class Banco
    {
        public List<Cliente> clientes { get; set; } = new List<Cliente>();
        public List<Cuenta> cuentas { get; set; } = new List<Cuenta>();

        public bool AgregarCliente(Cliente cliente)
        {
            if (cliente.ValidarDatos(clientes))
            {
                clientes.Add(cliente);
                return true;
            }
            return false;
        }

        public bool EliminarCliente(string dni)
        {
            var cliente = clientes.FirstOrDefault(c => c.dni == dni);
            if (cliente == null) return false;

            if (cuentas.Any(c => c.Titular.dni == dni))
                return false; 

            clientes.Remove(cliente);
            return true;
        }

        
        public bool AgregarCuenta(Cuenta cuenta)
        {
            if (cuentas.Any(c => c.Cod_Cli == cuenta.Cod_Cli))
                return false; 

            cuentas.Add(cuenta);
            return true;
        }


        public bool EliminarCuenta(string codigo)
        {
            var cuenta = cuentas.FirstOrDefault(c => c.Cod_Cli== codigo);
            if (cuenta == null) return false;
            if (cuenta.Saldo != 0) return false;

            cuentas.Remove(cuenta);
            return true;
        }


        public Cliente? BuscarClientePorDni(string dni)
        {
            return clientes.FirstOrDefault(c => c.dni == dni);
        }


        public List<Cliente> BuscarClientePorNombre(string nombre)
        {
            return clientes.Where(c => c.Nom_Ape.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
