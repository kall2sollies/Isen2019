using System;
using System.Collections;
using System.Collections.Generic;

namespace Isen.DotNet.Library.Lists
{    
    public class MyCollection<T> : IList<T>
    {
        private T[] _values;

        public MyCollection()
        {
            _values = new T[0];
        }

        /// <summary>
        /// Taille de la liste
        /// </summary>
        public int Count => _values.Length;

        /// <summary>
        /// Accès aux valeurs de la liste
        /// </summary>
        public T[] Values => _values;

        /// <summary>
        /// Accesseur indexeur
        /// </summary>
        /// <value></value>
        public T this[int index]
        {
            get { return _values[index]; }
            set { _values[index] = value; }
        }

        /// <summary>
        /// Ajoute un élément à la fin de la liste
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            // Nouveau tableau de taille + 1
            var tmp = new T[Count + 1];
            // Copier les éléments du tableau initial
            for (var i = 0 ; i < Count ; i++)
            {
                tmp[i] = _values[i];
            }
            // Ajouter le nouvel élément
            tmp[Count] = item;
            // Echanger les tableaux
            _values = tmp;
        }

        public void RemoveAt(int index)
        {
            if (Values?.Length == 0 
                || index > Count 
                || index < 0)
                throw new IndexOutOfRangeException();

            var tmp = new T[Count - 1];
            for (var i = 0 ; i < tmp.Length ; i++)
            {
                tmp[i] = _values[i < index ? i : i + 1];
            }
            _values = tmp;
        }

        public bool IsReadOnly => false;

        public int IndexOf(T item)
        {
            var index = -1;
            for (var i = 0 ; i < Count ; i++)
            {
                if (this[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}