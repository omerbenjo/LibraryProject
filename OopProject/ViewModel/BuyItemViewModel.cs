using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibraryBook;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopProject.ViewModel
{
    public class BuyItemViewModel : ViewModelBase
    {


        public RelayCommand BuyItemClickCommand { get; set; }
        public string CurrentItem { get; set; }
        private string iSBNstr;
        public string ISBNstr { get => iSBNstr; set => Set(ref iSBNstr, value); }
        public BuyItemViewModel() => BuyItemClickCommand = new RelayCommand(BuyItem);
        public void BuyItem()
        {
            int.TryParse(iSBNstr, out int ISBNint);
            LogicManager.manager.BuyItem(ISBNint);
            ISBNstr = "";
        }
    }
}
