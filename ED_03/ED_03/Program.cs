using System;
using Biblioteca;

namespace ED_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario arbol = new ArbolBinario(5);

            arbol.agregar(12);
            arbol.agregar(4);
            arbol.agregar(1);
            arbol.agregar(21);
            arbol.agregar(100);

            arbol.preOrden();

            Console.WriteLine(arbol.incluye(5));
            Console.WriteLine(arbol.contarHojas());
        }
    }
}
