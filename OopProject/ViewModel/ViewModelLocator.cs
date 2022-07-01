/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:OopProject"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System.Collections.ObjectModel;
using LibraryBook;
using LibraryBook.Collection;
using GalaSoft.MvvmLight.Messaging;
using LibraryBook.API;

namespace OopProject.ViewModel
{

    public class ViewModelLocator
    {

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<WorkerViewModel>();
            SimpleIoc.Default.Register< Inotify>(()=> new ForInterface());
            SimpleIoc.Default.Register< Manager>();
            SimpleIoc.Default.Register<LogicManager>();
            SimpleIoc.Default.Register<AddBookViewModel>();
            SimpleIoc.Default.Register<AddRecordViewModel>();
            SimpleIoc.Default.Register<ReportViewModel>();
            SimpleIoc.Default.Register<BuyItemViewModel>();
            SimpleIoc.Default.Register<CustomerShowItemViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
        }

        public  LoginViewModel Login => ServiceLocator.Current.GetInstance<LoginViewModel>();
        public WorkerViewModel Worker => ServiceLocator.Current.GetInstance<WorkerViewModel>();
        public AddRecordViewModel AddRecord => ServiceLocator.Current.GetInstance<AddRecordViewModel>();
        public AddBookViewModel AddBook => ServiceLocator.Current.GetInstance<AddBookViewModel>();
        public ReportViewModel Report => ServiceLocator.Current.GetInstance<ReportViewModel>();
        public BuyItemViewModel BuyItem => ServiceLocator.Current.GetInstance<BuyItemViewModel>();
        public CustomerShowItemViewModel CustomerShowItem => ServiceLocator.Current.GetInstance<CustomerShowItemViewModel>();
        public RegisterViewModel Register => ServiceLocator.Current.GetInstance<RegisterViewModel>();
        public static void Cleanup()
        {
            
        }
    }
}