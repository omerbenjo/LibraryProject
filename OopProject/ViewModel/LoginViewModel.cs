using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LibraryBook.API;
using LibraryBook.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OopProject.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string nickname;
        public string NicknameStr { get => nickname; set => Set(ref nickname, value); }

        private string password;
        public string PasswordStr { get => password; set => Set(ref password, value); }
        public RelayCommand LoginClickCommand { get; set; }
        public LoginViewModel(Inotify inotify)
        {
            LogicManager.manager = new Manager(inotify);
            LoginClickCommand = new RelayCommand(LoginValidation);
        }
        private void LoginValidation()
        {
            int num;
            num = LogicManager.manager.Login(NicknameStr, PasswordStr);
            if (num == 1)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                App.Current.MainWindow.Close();
            }
            else if (num == 2)
            {
                CustomerWindow customerWindow = new CustomerWindow();
                customerWindow.Show();
                App.Current.MainWindow.Close();
            }
            else
            {
                PasswordStr = " ";
                NicknameStr = " ";
            }
        }


    }
}
