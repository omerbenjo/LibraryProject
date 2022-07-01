using LibraryBook.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopProject
{
    public class LogicManager
    {
        public static Manager manager { get; set; }
        public LogicManager(Manager manager)
        {
            LogicManager.manager = manager;
        }
    }
}
