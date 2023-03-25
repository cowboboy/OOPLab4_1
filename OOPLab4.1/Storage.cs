using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab4._1
{
    internal class Storage
    {
        Figure[] elements;
        public int size { get; set; }

        public Storage()
        {
            size = 0;
        }

        public void push_back(in Figure element)
        {
            Figure[] changedElements = new Figure[size + 1];
            int i = 0;
            for (; i < size; i++)
            {
                changedElements[i] = elements[i];
            }
            changedElements[i] = element;
            elements = changedElements;
            ++size;
        }

        public void push_front(in Figure element)
        {
            Figure[] changedElements = new Figure[size + 1];
            changedElements[0] = element;
            for (int i = 1; i < changedElements.Length; i++)
            {
                changedElements[i] = elements[i];
            }
            elements = changedElements;
            ++size;
        }

        public ref Figure getObject(int index)
        {
            return ref elements[index];
        }
    }
}
