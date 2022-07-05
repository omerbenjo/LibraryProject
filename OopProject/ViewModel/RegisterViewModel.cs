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
        private bool[] isSelected = new bool[2];

        public string NicknameStr { get => nicknameStr; set => Set(ref nicknameStr, value); }
        public bool[] IsSelected { get => isSelected; set => Set(ref isSelected , value); }

        public RelayCommand JoinClickCommand { get; set; }
        public RegisterViewModel() => JoinClickCommand = new RelayCommand(JoinClick);

        private async void JoinClick()
        {
            var n = NicknameStr;
            var p = PasswordStr;
            var s = IsSelected;
            Reset();

            await LogicManager.manager.AddPersonAsync(p, n, s);
        }

        private void Reset()
        {
            NicknameStr = "";
            PasswordStr = "";
            IsSelected = new bool[2];
        }
    }
}
