using DataStructures;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibraryBook;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OopProject.ViewModel
{
    public class ReportViewModel : ViewModelBase
    {
        List<AbstractItem> items;
        public List<AbstractItem> AllItems { get; set; }
        public ObservableCollection<AbstractItem> FiltersItem { get; set; }
        #region prop & fields
        public AbstractItem CurrentItem { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        static public Action ItemSelected { get; set; }
        private string authorStr;
        public string AuthorStr { get => authorStr; set => Set(ref authorStr, value); }

        private string priceBeforeDiscountStr;
        public string PriceBeforeDiscountStr { get => priceBeforeDiscountStr; set => Set(ref priceBeforeDiscountStr, value); }

        private string discountPercentageStr;
        private bool[] isSelected = new bool[3];

        public string DiscountPercentageStr { get => discountPercentageStr; set => Set(ref discountPercentageStr, value); }
        public bool[] IsSelected { get => isSelected; set => Set(ref isSelected, value); } 
        #endregion
        public RelayCommand ShowItemClickCommand { get; set; }
        public RelayCommand ShowReportClickCommand { get; set; }
        public ReportViewModel()
        {
            ShowItemClickCommand = new RelayCommand(DisplayByItem);
            ShowReportClickCommand = new RelayCommand(ShowReport);
            AllItems = LogicManager.manager.Context.AbstractItems.ToList();
            ItemSelected = new Action(ListView_SelectionChanged);
            FiltersItem = new ObservableCollection<AbstractItem>();
        }
        public void DisplayByItem()
        {
            StringCasting(priceBeforeDiscountStr, discountPercentageStr, out int priceBeforeDiscountInt, out int discountPercentageInt);
            items = (LogicManager.manager.Filter(authorStr, priceBeforeDiscountInt, PublishDate, discountPercentageInt, IsSelected));

            foreach (var item in items) FiltersItem.Add(item);
        }
        private void StringCasting(string priceBeforeDiscountStr, string discountPercentageStr, out int priceBeforeDiscountInt, out int discountPercentageInt)
        {
            int.TryParse(priceBeforeDiscountStr, out priceBeforeDiscountInt);
            int.TryParse(discountPercentageStr, out discountPercentageInt);
        }
        void ListView_SelectionChanged()
        {
            using (LibraryBookContext data = new LibraryBookContext())
            {
                AbstractItem item = data.AbstractItems.First(x => x.Id == CurrentItem.Id);
                string message = $"Id: {item.Id}\nName: {item.ItemName}\nCreator Name: {item.AuthorName}\nPrice Before Discount:" +
                    $" {item.ItemPrice}\nDiscount Percentage: {item.Discount}%\nPrice After Discount:{item.PriceAfterDiscount}" +
                    $" Published At: {item.PublicationDate}";
                MessageBox.Show(message, "Item Details");
            }
        }
        void ShowReport() => LogicManager.manager.ShowReport(items);
    }
}
