using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Task5.Tests
{
    public class BinarySearchTreeTests
    {

        #region Source and Expected objects
        public struct Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }


        #region Integers
        private static readonly BinarySearchTree<int> Integers =
           new BinarySearchTree<int>(new List<int> { -1, 13, 16, 8, 14 }, Comparer<int>.Default);
        private static readonly string IntegersPreOrder = "-1 13 8 16 14";
        private static readonly string IntegersInOrder = "-1 8 13 14 16";
        private static readonly string IntegersPostOrder = "8 14 16 13 -1";
        
        
        private static readonly BinarySearchTree<int> IntegersWithComparison =
            new BinarySearchTree<int>(new List<int> { -1, 13, 16, 8, 14 }, delegate (int first, int second) { return ((-1 * first > -1 * second) ? 1 : -1 * first < -1 * second ? -1 : 0); });
        private static readonly string IntegersWithComparisonPreOrder = "-1 13 16 14 8";
        private static readonly string IntegersWithComparisonInOrder = "16 14 13 8 -1";
        private static readonly string IntegersWithComparisonPostOrder = "14 16 8 13 -1";
        #endregion

        #region Strings
        private static readonly BinarySearchTree<string> Strings =
            new BinarySearchTree<string>(new List<string> { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" }, Comparer<string>.Default);
        private static readonly string StringsPreOrder = "Mercury Earth Mars Jupiter Venus Saturn Neptune Uranus";
        private static readonly string StringsInOrder = "Earth Jupiter Mars Mercury Neptune Saturn Uranus Venus";
        private static readonly string StringsPostOrder = "Jupiter Mars Earth Neptune Uranus Saturn Venus Mercury";
       


        private static readonly BinarySearchTree<string> StringsWithComparison =
            new BinarySearchTree<string>(new List<string> { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" }, delegate (string first,string second) { return String.Compare(first.First().ToString(), second.Last().ToString()); });
        private static readonly string StringsWithComparisonPreOrder = "Mercury Venus Earth Mars Jupiter Neptune Saturn Uranus";
        private static readonly string StringsWithComparisonInOrder = "Earth Neptune Jupiter Mars Venus Saturn Uranus Mercury";
        private static readonly string StringsWithComparisonPostOrder = "Neptune Jupiter Mars Earth Uranus Saturn Venus Mercury";
        #endregion

        #region Books
        private static readonly Book book1 = new Book("Преступление и наказание", "Федор Достоевский", "роман", 608, "русский", "Россия");
        private static readonly Book book2 = new Book("Война и мир", "Лев Толстой", "роман-эпопея", 1408, "русский", "Россия");
        private static readonly Book book3 = new Book("Собачье сердце", "Михаил Булгаков", "повесть", 384, "русский", "Россия");
        private static readonly Book book4 = new Book("Тихий Дон", "Михаил Шолохов", "роман-эпопея", 1505, "русский", "Россия");
        
        private static readonly BinarySearchTree<Book> Books =
            new BinarySearchTree<Book>(new List<Book> { book1, book2, book3, book4 }, Comparer<Book>.Default);
        List<Book> BooksPreOrder = new List<Book> { book1, book3, book2, book4 };
        List<Book> BooksInOrder = new List<Book> { book3, book1, book2, book4 };
        List<Book> BooksPostOrder = new List<Book> { book3, book4, book2, book1 };
        private static readonly BinarySearchTree<Book> BooksWithComparison =
           new BinarySearchTree<Book>(new List<Book> { book1, book2, book3, book4 }, delegate (Book firstBook, Book secondBook)
           {
               return firstBook.Title.CompareTo(secondBook.Title);
           });
        List<Book> BooksWithComparisonPreOrder = new List<Book> { book1, book2, book3, book4 };
        List<Book> BooksWithComparisonInOrder = new List<Book> { book2, book1, book3, book4 };
        List<Book> BooksWithComparisonPostOrder = new List<Book> { book2, book4, book3, book1 };
        #endregion
        
        #region Points
        private static readonly Point Point1 = new Point(2, 4);
        private static readonly Point Point2 = new Point(6, -5);
        private static readonly Point Point3 = new Point(13, 13);

        

        private static readonly BinarySearchTree<Point> PointsWithComparison =
            new BinarySearchTree<Point>(new List<Point> { Point1, Point2, Point3 }, delegate (Point first, Point second)
            {
                return (first.X+first.Y).CompareTo(second.X+second.Y);
            });
        List<Point> PointsWithComparisonPreOrder = new List<Point> { Point1, Point2, Point3 };
        List<Point> PointsWithComparisonInOrder = new List<Point> { Point2, Point1, Point3 };
        List<Point> PointsWithComparisonPostOrder = new List<Point> { Point2, Point3, Point1 };
        #endregion

        #endregion







        #region Tests

        [Test]
        public void PreOrder_IntegerValues()
        {
            string temp = String.Empty;
            foreach (var item in Integers.PreOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(),IntegersPreOrder);
           
        }

        [Test]
        public void InOrder_IntegerValues()
        {
            string temp = String.Empty;
            foreach (var item in Integers.InOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), IntegersInOrder);
        }

        [Test]
        public void PostOrder_IntegerValues()
        {
            string temp = String.Empty;
            foreach (var item in Integers.PostOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), IntegersPostOrder);
        }
        
        [Test]
        public void PreOrder_IntegerValuesWithComparison()
        {
            string temp = String.Empty;
            foreach (var item in IntegersWithComparison.PreOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), IntegersWithComparisonPreOrder);
        }

        [Test]
        public void InOrder_IntegerValuesWithComparison()
        {
            string temp = String.Empty;
            foreach (var item in IntegersWithComparison.InOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), IntegersWithComparisonInOrder);
        }

        [Test]
        public void PostOrder_IntegerValuesWithComparison()
        {
            string temp = String.Empty;
            foreach (var item in IntegersWithComparison.PostOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), IntegersWithComparisonPostOrder);
        }


        [Test]
        public void PreOrder_Strings()
        {
            string temp = String.Empty;
            foreach (var item in Strings.PreOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), StringsPreOrder);
        }

        [Test]
        public void InOrder_Strings()
        {
            string temp = String.Empty;
            foreach (var item in Strings.InOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), StringsInOrder);
        }

        [Test]
        public void PostOrder_Strings()
        {
            string temp = String.Empty;
            foreach (var item in Strings.PostOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), StringsPostOrder);
        }

        [Test]
        public void PreOrder_StringsWithComparison()
        {
            string temp = String.Empty;
            foreach (var item in StringsWithComparison.PreOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), StringsWithComparisonPreOrder);
        }

        [Test]
        public void InOrder_StringsWithComparison()
        {
            string temp = String.Empty;
            foreach (var item in StringsWithComparison.InOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), StringsWithComparisonInOrder);
        }

        [Test]
        public void PostOrder_StringsWithComparison()
        {
            string temp = String.Empty;
            foreach (var item in StringsWithComparison.PostOrder())
            {
                temp += item + " ";
            }
            Assert.AreEqual(temp.Trim(), StringsWithComparisonPostOrder);
        }

        
        [Test]
        public void PreOrder_Books()
        {

            List<Book> temp = new List<Book>();
            foreach (var item in Books.PreOrder())
                temp.Add(item);
            Assert.AreEqual(temp, BooksPreOrder);
        }

        [Test]
        public void InOrder_Books()
        {
            List<Book> temp = new List<Book>();
            foreach (var item in Books.InOrder())
                temp.Add(item);
            Assert.AreEqual(temp, BooksInOrder);
        }

        [Test]
        public void PostOrder_Books()
        {
            List<Book> temp = new List<Book>();
            foreach (var item in Books.PostOrder())
                temp.Add(item);
            Assert.AreEqual(temp, BooksPostOrder);
        }

        [Test]
        public void PreOrder_BooksWithComparison()
        {
            List<Book> temp = new List<Book>();
            foreach (var item in BooksWithComparison.PreOrder())
                temp.Add(item);
            Assert.AreEqual(temp, BooksWithComparisonPreOrder);
        }

        [Test]
        public void InOrder_BooksWithComparison()
        {
            List<Book> temp = new List<Book>();
            foreach (var item in BooksWithComparison.InOrder())
                temp.Add(item);
            Assert.AreEqual(temp, BooksWithComparisonInOrder);
        }

        [Test]
        public void PostOrder_BooksWithComparison()
        {
            List<Book> temp = new List<Book>();
            foreach (var item in BooksWithComparison.PostOrder())
                temp.Add(item);
            Assert.AreEqual(temp, BooksWithComparisonPostOrder);
        }
        
        [Test]
        public void PreOrder_PointsWithComparison()
        {
            var temp = new List<Point>();
            foreach (var item in PointsWithComparison.PreOrder())
                temp.Add(item);
            Assert.AreEqual(temp, PointsWithComparisonPreOrder);
        }

        [Test]
        public void InOrder_PointsWithComparison()
        {
            var temp = new List<Point>();
            foreach (var item in PointsWithComparison.InOrder())
                temp.Add(item);
            Assert.AreEqual(temp, PointsWithComparisonInOrder);
        }

        [Test]
        public void PostOrder_PointsWithComparison()
        {
            var temp = new List<Point>();
            foreach (var item in PointsWithComparison.PostOrder())
                temp.Add(item);
            Assert.AreEqual(temp, PointsWithComparisonPostOrder);
        }


        [Test]
        public void PointConstructor_Points()
        {
            Assert.Throws<TypeInitializationException>(() => new BinarySearchTree<Point>(new List<Point> { Point1, Point2, Point3 }));
        }
        
        #endregion

    }
}
