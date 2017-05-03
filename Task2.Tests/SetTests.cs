using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2.Tests
{
    public class SetTests
    {
        [TestCase(new[] { "AAA", "BBB", "CCC" }, "DDD")]
        public void Add_SetAddElement(string[] array, string element)
        {
            Set<string> set = new Set<string>(array);
            set.Add(element);
            Assert.AreEqual(set, new Set<string>(new[] { "AAA", "BBB", "CCC", "DDD" }));
        }

        [TestCase(new[] {  "AAA", "BBB", "CCC", "DDD","EEE" }, "CCC")]
        public void Remove_SetRemoveElement(string[] array, string element)
        {
            Set<string> set = new Set<string>(array);
            set.Remove(element);
            Assert.AreEqual(set, new Set<string>(new[] { "AAA", "BBB", "DDD", "EEE" }));
        }


        [TestCase(new[] {  "CCC" }, "CCC")]
        public void RemoveLast_SetRemoveLastElement(string[] array, string element)
        {
            Set<string> set = new Set<string>(array);
            set.Remove(element);
            Assert.AreEqual(set, new Set<string>());
        }

        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "DDD", "EEE","FFF", "GGG" })]
        public void Intersection_TwoSetsIntersect(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            var result = Set<string>.Intersection(set1,set2);
            Assert.AreEqual(result, new Set<string>(new[] { "DDD", "EEE" }));
        }

        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "DDD", "EEE", "FFF", "GGG" })]
        public void Union_TwoSetsUnion(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            var result = Set<string>.Union(set1,set2);
            Assert.AreEqual(result, new Set<string>(new[] { "AAA", "BBB", "CCC", "DDD", "EEE", "FFF", "GGG" }));
        }

        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "DDD", "EEE", "FFF", "GGG" })]
        public void Difference_TwoSetsDifference(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            var result = Set<string>.Difference(set1, set2);
            Assert.AreEqual(result, new Set<string>(new[] { "AAA", "BBB", "CCC" }));
        }

        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "DDD", "EEE", "FFF", "GGG" })]
        public void SymmetricDifference_TwoSetsSymmetricDifference(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            var result = Set<string>.SymmetricDifference(set1, set2);
            Assert.AreEqual(result, new Set<string>(new[] { "AAA", "BBB", "CCC","FFF","GGG" }));
        }



        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "DDD", "EEE", "FFF", "GGG" })]
        public void IntersectionWith_TwoSetsIntersect(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            var result = set1.IntersectionWith(set2);
            Assert.AreEqual(result, new Set<string>(new[] { "DDD", "EEE" }));
        }

        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "DDD", "EEE", "FFF", "GGG" })]
        public void UnionWith_TwoSetsUnion(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            var result = set1.UnionWith(set2);
            Assert.AreEqual(result, new Set<string>(new[] { "AAA", "BBB", "CCC", "DDD", "EEE", "FFF", "GGG" }));
        }

        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "DDD", "EEE", "FFF", "GGG" })]
        public void DifferenceWith_TwoSetsDifference(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            var result = set1.DifferenceWith(set2);
            Assert.AreEqual(result, new Set<string>(new[] { "AAA", "BBB", "CCC" }));
        }

        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "DDD", "EEE", "FFF", "GGG" })]
        public void SymmetricDifferenceWith_TwoSetsSymmetricDifference(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            var result = set1.SymmetricDifferenceWith(set2);
            Assert.AreEqual(result, new Set<string>(new[] { "AAA", "BBB", "CCC", "FFF", "GGG" }));
        }



        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, ExpectedResult = true)]
        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "AAA", "BBB", "CCC", "DDD", "EEE", "FFF" }, ExpectedResult = false)]
        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "BBB", "AAA", "CCC", "DDD", "EEE" }, ExpectedResult = true)]
        public bool Equals_TwoSets(string[] array1, string[] array2)
        {
            Set<string> set1 = new Set<string>(array1);
            Set<string> set2 = new Set<string>(array2);
            return set1.Equals(set2);
        }

        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, ExpectedResult = true)]
        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "AAA", "BBB", "CCC", "DDD", "EEE", "FFF" }, ExpectedResult = false)]
        [TestCase(new[] { "AAA", "BBB", "CCC", "DDD", "EEE" }, new[] { "BBB", "AAA", "CCC", "DDD", "EEE" }, ExpectedResult = true)]
        public bool Equals_TwoObjectSets(string[] array1, string[] array2)
        {
            Object set1 = new Set<string>(array1);
            Object set2 = new Set<string>(array2);
            return set1.Equals(set2);
        }
    }
}
