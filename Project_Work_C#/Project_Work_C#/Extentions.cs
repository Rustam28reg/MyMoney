using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_C_
{
    public static class ListExtensions
    {
        public static void Replace<T>(this List<T> list, T oldValue, T newValue)
        {
            int index = list.IndexOf(oldValue);
            if (index >= 0)
            {
                list[index] = newValue;
            }
        }
    }
}
