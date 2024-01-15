using System;
using System.Collections.Generic;

namespace Biblioteca
{
    /// <summary>
    /// Clase que representa un nodo en una estructura de árbol.
    /// </summary>
    public class Nodo
    {
        private int dato;
        private List<Nodo> hijos;

        /// <summary>
        /// Constructor que inicializa un nodo con un valor de dato.
        /// </summary>
        /// <param name="dato">Valor del nodo.</param>
        public Nodo(int dato)
        {
            this.dato = dato;
            this.hijos = new List<Nodo>();
        }

        /// <summary>
        /// Constructor que inicializa un nodo copiando otro nodo.
        /// </summary>
        /// <param name="nodo">Nodo a ser copiado.</param>
        public Nodo(Nodo nodo)
            : this(nodo.dato)
        {
            // No se requieren acciones adicionales, ya que el constructor principal se llama con el dato del nodo.
        }

        /// <summary>
        /// Obtiene el valor de dato del nodo.
        /// </summary>
        /// <returns>Valor de dato del nodo.</returns>
        public int GetDato()
        {
            return this.dato;
        }

        /// <summary>
        /// Obtiene la lista de hijos del nodo.
        /// </summary>
        /// <returns>Lista de hijos del nodo.</returns>
        public List<Nodo> GetHijos()
        {
            return this.hijos;
        }

        /// <summary>
        /// Establece el valor de dato del nodo.
        /// </summary>
        /// <param name="dato">Nuevo valor de dato.</param>
        /// <exception cref="Exception">Se lanza cuando el nodo es nulo.</exception>
        public void SetDato(int dato)
        {
            if (this is null) throw new Exception("Nodo nulo");
            this.dato = dato;
        }

        /// <summary>
        /// Establece la lista de hijos del nodo.
        /// </summary>
        /// <param name="hijos">Nueva lista de hijos.</param>
        /// <exception cref="Exception">Se lanza cuando el nodo es nulo.</exception>
        private void SetHijos(List<Nodo> hijos)
        {
            if (this is null) throw new Exception("Nodo nulo");
            this.hijos = hijos;
        }
    }
}
