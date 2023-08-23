using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaBinaria
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr;
            int i;
            int buscado;
            char resp;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("       Busqueda Binaria/n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Cuantos datos desea ingresar?: ");
                arr = new int[Int32.Parse(Console.ReadLine())];
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green; 
                for (i = 0; i < arr.Length; i++)  //Ingreso de Datos
                {
                    Console.Write("Ingrese el dato [{0}]: ", i);
                    arr[i] = Int32.Parse(Console.ReadLine());
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\nQue elemento desea buscar?: "); 
                buscado = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                OrdenarArreglo(arr); //Se ordena el arreglo
                BusquedaBinaria(arr, buscado);  //Se realiza la busqueda

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nDesea repetir el programa? (s/n): ");
                resp = char.Parse(Console.ReadLine());
            } while (resp == 'S' || resp == 's'); // se repite el programa las veces que el usuario quiera
        }

        //Funcion que ordena el arreglo de mayor a menor
        public static void OrdenarArreglo(int[] arr)
        {
            int i,j,aux;
            for (i = 0; i < arr.Length-1; i++) //Metodo burbuja
                for (j = i+1; j<arr.Length; j++)
                {
                    if (arr[i]<arr[j])
                    {
                        aux = arr[i];
                        arr[i] = arr[j];
                        arr[j] = aux;
                    }
                }
        }

        //Funcion que realiza la busqueda binaria en el arreglo
        public static void BusquedaBinaria(int[] arr, int num)
        {
            int inferior = 0, superior = arr.Length - 1;
            int mitad = 0;
            int pos = -1;
            int cont = 0;
            bool encontrado = false;

            while (inferior <= superior && encontrado == false)  //Se repite hasta que la condicion encontrado sea true (el numero existe) o que el limite inferior supere al limite superior (no existe el numero)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                for (int i = inferior; i <= superior; i++) // va imprimiendo el proceso de la busqueda
                    Console.Write("[{0}] ", arr[i]);
                Console.WriteLine();
                mitad = (inferior + superior) / 2;
                if (arr[mitad] == num) // Si la mitad es igual al numero buscado sale del bucle
                {
                    encontrado = true;
                    pos = mitad;
                    break;
                }
                else if (num > arr[mitad]) //modifica el limite superior si el numero se encuentra a la izquierda
                    superior = mitad - 1;
                else //modifica el limite inferior si el numero se encuentra a la derecha
                    inferior = mitad + 1;

                cont++;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (encontrado == false)
            {
                Console.WriteLine("\nEl elemento {0} no se encuentra en el arreglo", num);
                Console.WriteLine("Numero de iteraciones: {0}", cont);
            }
            else
            {
                Console.WriteLine("\nEncontrado en la posicion: {0}", pos);
                Console.WriteLine("Numero de iteraciones: {0}", cont);
            }
        }
    }

}
