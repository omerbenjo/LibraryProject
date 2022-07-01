using DataStructures;
using LibraryBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OopProject.ViewModel
{
    public class CustomerShowItemViewModel
    {
        public List<AbstractItem> AllItems { get; set; }
        public AbstractItem CurrentItem { get; set; }
        static public Action ItemSelected { get; set; }
        public CustomerShowItemViewModel()
        {
            ItemSelected = new Action(ListView_SelectionChanged);
            AllItems = LogicManager.manager.Context.AbstractItems.ToList();
        }
        void ListView_SelectionChanged()
        {
            using (LibraryBookContext data = new LibraryBookContext())
            {
                AbstractItem item = data.AbstractItems.First(x => x.Id == CurrentItem.Id);
                string message = $"Id: {item.Id}\nName: {item.ItemName}\nCreator Name: {item.AuthorName}\nPrice Before Discount: {item.ItemPrice}\nDiscount Percentage: {item.Discount}%\nPrice After Discount:{item.PriceAfterDiscount} Published At: {item.PublicationDate}";
                MessageBox.Show(message, "Item Details");
            }
        }
    }
}
