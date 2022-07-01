using DataStructures;
using LibraryBook.API;
using LibraryBook.CategoriesClass;
using LibraryBook.ManagersClass;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraryBook.CategoriesClass.Book;
using static LibraryBook.CategoriesClass.Enums;
using static LibraryBook.CategoriesClass.Record;

namespace LibraryBook.Collection
{
    public class Manager
    {
        public LibraryBookContext Context;
        int[] Workerpins = { 11111, 11112 };
        int[] Customerpins = { 22222, 22221 };
        ItemManage itemManage;
        EmpAndCustManager empAndCustManager;
        //     List<AbstractItem> items;
        Inotify inotifyAble;
        private static SqlProviderServices instance;
        public Manager(Inotify inotifyable)
        {
            inotifyAble = inotifyable;
            itemManage = new ItemManage();
            empAndCustManager = new EmpAndCustManager();
            Context = new LibraryBookContext();
            instance = SqlProviderServices.Instance;
        }
        public bool AddItem(BookType bookType, string nameStr, string authorStr, double priceBeforeDiscount, DateTime publishDate,  int discountPercentage, bool[] vs)
        {
            Book book = new Book
            {
                AuthorName = authorStr,
                BookType = bookType,
                ItemName = nameStr,
                Discount = discountPercentage,
                ItemPrice = priceBeforeDiscount,
                PublicationDate = publishDate,
                PriceAfterDiscount = (priceBeforeDiscount * (100 - discountPercentage)) / 100
            };
            bool isSucceed = itemManage.AddItem(inotifyAble, Context, book, vs);
            return isSucceed;
        }
        public bool AddItem(RecordType recordrType, string nameStr, string authorStr, double priceBeforeDiscount, DateTime publishDate,  int discountPercentage, bool[] vs)
        {
            Record record = new Record
            {
                AuthorName = authorStr,
                RecordType = recordrType,
                ItemName = nameStr,
                Discount = discountPercentage,
                ItemPrice = priceBeforeDiscount,
                PublicationDate = publishDate,
                PriceAfterDiscount = (priceBeforeDiscount * (100 - discountPercentage)) / 100
            };
            bool isSucceed = itemManage.AddItem(inotifyAble, Context, record, vs);
            return isSucceed;
        }
        public List<AbstractItem> Filter(string authorName, double itemPrice, DateTime publicationDate, int discount, bool[] vs)
        {
            List<AbstractItem> items = new List<AbstractItem>();
            List<int> parameters = CreateIndexCategory(authorName, itemPrice, publicationDate, discount);
            bool check = true;
            foreach (var item in Context.AbstractItems.ToList())
            {
                check = CheckParamters(authorName, itemPrice, publicationDate, discount, parameters, check, item);
                if (vs[0])
                {
                    if (item.GetType() == typeof(Book) && check) items.Add(item);
                }
                if (vs[1])
                {
                    if (item.GetType() == typeof(Record) && check) items.Add(item);

                }
                else if (check) items.Add(item);


            }
            return items;
        }
        private static bool CheckParamters(string authorName, double itemPrice, DateTime publicationDate, int discount, List<int> parameters, bool check, AbstractItem item)
        {
            for (int i = 0; i < parameters.Count; i++)
            {
                if (parameters[i] == 0)
                {
                    if (item.Discount >= discount) check = true;
                    else
                    {
                        check = false;
                        break;
                    }
                }
                if (parameters[i] == 1)
                {
                    if (item.AuthorName == authorName) check = true;
                    else
                    {
                        check = false;
                        break;
                    }
                }
                if (parameters[i] == 2)
                {
                    if (item.PublicationDate > publicationDate) check = true;
                    else
                    {
                        check = false;
                        break;
                    }
                }
                if (parameters[i] == 3)
                {
                    if (item.ItemPrice > itemPrice) check = true;
                    else
                    {
                        check = false;
                        break;
                    }
                }
            }

            return check;
        }
        private List<int> CreateIndexCategory(string authorName, double itemPrice, DateTime publicationDate, int discount)
        {
            List<int> parameters = new List<int>();

            if (discount != 0) parameters.Add(0);
            if (authorName != null) parameters.Add(1);
            if (publicationDate < DateTime.Now.AddDays(1)) parameters.Add(2);
            if (itemPrice != 0) parameters.Add(3);
            return parameters;

        }
        public BookType CreateBookTypeList(bool[] itemCollection)
        {
            BookType bookType = new BookType();
            for (int i = 0; i < itemCollection.Length; i++)
            {
                if (itemCollection[i] == true) bookType |= (BookType)Math.Pow(2, (i + 1));
            }
            return bookType;
        }
        public RecordType CreateRecordTypeList(bool[] itemCollection)
        {
            RecordType recordType = new RecordType();
            for (int i = 0; i < itemCollection.Length; i++)
            {
                if (itemCollection[i] == true) recordType |= (RecordType)Math.Pow((i + 1), 2);
            }
            return recordType;
        }
        public int Login(string name, string password)
        {
            string employee = null;
            string customer = null;
            try { employee = Context.Employees.FirstOrDefault(e => e.Name == name).Password = password; }
            catch { }
            if (employee != null) return 1;

            try { customer = Context.Customers.FirstOrDefault(c => c.Name == name).Password = password; }
            catch { }
            if (customer != null) return 2;

            inotifyAble.IsErorr("Nickname or Password Are Unvalid");
            return 0;
        }
        public void SearchByName(string name)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Context.AbstractItems.ToList())
            {
                if (item.ItemName == name)
                {
                    sb.AppendLine(item.ToString());
                }
            }
            if (sb.Length > 0)
            {
                inotifyAble.IsShow(sb.ToString());
                return;
            }
            inotifyAble.IsErorr("we not found item with this name");

        }
        public string ShowItemDetails(AbstractItem item)
        {
            string message = "";
            if (item.GetType() == typeof(Book))
            {
                Book book = item as Book;
                message = $"ItemType: Book\nId:{book.Id}\nName: {book.ItemName}\nCreator Name: " +
                    $"{book.AuthorName}\nPrice Before Discount: {book.ItemPrice}\nDiscount Percentage: " +
                    $"{book.Discount}%\nPrice After Discount:{book.PriceAfterDiscount}\nPublished At: " +
                    $"{book.PublicationDate}\nGenres are:{book.BookType}";
            }
            else if (item.GetType() == typeof(Record))
            {
                Record record = item as Record;
                message = $"ItemType: Record\nId:{record.Id}\nName: {record.ItemName}\nCreator Name: {record.AuthorName}\nPrice Before Discount:" +
                    $" {record.ItemPrice}\nDiscount Percentage: {record.Discount}%\nPrice After Discount:{record.PriceAfterDiscount}\nPublished At: " +
                    $"{record.PublicationDate}\nCategories are:{record.RecordType}";
            }
            return message;
        }
        public void ShowReport(List<AbstractItem> items)
        {
            string fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Report.txt");
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    foreach (AbstractItem item in items)
                    {
                        sw.WriteLine($"{ShowItemDetails(item)}\n");
                    }
                }
                Process.Start("notepad.exe", fileName);
            }
            catch (NullReferenceException)
            {
                inotifyAble.IsErorr("cuurently the report are empty");
            }
            catch (Exception ex)
            {
                inotifyAble.IsErorr($"{ex}");
            }

        }
        public void BuyItem(int isbn)
        {
            try
            {
                if (Context.AbstractItems.First(x => x.Id == isbn) != null)
                {
                    Context.AbstractItems.Remove(Context.AbstractItems.First(x => x.Id == isbn));
                    inotifyAble.IsSucceed("the purchase succeed");
                }
            }
            catch
            {
                inotifyAble.IsErorr("unvalid isbn");
            }


        }
        public void AddPerson(string password, string name, bool[] isSelected) => empAndCustManager.AddPerson(inotifyAble, password, name, isSelected);
    }
}