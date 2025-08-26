using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Cliente
    {
        public string dni { get; set; } = string.Empty;
        public string Nom_Ape { get; set; } = string.Empty;
        public string Nro_tel { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;

        public DateTime Fecha_nac { get; set; }

        public int CalcularEdad()
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - Fecha_nac.Year;
            if (Fecha_nac.Date> hoy.AddYears(-edad)) edad--;
            return edad;
        }

        public bool ValidarDatos (List<Cliente> ClientesExistentes)
        {
            if (string.IsNullOrEmpty(dni) || ClientesExistentes.Any(c => c.dni == this.dni)) ;
            if (string.IsNullOrEmpty(Nom_Ape)) return false;
            if (string.IsNullOrEmpty(Nro_tel)) return false;
            if (string.IsNullOrEmpty(Mail)) return false;

            return true;
        }
    }

}
