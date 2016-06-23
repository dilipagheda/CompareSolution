using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CompareUtils;

namespace CompareTestCases
{
    public class CustomClass
    {
        private int temp;
    }

    [TestClass]
    public class CompareTests
    {
        //testcase:1 - verify two distinct objects of type IEnumerable are equal if their members are equal
        [TestMethod]
        public void list_equal_is_true()
        {
            IEnumerable<int> obj1, obj2;

            obj1 = new List<int>() { 10, 20, 30 };
            obj2 = new List<int>() { 10, 20, 30 };

            Assert.IsTrue(obj1.Compare(obj2));
        }

        //testcase:2 - verify two distinct objects of type IEnumerable are not equal if their members are not equal
        [TestMethod]
        public void list_equal_is_not_true()
        {
            IEnumerable<int> obj1, obj2;

            obj1 = new List<int>() { 10, 20, 30 };
            obj2 = new List<int>() { 11, 20  };

            Assert.IsFalse(obj1.Compare(obj2));
        }

        //testcase:3 - verify two distinct objects of different types where types are IEnumerable and CustomClass are not equal
        [TestMethod]
        public void list_is_not_equal_to_custom()
        {
            IEnumerable<int> obj1;
            CustomClass obj2=new CustomClass();

            obj1 = new List<int>() { 10, 20, 30 };

            Assert.IsFalse(obj1.Compare(obj2));
        }

        //testcase:4 - verify two distinct objects of differnt types are not equal even if their values are same
        [TestMethod]
        public void int_is_not_equal_to_float()
        {
            int o1 = 10;
            float o2 = 10f;
            Assert.IsFalse(o1.Compare(o2)); 
        }

        //testcase:5 - verify  two distinct objects of same types are not equal when their values are different
        [TestMethod]
        public void ints_are_not_equal_when_values_differ()
        {
            int p1 = 10;
            int p2 = 20;
            Assert.IsFalse(p1.Compare(p2));
        }

        //testcase:6 - verify  two distinct objects of same types are equal when their values are equal
        [TestMethod]
        public void ints_are_equal_when_values_same()
        {
            int q1 = 20;
            int q2 = 20;
            Assert.IsTrue(q1.Compare(q2)); 
        }
    }
}
