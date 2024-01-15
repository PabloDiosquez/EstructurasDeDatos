using System;

namespace Biblioteca
{
    public class ArbolBinario
    {
        private int dato;

        private ArbolBinario hijoIzquierdo;

        private ArbolBinario hijoDerecho;

        public ArbolBinario(int dato)
        {
            this.dato = dato;
        }

        public int getDatoRaiz()
        {
            return this.dato;
        }

        public ArbolBinario getHijoIzquierdo()
        {
            return this.hijoIzquierdo;
        }

        public ArbolBinario getHijoDerecho()
        {
            return this.hijoDerecho;
        }

        public void agregarHijoIzquierdo(ArbolBinario arbol)
        {
            this.hijoIzquierdo = arbol;
        }

        public void agregarHijoDerecho(ArbolBinario arbol)
        {
            this.hijoDerecho = arbol;
        }

        public ArbolBinario eliminarHijoIzquierdo()
        {
            ArbolBinario hijoIzquierdo = this.getHijoIzquierdo();

            this.hijoIzquierdo = null;

            return hijoIzquierdo;
        }

        public ArbolBinario eliminarHijoDerecho()
        {
            ArbolBinario hijoDerecho = this.getHijoDerecho();

            this.hijoDerecho = null;

            return hijoDerecho;
        }

        public bool esHoja()
        {
            return this.hijoIzquierdo is null && this.hijoDerecho is null;
        }

        public void agregar(int elemento)
        {
            agregar(this, elemento);
        }

        private ArbolBinario agregar(ArbolBinario arbol, int elemento)
        {
            if (arbol is null)
            {
                return new ArbolBinario(elemento);
            }

            if (elemento < arbol.getDatoRaiz()) 
            {
                arbol.hijoIzquierdo = agregar(arbol.hijoIzquierdo, elemento);
            } else if (elemento > arbol.getDatoRaiz()) 
            {
                arbol.hijoDerecho = agregar(arbol.hijoDerecho, elemento);
            }

            return arbol;
        }

        public bool incluye(int elemento)
        {
            return incluye(this, elemento);
        }

        private bool incluye(ArbolBinario arbol, int elemento)
        {
            if (arbol is null)
            {
                return false;
            }

            return arbol.getDatoRaiz() == elemento || incluye(arbol.hijoIzquierdo, elemento) || incluye(arbol.hijoDerecho, elemento);
        }

        // Recorridos 

        public void preOrden()
        {
            Console.WriteLine(this.getDatoRaiz());

            this.hijoIzquierdo?.preOrden();

            this.hijoDerecho?.preOrden();
        }

        public void inOrden()
        {
            this.hijoIzquierdo.inOrden();

            Console.WriteLine(this.getDatoRaiz());

            this.hijoDerecho?.inOrden();
        }

        public void postOrden()
        {
            hijoIzquierdo?.postOrden();

            hijoDerecho?.postOrden();

            Console.WriteLine(this.getDatoRaiz());
        }

        public int contarHojas()
        {
            if (this.esHoja())
            {
                return 1;
            }

            int hojasIzquierdas = this.hijoIzquierdo?.contarHojas() ?? 0;
            int hojasDerechas   = this.hijoDerecho?.contarHojas() ?? 0;

            return hojasIzquierdas + hojasDerechas;
        }
    }
}
