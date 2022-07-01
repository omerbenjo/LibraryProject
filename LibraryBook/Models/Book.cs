using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook.CategoriesClass
{
    public class Book : AbstractItem
    {
        public Enums.BookType BookType { get; set; }
    }
}
