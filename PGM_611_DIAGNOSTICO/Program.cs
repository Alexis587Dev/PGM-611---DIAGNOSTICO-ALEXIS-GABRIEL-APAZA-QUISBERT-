using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGM_611_DIAGNOSTICO
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            int L = 0;
            int R = 0;
            bool alert = false;

            Console.WriteLine("CANTIDAD DE NUMEROS PRIMOS EN UN INTERVALO DE NUMEROS ENTEROS");
            Console.Write("Ingrese el primer valor: ");
            alert = !int.TryParse(Console.ReadLine(), out L);
            Console.Write("Ingrese el segundo valor: ");
            alert = !int.TryParse(Console.ReadLine(), out R);
            Console.WriteLine("Intervalo ingresado: {" + L + " ; " + R + "}");

            if (L >= R || L < 1 || R > 100000000|| alert == true)
            {
                Console.WriteLine("ERROR: Valores no validos o fuera de rango fueron ingresados");
            }else if (L == 0 && R == 0)
            {
                Console.WriteLine("Programa terminado");
            }
            else
            {
                stopwatch.Start();
                int cantPrimes = GetCantPrimes(L, R);
                stopwatch.Stop();

                Console.WriteLine("La cantidad de numeros primos entre el intervalo {" + L + " ; " + R + "} es " + cantPrimes);
                Console.WriteLine($"Tiempo de ejecución: {stopwatch.ElapsedMilliseconds} ms");
            }
        }

        //Version 1 basada en iteraciones
        public static int GetCantPrimesIterative(int L, int R)
        {
            int cantPrimes = 0;
            for (int i = L; i <= R; i++)
            {
                int cantDivided = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        cantDivided++;
                    }
                }
                if (cantDivided == 2)
                {
                    cantPrimes++;
                }
            }
            return cantPrimes;
        }

        //Version 2 basada en la criba de eratostenes
        public static int GetCantPrimes(int L, int R)
        {
            int count = 0;
            bool[] arrBools = new bool[R + 1];

            arrBools[0] = false;
            arrBools[1] = false;

            for (int i = 2; i <= R; i++)
            {
                arrBools[i] = true;
            }

            for (int index = 2; index * index <= R; index++)
            {
                if (arrBools[index] == true)
                { 
                    for (int i = index * index; i <= R; i += index)
                    {
                        arrBools[i] = false;
                    }
                }
            }

            for (int i = 2; i <= R; i++)
            {
                if (i >= L && arrBools[i])
                {
                    count++;
                }
            }

            return count;
            
        }

    }
}
