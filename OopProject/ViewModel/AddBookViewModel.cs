using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibraryBook.CategoriesClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static LibraryBook.CategoriesClass.Book;
using static LibraryBook.CategoriesClass.Enums;

namespace OopProject.ViewModel
{
    public class AddBookViewModel : ViewModelBase
    {
        #region prop & fields
        bool isAdd = false;
        private string isbnStr;
        public string IsbnStr { get => isbnStr; set => Set(ref isbnStr, value); }

        private string nameStr;
        public string NameStr { get => nameStr; set => Set(ref nameStr, value); }

        private string authorStr;
        public string AuthorStr { get => authorStr; set => Set(ref authorStr, value); }

        private string priceBeforeDiscountStr;
        public string PriceBeforeDiscountStr { get => priceBeforeDiscountStr; set => Set(ref priceBeforeDiscountStr, value); }

        private string discountPercentageStr;
        public string DiscountPercentageStr { get => discountPercentageStr; set => Set(ref discountPercentageStr, value); }

        public DateTime PublishDate { get; set; } = DateTime.Now;
        private bool[] categoriesCollection = new bool[8];
        public bool[] CategoriesCollection
        {
            get { return categoriesCollection; }
            set { categoriesCollection = value; }
        }
        #endregion
        public RelayCommand AddBookClickCommand { get; set; }
        public AddBookViewModel()
        {
            AddBookClickCommand = new RelayCommand(AddBookClick);
        }
        private void AddBookClick() => AddBook(isbnStr, nameStr, authorStr, priceBeforeDiscountStr, discountPercentageStr, PublishDate, CategoriesCollection);
        public void AddBook(string isbnStr, string nameStr, string authorStr, string priceBeforeDiscountStr, string discountPercentageStr, DateTime publishDate, bool[] vs)
        {

            BookType bookType;
            bookType = LogicManager.manager.CreateBookTypeList(vs);
            ParseString(isbnStr, priceBeforeDiscountStr, discountPercentageStr, out int isbn, out double priceBeforeDiscount, out int discountPercentage);
            isAdd = LogicManager.manager.AddItem(bookType, nameStr, authorStr, priceBeforeDiscount, publishDate, discountPercentage, vs);
            if (isAdd)
            {
                IsbnStr = default;
                NameStr = default;
                AuthorStr = default;
                PriceBeforeDiscountStr = default;
                DiscountPercentageStr = default;
                PublishDate = DateTime.Now;
                for (int i = 0; i < CategoriesCollection.Length; i++)
                {
                    CategoriesCollection[i] = false;
                }
            }
            return;

        }

        private void ParseString(string isbnStr, string priceBeforeDiscountStr, string discountPercentageStr, out int isbnInt, out double priceBeforeDiscountInt, out int discountPercentageInt)
        {
            int.TryParse(isbnStr, out isbnInt);
            double.TryParse(priceBeforeDiscountStr, out priceBeforeDiscountInt);
            int.TryParse(discountPercentageStr, out discountPercentageInt);
        }
    }
}
