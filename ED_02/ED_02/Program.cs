using System;
using Biblioteca;

namespace ED_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Crear el árbol principal
            Arbol arbolPrincipal = new Arbol(10);

            // Crear subárboles
            Arbol subArbol1 = new Arbol(5);
            Arbol subArbol2 = new Arbol(11);
            Arbol subArbol3 = new Arbol(23);
            Arbol subArbol4 = new Arbol(19);

            // Agregar subárboles al árbol principal
            arbolPrincipal.agregarHijo(subArbol1);
            arbolPrincipal.agregarHijo(subArbol2);

            // Agregar subárbol3 como hijo de subárbol2
            subArbol2.agregarHijo(subArbol3);

            // Agregar subárbol4 como hijo de subárbol3
            subArbol3.agregarHijo(subArbol4);

            // Imprimir el árbol por niveles
            Console.WriteLine("Árbol por niveles:");
            //arbolPrincipal.porNiveles();

            // Imprimir usando inOrden
            Console.WriteLine("\nÁrbol (inOrden):");
            //arbolPrincipal.inOrden();

            // Verificar el nivel del valor 12 en el árbol principal
            int nivelDelValor12 = arbolPrincipal.nivel(12);
            Console.WriteLine($"Nivel del valor 12 en el árbol principal: {nivelDelValor12}");

            Console.WriteLine(arbolPrincipal.ancho());
        }
    }
}
