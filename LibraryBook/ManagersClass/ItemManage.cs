using DataStructures;
using LibraryBook.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBook
{
    internal class ItemManage
    {
        public bool AddItem(Inotify inotifyAble, LibraryBookContext Context, AbstractItem item, bool[] vs)
        {
            if (CheckFields(item, vs))
            {
                try
                {
                    Context.AbstractItems.Add(item);
                }
                catch
                {
                    inotifyAble.IsErorr("the item is also exisd");
                    return false;
                }
                inotifyAble.IsSucceed("the item add to the library");
                Context.SaveChanges();
                return true;
            }
            inotifyAble.IsErorr("please fill all thr fields \nAll of them must except the discount");
            return false;
        }
        private bool CheckFields(AbstractItem item, bool[] vs)
        {

            if (item.AuthorName == null || item.AuthorName == "" || item.ItemName == null || item.ItemName == "" || item.ItemPrice == 0 || item.Id == 0) return false;
            foreach (var item2 in vs)
            {
                if (item2 == true) return true;
            }
            return false;
        }
    }
}
