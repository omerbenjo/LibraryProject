using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook.API
{
    public interface Inotify
    {
        void IsErorr(string message);
        void IsSucceed(string message);
        void IsShow(string message);
        bool AskBuyer(string message);
    }
}
