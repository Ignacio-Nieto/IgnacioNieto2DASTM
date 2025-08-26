using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejercicio2
{
    public class Cliente
    {
        public string CodigoCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Paquete? PaqueteContratado { get; set; }

        public Cliente(string codigo, string nombre, string apellido, string dni, DateTime fechaNac)
        {
            CodigoCliente = codigo;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            FechaNacimiento = fechaNac;
        }
    }

    // ---- PAQUETES ----
    public abstract class Paquete
    {
        public string Nombre { get; set; }
        public double PrecioBase { get; set; }
        public List<Serie> Series { get; set; } = new List<Serie>();

        public Paquete(string nombre, double precioBase)
        {
            Nombre = nombre;
            PrecioBase = precioBase;
        }

        public abstract double CalcularPrecio();

        public virtual string MostrarInfo()
        {
            string info = $"Paquete: {Nombre} - Precio final: {CalcularPrecio():C}\n";
            foreach (var serie in Series)
            {
                info += $"  Serie: {serie.Nombre} ({serie.Ranking})\n";
                foreach (var temporada in serie.Temporadas)
                {
                    info += $"    Temporada {temporada.Numero}:\n";
                    foreach (var ep in temporada.Episodios)
                        info += $"      Episodio: {ep.Nombre} ({ep.DuracionMinutos} min)\n";
                }
            }
            return info;
        }
    }

    public class PaquetePremium : Paquete
    {
        public PaquetePremium(string nombre, double precioBase) : base(nombre, precioBase) { }
        public override double CalcularPrecio() => PrecioBase * 1.20;
    }

    public class PaqueteSilver : Paquete
    {
        public PaqueteSilver(string nombre, double precioBase) : base(nombre, precioBase) { }
        public override double CalcularPrecio() => PrecioBase * 1.15;
    }

    // ---- SERIES ----
    public class Serie
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Director { get; set; }
        public double Ranking { get; set; }
        public List<Temporada> Temporadas { get; set; } = new List<Temporada>();

        public Serie(string nombre, string genero, string director, double ranking)
        {
            Nombre = nombre;
            Genero = genero;
            Director = director;
            Ranking = ranking;
        }
    }

    public class Temporada
    {
        public int Numero { get; set; }
        public List<Episodio> Episodios { get; set; } = new List<Episodio>();
    }

    public class Episodio
    {
        public string Nombre { get; set; }
        public int DuracionMinutos { get; set; }
    }

    // ---- INFORMES ----
    public static class Informes
    {
        
        public static double TotalRecaudado(List<Cliente> clientes)
            => clientes.Where(c => c.PaqueteContratado != null)
                       .Sum(c => c.PaqueteContratado!.CalcularPrecio());

        
        public static Paquete? PaqueteMasVendido(List<Cliente> clientes)
        {
            return clientes.Where(c => c.PaqueteContratado != null)
                           .GroupBy(c => c.PaqueteContratado)
                           .OrderByDescending(g => g.Count())
                           .Select(g => g.Key)
                           .FirstOrDefault();
        }

       
        public static List<Serie> SeriesRankingAlto(List<Paquete> paquetes)
        {
            return paquetes.SelectMany(p => p.Series)
                           .Where(s => s.Ranking > 3.5)
                           .ToList();
        }
    }
}
