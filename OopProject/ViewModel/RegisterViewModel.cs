using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace OopProject.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        ForInterface forInterface;
        private string passwordStr;
        public string PasswordStr { get => passwordStr; set => Set(ref passwordStr, value); }

        private string nicknameStr;
        public string NicknameStr { get => nicknameStr; set => Set(ref nicknameStr, value); }
        public bool[] IsSelected { get; set; } = new bool[2];

        public RelayCommand JoinClickCommand { get; set; }
        public RegisterViewModel() => JoinClickCommand = new RelayCommand(JoinClick);

        private  void JoinClick()
        {
            LogicManager.manager.AddPerson(PasswordStr, NicknameStr, IsSelected);
            NicknameStr = "";
            PasswordStr = "";
        }
    }
}
