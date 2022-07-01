using LibraryBook.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace OopProject
{
    public class ForInterface : Inotify
    {
        public bool AskBuyer(string question)
        {
            DialogResult dialogResult = (DialogResult)System.Windows.MessageBox.Show(question, "Thank You!");
            if (dialogResult == DialogResult.Yes) return true;
            return false;
        }

        public void IsErorr(string message) => System.Windows.MessageBox.Show(message);


        public void IsShow(string message) => System.Windows.MessageBox.Show(message);

        public void IsSucceed(string message) => System.Windows.MessageBox.Show(message);
    }
}