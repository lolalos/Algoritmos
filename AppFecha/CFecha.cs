using System;
using System.Linq;

namespace AppFechas
{
    internal class CFecha
    {
        // Atributos
        private int aDia;
        private int aMes;
        private int aAño;

        // Métodos

        // Constructores
        public CFecha()
        {
            aDia = 1;
            aMes = 1;
            aAño = 1900;
        }

        public CFecha(int pDia, int pMes, int pAño)
        {
            if (EsFechaValida(pDia, pMes, pAño))
            {
                aDia = pDia;
                aMes = pMes;
                aAño = pAño;
            }
            else
            {
                throw new ArgumentException("Fecha no válida.");
            }
        }

        // Modificadores
        public void modificarDia(int pDia)
        {
            if (EsFechaValida(pDia, aMes, aAño))
                aDia = pDia;
            else
                throw new ArgumentException("Día no válido.");
        }

        public void modificarMes(int pMes)
        {
            if (EsFechaValida(aDia, pMes, aAño))
                aMes = pMes;
            else
                throw new ArgumentException("Mes no válido.");
        }

        public void modificarAño(int pAño)
        {
            if (EsFechaValida(aDia, aMes, pAño))
                aAño = pAño;
            else
                throw new ArgumentException("Año no válido.");
        }

        // Selectores
        public int seleccionarDia() => aDia;
        public int seleccionarMes() => aMes;
        public int seleccionarAño() => aAño;

        // Otros métodos

        // Determina si el año es bisiesto
        public bool EsBisiesto()
        {
            return (aAño % 4 == 0 && aAño % 100 != 0) || (aAño % 400 == 0);
        }

        // Devuelve el número de días del mes actual
        public int NroDiasMes()
        {
            int[] diasPorMes = { 31, EsBisiesto() ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return diasPorMes[aMes - 1];
        }

        // Calcula el número de días transcurridos en el año actual hasta la fecha
        public int NroDiasAño()
        {
            int dias = 0;
            for (int i = 1; i < aMes; i++)
            {
                dias += NroDiasMes(i, aAño);
            }
            dias += aDia;
            return dias;
        }

        // Calcula el número total de días desde el 01/01/1900 hasta la fecha actual
        public int NroDiasTotal()
        {
            int diasTotales = 0;
            for (int año = 1900; año < aAño; año++)
            {
                diasTotales += EsBisiesto(año) ? 366 : 365;
            }
            diasTotales += NroDiasAño();
            return diasTotales;
        }

        // Retorna la fecha en formato "dd/mm/aa"
        public string EscribirFecha1()
        {
            return $"{aDia:D2}/{aMes:D2}/{aAño:D2}";
        }

        // Retorna la fecha en formato "23 de noviembre de 1984"
        public string EscribirFecha2()
        {
            return $"{aDia} de {NombreDelMes()} de {aAño}";
        }

        // Retorna la fecha en formato "martes 23 de noviembre de 1984"
        public string EscribirFecha3()
        {
            return $"{NombreDelDia()} {aDia} de {NombreDelMes()} de {aAño}";
        }

        // Lee la fecha desde la consola con validaciones y soporte para diferentes formatos
        public void LeerFecha()
        {
            bool fechaValida = false;

            while (!fechaValida)
            {
                try
                {
                    Console.Write("Ingrese la fecha en formato dd-mm-aaaa o dd/mm/aaaa: ");
                    string entrada = Console.ReadLine();

                    // Detecta el separador y divide la cadena
                    char separador = entrada.Contains('-') ? '-' : '/';
                    string[] partes = entrada.Split(separador);

                    if (partes.Length == 3)
                    {
                        aDia = int.Parse(partes[0]);
                        aMes = int.Parse(partes[1]);
                        aAño = int.Parse(partes[2]);

                        if (EsFechaValida(aDia, aMes, aAño))
                        {
                            fechaValida = true;
                        }
                        else
                        {
                            Console.WriteLine("Fecha no válida. Por favor, intente nuevamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Formato no válido. Asegúrese de usar el formato dd-mm-aaaa o dd/mm/aaaa.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato no válido. Por favor, ingrese valores numéricos separados por '-' o '/'.");
                }
            }
        }

        // Devuelve el nombre del mes
        public string NombreDelMes()
        {
            string[] nombresMes = { "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };
            return nombresMes[aMes - 1];
        }

        // Devuelve el nombre del día de la semana usando el algoritmo de Zeller
        public string NombreDelDia()
        {
            int q = aDia;
            int m = aMes;
            int y = aAño;

            if (m < 3)
            {
                m += 12;
                y -= 1;
            }

            int k = y % 100;
            int j = y / 100;

            int h = (q + (13 * (m + 1)) / 5 + k + (k / 4) + (j / 4) + 5 * j) % 7;

            // En el resultado de Zeller: 0 = sábado, 1 = domingo, ..., 6 = viernes
            string[] nombresDia = { "sábado", "domingo", "lunes", "martes", "miércoles", "jueves", "viernes" };
            return nombresDia[h];
        }

        // Calcula la fecha del día siguiente
        public CFecha FechaDiaSiguiente()
        {
            int dia = aDia + 1;
            int mes = aMes;
            int año = aAño;

            if (dia > NroDiasMes())
            {
                dia = 1;
                mes++;
                if (mes > 12)
                {
                    mes = 1;
                    año++;
                }
            }

            return new CFecha(dia, mes, año);
        }

        // Calcula la fecha del día anterior
        public CFecha FechaDiaAnterior()
        {
            int dia = aDia - 1;
            int mes = aMes;
            int año = aAño;

            if (dia < 1)
            {
                mes--;
                if (mes < 1)
                {
                    mes = 12;
                    año--;
                }
                dia = NroDiasMes(mes, año);
            }

            return new CFecha(dia, mes, año);
        }

        // Valida que la fecha sea correcta
        private bool EsFechaValida(int dia, int mes, int año)
        {
            if (mes < 1 || mes > 12 || dia < 1 || dia > NroDiasMes(mes, año))
                return false;
            return true;
        }

        // Determina el número de días en un mes específico y año específico
        private int NroDiasMes(int mes, int año)
        {
            int[] diasPorMes = { 31, EsBisiesto(año) ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return diasPorMes[mes - 1];
        }

        // Determina si un año específico es bisiesto
        private bool EsBisiesto(int año)
        {
            return (año % 4 == 0 && año % 100 != 0) || (año % 400 == 0);
        }
    }
}
