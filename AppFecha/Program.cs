using System;

namespace AppFechas
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CFecha fecha = new CFecha();
                fecha.LeerFecha();  // Solicita al usuario que ingrese la fecha
                Console.WriteLine("Fecha actual: " + fecha.EscribirFecha3());
                Console.WriteLine("Es bisiesto: " + fecha.EsBisiesto());
                Console.WriteLine("Días en el mes: " + fecha.NroDiasMes());
                Console.WriteLine("Días transcurridos en el año: " + fecha.NroDiasAño());
                Console.WriteLine("Días totales desde 01/01/1900: " + fecha.NroDiasTotal());
                Console.WriteLine("Fecha del día siguiente: " + fecha.FechaDiaSiguiente().EscribirFecha3());
                Console.WriteLine("Fecha del día anterior: " + fecha.FechaDiaAnterior().EscribirFecha3());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Pausa para evitar que la consola se cierre inmediatamente
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
