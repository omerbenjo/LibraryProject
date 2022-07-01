using LibraryBook.API;
using LibraryBook.EmpCust;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook.ManagersClass
{
    internal class EmpAndCustManager
    {
        LibraryBookContext libraryBookContext; 
        public EmpAndCustManager()
        {
            libraryBookContext = new LibraryBookContext();
        }
        public void AddPerson(Inotify inotify, string password, string name, bool[] isSelected)
        {
            if (password == null || name == null)
            {
                inotify.IsErorr("Please Insert All The Field");
                return;
            }

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == ' ')
                {
                    inotify.IsErorr($" {password} \n Cannot Include Space ");
                    return;
                }
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                {
                    inotify.IsErorr($" {name} \n Cannot Include Space ");
                    return;
                }
            }
            if (isSelected[0]) libraryBookContext.Employees.Add(new Employee { Name = name, Password = password });
            else if (isSelected[1]) libraryBookContext.Customers.Add(new Customer { Name = name, Password = password });
            else inotify.IsErorr($"Please Choose Customer Or Employee");
            libraryBookContext.SaveChanges();
        }
    }
}
