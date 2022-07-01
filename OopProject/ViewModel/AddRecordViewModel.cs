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
using static LibraryBook.CategoriesClass.Record;

namespace OopProject.ViewModel
{
    public class AddRecordViewModel : ViewModelBase
    {
        #region prop & fiels
        bool isAdd = false;
        private string recordIdStr;
        public string RecordIdStr { get => recordIdStr; set => Set(ref recordIdStr, value); }

        private string nameStr;
        public string NameStr { get => nameStr; set => Set(ref nameStr, value); }

        private string authorStr;
        public string AuthorStr { get => authorStr; set => Set(ref authorStr, value); }

        private string bandSingerNameStr;
        public string BandSingerNameStr { get => bandSingerNameStr; set => Set(ref bandSingerNameStr, value); }

        private string priceBeforeDiscountStr;
        public string PriceBeforeDiscountStr { get => priceBeforeDiscountStr; set => Set(ref priceBeforeDiscountStr, value); }

        private string discountPercentageStr;
        public string DiscountPercentageStr { get => discountPercentageStr; set => Set(ref discountPercentageStr, value); }
        public DateTime PublishDate { get; set; } = DateTime.Now;

        private bool[] categoriesCollection = new bool[7];
        public bool[] CategoriesCollection
        {
            get { return categoriesCollection; }
            set { categoriesCollection = value; }
        }
        #endregion
        public RelayCommand AddRecordClickCommand { get; set; }
        public AddRecordViewModel()
        {
            AddRecordClickCommand = new RelayCommand(AddRecordClick);
        }
        private void AddRecordClick() => AddRecordClick(recordIdStr, nameStr, authorStr, priceBeforeDiscountStr, PublishDate, discountPercentageStr, CategoriesCollection);
        public void AddRecordClick(string isbnStr, string nameStr, string authorStr, string priceBeforeDiscountStr, DateTime publishDate, string discountPercentageStr, bool[] vs)
        {

            RecordType recordType;
            recordType = LogicManager.manager.CreateRecordTypeList(vs);
            ParseString(isbnStr, priceBeforeDiscountStr, discountPercentageStr, out int isbn, out double priceBeforeDiscount, out int discountPercentage);
            isAdd = LogicManager.manager.AddItem(recordType, nameStr, authorStr, priceBeforeDiscount, publishDate, discountPercentage,vs);
            if (isAdd)
            {
                RecordIdStr = default;
                NameStr = default;
                AuthorStr = default;
                PriceBeforeDiscountStr = default;
                DiscountPercentageStr = default;
                PublishDate = DateTime.Now;
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
