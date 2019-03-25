using System;

namespace Isen.DotNet.Library.Lists
{    
    public class MyCollection
    {
        private string[] _values;

        public MyCollection()
        {
            _values = new string[0];
        }

        /// <summary>
        /// Taille de la liste
        /// </summary>
        public int Count => _values.Length;

        /// <summary>
        /// Accès aux valeurs de la liste
        /// </summary>
        public string[] Values => _values;

        /// <summary>
        /// Accesseur indexeur
        /// </summary>
        /// <value></value>
        public string this[int index]
        {
            get { return _values[index]; }
            set { _values[index] = value; }
        }

        /// <summary>
        /// Ajoute un élément à la fin de la liste
        /// </summary>
        /// <param name="item"></param>
        public void Add(string item)
        {
            // Nouveau tableau de taille + 1
            var tmp = new string[Count + 1];
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

            var tmp = new string[Count - 1];
            for (var i = 0 ; i < tmp.Length ; i++)
            {
                if (i < index) tmp[i] = _values[i];
                else if (i >= index) tmp[i] = _values[i + 1];
            }
            _values = tmp;
        }
    }
}