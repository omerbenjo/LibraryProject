using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    public abstract class AbstractItem
    {
        public  int Id { get; set; }
        public  string ItemName { get; set; }
        public  string AuthorName { get; set; }
        public  double ItemPrice { get; set; }
        public  DateTime PublicationDate { get; set; }
        public  int Discount { get; set; }
        public  double PriceAfterDiscount { get; set; }
        //public AbstractItem(string itemName, string authorName, double itemPrice, DateTime publicationDate, int id, int discount)
        //{
        //    ItemName = itemName;
        //    AuthorName = authorName;
        //    ItemPrice = itemPrice;
        //    PublicationDate = publicationDate;
        //    Id = id;
        //    Discount = discount;
        //    PriceAfterDiscount = itemPrice * (100 - discount) / 100;

        //}
    }
}
