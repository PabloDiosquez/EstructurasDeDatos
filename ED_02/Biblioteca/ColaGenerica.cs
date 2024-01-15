using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    /// <summary>
    /// Clase que representa una cola genérica.
    /// </summary>
    /// <typeparam name="T">Tipo de elementos en la cola.</typeparam>
    public class ColaGenerica<T>
    {
        private List<T> encolados;

        /// <summary>
        /// Constructor de la clase <see cref="ColaGenerica{T}"/>.
        /// </summary>
        public ColaGenerica()
        {
            this.encolados = new List<T>();
        }

        /// <summary>
        /// Verifica si la cola está vacía.
        /// </summary>
        /// <returns>True si la cola está vacía, false de lo contrario.</returns>
        public bool EsVacia()
        {
            // Utilizando el método Any() para verificar si la lista está vacía.
            return !this.encolados.Any();
        }

        /// <summary>
        /// Obtiene el elemento en el tope de la cola.
        /// </summary>
        /// <returns>El elemento en el tope de la cola.</returns>
        /// <exception cref="Exception">Se lanza cuando la cola está vacía.</exception>
        public T Tope()
        {
            // Verifica si la cola está vacía antes de acceder al tope.
            if (this.EsVacia())
            {
                throw new Exception("La cola no debe ser vacía.");
            }
            return this.encolados[0];
        }

        /// <summary>
        /// Encola un elemento en la cola.
        /// </summary>
        /// <param name="elemento">Elemento a encolar.</param>
        public void Encolar(T elemento)
        {
            this.encolados.Add(elemento);
        }

        /// <summary>
        /// Desencola el elemento en el tope de la cola.
        /// </summary>
        /// <returns>El elemento desencolado.</returns>
        /// <exception cref="Exception">Se lanza cuando la cola está vacía.</exception>
        public T Desencolar()
        {
            // Verifica si la cola está vacía antes de intentar desencolar.
            if (this.EsVacia())
            {
                throw new Exception("La cola no debe ser vacía.");
            }

            // Obtén el elemento desencolado y remuévelo de la lista.
            T desencolado = this.encolados[0];
            this.encolados.Remove(desencolado);

            return desencolado;
        }
    }
}
