using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibraryBook.API;
using LibraryBook.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopProject.ViewModel
{
    public class WorkerViewModel : ViewModelBase
    {
        
        private string itemName;
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public RelayCommand CheckNameClick { get; set; }
        public WorkerViewModel(Inotify inotify)
        {
            CheckNameClick = new RelayCommand(SearchByNameClick);
        }
        private void SearchByNameClick() => LogicManager.manager.SearchByName(itemName);

    }
}
