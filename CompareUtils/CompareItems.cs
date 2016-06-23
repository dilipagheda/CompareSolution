using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareUtils
{
    public static class CompareItems
    {
        public static bool Compare(this object group1, object group2)
        {
            //if any of the parameter is null, return false
            if (group1 == null || group2 == null)
                return false;

            //if types are different then return false
            Type t1 = group1.GetType();
            Type t2 = group2.GetType();

            if (!t2.Equals(t2))
                return false;

            //compare if both are pointing to the same object of same type, if yes then return true
            if (group1 == group2)
            {
                return true;
            }

            //if both paramters are of type IEnumerable then call method CompareList to reuse that logic
            List<object> list1 = new List<object>();
            List<object> list2 = new List<object>();
            if ((group1 is IEnumerable) && (group2 is IEnumerable))
            {
                var enumerator1 = ((IEnumerable)group1).GetEnumerator();
                var enumerator2 = ((IEnumerable)group2).GetEnumerator();
                while (enumerator1.MoveNext())
                {
                    list1.Add(enumerator1.Current);
                }
                while (enumerator2.MoveNext())
                {
                    list2.Add(enumerator2.Current);
                }
                return list1.CompareList(list2);
            }

            return (group1.Equals(group2));
        }

        public static bool CompareList<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {
            if (list1 == list2)
            {
                return true;
            }
            if (list1 != null && list2 != null)
            {
                return list1.SequenceEqual(list2);
            }
            return false;
        }
    }
}
