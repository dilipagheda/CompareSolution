using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public static class CompareTest
    {
        public static bool Compare(this object group1, object group2)
        {
            //if any of the parameter is null, return false
            if(group1 == null || group2 ==null)
              return false;

            //if types are different then return false
            Type t1 = group1.GetType();
            Type t2 = group2.GetType();
            
            if(!t2.Equals(t2))
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


    class Program
    {
        static void Main(string[] args)
        {
            //testcase:1 - verify two distinct objects of type IEnumerable are equal if their members are equal
            IEnumerable<int> obj1, obj2;
            
            obj1 = new List<int>() { 10, 20, 30 };
            obj2 = new List<int>() { 10, 20, 30 };

            Console.WriteLine(obj1.Compare(obj2)); //prints true

            //testcase:2 - verify two distinct objects of differnt types are not equal even if their values are same
            int o1=10;
            float o2=10f;
            Console.WriteLine(o1.Compare(o2)); //prints false

            //testcase:3 - verify  two distinct objects of same types are not equal when their values are different
            int p1 = 10;
            int p2 = 20;
            Console.WriteLine(p1.Compare(p2)); //prints false

            //testcase:4 - verify  two distinct objects of same types are equal when their values are equal
            int q1 = 20;
            int q2 = 20;
            Console.WriteLine(q1.Compare(q2)); //prints true

            Console.Read();


        }
    }
}
