using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Arbol
    {
        private Nodo raiz;

        public Arbol(int dato)
        {
            this.raiz = new Nodo(dato);
        }

        private Arbol(Nodo raiz)
        {
            if (raiz == null) throw new ArgumentNullException("Null Refference Exception");

            this.raiz = raiz;
        }

        private Nodo getRaiz()
        {
            return this.raiz;
        }

        public int getValorRaiz()
        {
            return this.raiz.GetDato();
        }

        public List<Arbol> getHijos()
        {
            List<Arbol> arboles = new List<Arbol>();
            foreach (Nodo hijo in this.raiz.GetHijos())
            {
                arboles.Add(new Arbol(hijo));
            }
            return arboles;
        }

        public void agregarHijo(Arbol arbol)
        {
            this.raiz.GetHijos().Add(arbol.getRaiz());
        }

        public void eliminarHijo(Arbol arbol)
        {
            this.raiz.GetHijos().Remove(arbol.getRaiz());
        }

        public bool esVacio()
        {
            return this.raiz is null;
        }

        public bool esHoja()
        {
            return this.raiz is not null && this.raiz.GetHijos().Count == 0;
        }

        // Describe la altura del árbol, i.e., la longitud del camino más largo 
        // desde el nodo raíz hasta una hoja.
        public int altura() 
        {
            if (this.esHoja()) 
            {
                return 0;
            }

            int alturaMaxima = 0;

            foreach (Arbol hijo in this.getHijos())
            {
                int alturahijo = hijo.altura();

                if (alturahijo > alturaMaxima)
                {
                    alturaMaxima = alturahijo;
                }
            }
            return 1 + alturaMaxima;
        }

        public int nivel(int dato)
        {
            if (this.getValorRaiz() == dato)
            {
                return 0;
            }

            foreach (Arbol hijo in this.getHijos())
            {
                if (hijo.include(dato)) 
                {
                    return 1 + hijo.nivel(dato);
                }
            }
            return -1;
        }

        // La amplitud (ancho) de un árbol se define como la cantidad de nodos que se
        // encuentran en el nivel que posee la mayor cantidad de nodos.
        public int ancho()
        {
        //    if (this.getRaiz() is null)
        //    {
        //        return -1;  // Otra opción podría ser lanzar una excepción en lugar de devolver -1
        //    }

            int ancho = 0;

            ColaGenerica<Arbol> encolados = new ColaGenerica<Arbol>();

            encolados.Encolar(new Arbol(this.getValorRaiz()));

            encolados.Encolar(null);

            while (!encolados.EsVacia())
            {
                int nroNodosDelNivel = encolados.Length() - 1;  // Restamos 1 para excluir el elemento nulo

                if (nroNodosDelNivel > ancho)
                {
                    ancho = nroNodosDelNivel;
                }

                while (encolados.Length() > 0)
                {
                    Arbol desencolado = encolados.Desencolar();

                    if (desencolado is not null)
                    {
                        foreach (Arbol hijo in desencolado.getHijos())
                        {
                            if (hijo != null)
                            {
                                encolados.Encolar(hijo);
                            }
                        }
                    }
                }

                if (!encolados.EsVacia())
                {
                    encolados.Encolar(null);  // Marcar el final del nivel
                }
            }
            return ancho;
        }

        private bool include(int dato)
        {
            ColaGenerica<Arbol> arboles = new ColaGenerica<Arbol>();

            arboles.Encolar(this);

            while (!arboles.EsVacia())
            {
                Arbol desencolado = arboles.Desencolar();

                if (desencolado.getValorRaiz() == dato)
                {
                    return true;
                }

                foreach (Arbol hijo in desencolado.getHijos())
                {
                    arboles.Encolar(hijo);
                }
            }
            return false;
        }

        public void preOrden()
        {
            if (this is not null)
            {
                Console.WriteLine(this.getValorRaiz());

                foreach (Arbol hijo in this.getHijos())
                {
                    hijo.preOrden();
                }
            }
        }

        public void inOrden()
        {
            if (this is not null)
            {
                if (!this.esHoja())
                {
                    Arbol primerHijo = this.getHijos()[0];

                    primerHijo.inOrden();

                    Console.WriteLine(this.getValorRaiz());

                    List<Arbol> hijosRestantes = this.getHijos().GetRange(1, this.getHijos().Count - 1);

                    foreach (Arbol hijo in hijosRestantes)
                    {
                        hijo.inOrden();
                    }
                }
                else
                {
                    Console.WriteLine(this.getValorRaiz());
                }
            }
        }

        public void postOrden()
        {
            if (this is not null)
            {
                foreach (Arbol hijo in this.getHijos())
                {
                    hijo.postOrden();
                }
                Console.WriteLine(this.getValorRaiz());
            }
        }

        public void porNiveles()
        {
            ColaGenerica<Arbol> arboles = new ColaGenerica<Arbol>();

            arboles.Encolar(new Arbol(this.getRaiz()));

            while (!arboles.EsVacia())
            {
                Arbol desencolado = arboles.Desencolar();

                Console.WriteLine(desencolado.getValorRaiz());

                foreach (Arbol hijo in desencolado.getHijos())
                {
                    arboles.Encolar(hijo);
                }
            } 
        }

    }
}
