using LibraryBook.CategoriesClass;
using LibraryBook.Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OopProject;
using System;
using static LibraryBook.CategoriesClass.Enums;

namespace UnitTestProjectBook
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BookCreateTestMethod()
        {
            Book book = new Book { BookType = BookType.Comic, AuthorName = "omer", ItemName =  "benjo", ItemPrice =  100, PublicationDate =  new DateTime(2012, 10, 14), Discount = 10 };
            Assert.IsTrue(book is Book);
        }
        [TestMethod]
        public void RecordCreateTestMethod()
        {

            Record record = new Record { RecordType = RecordType.Funk, AuthorName = "plago", ItemName = "Maya", ItemPrice = 250, PublicationDate = new DateTime(2020, 12, 14), Discount = 15 };
            Assert.IsTrue(record is Record);
        }
        [TestMethod]
        public void AddItemTestMethod()
        {
            bool[] vs = new bool[7];
            vs[0] = true;
            ForInterface forInterFace = new ForInterface();
            Manager manager = new Manager(forInterFace);
            manager.AddItem(BookType.Comic,"stam","book",200, new DateTime(2020, 12, 14),15,vs);

        }
    }
}
