using LibraryBook.CategoriesClass;
using LibraryBook.EmpCust;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    public class LibraryBookContext:DbContext
    {
        public DbSet<AbstractItem> AbstractItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public LibraryBookContext():base("name=LibraryProject")
        {
                
        }

    }
}
