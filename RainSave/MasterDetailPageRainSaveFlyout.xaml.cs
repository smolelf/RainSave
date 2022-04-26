using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RainSave
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageRainSaveFlyout : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageRainSaveFlyout()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageRainSaveFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageRainSaveFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageRainSaveFlyoutMenuItem> MenuItems { get; set; }

            public MasterDetailPageRainSaveFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageRainSaveFlyoutMenuItem>(new[]
                {
                    new MasterDetailPageRainSaveFlyoutMenuItem { Id = 0, Title = "Home (Collection Form)", TargetType=typeof(MainPage) },
                    new MasterDetailPageRainSaveFlyoutMenuItem { Id = 1, Title = "History", TargetType=typeof(History)},
                    new MasterDetailPageRainSaveFlyoutMenuItem { Id = 2, Title = "Monthly History", TargetType=typeof(MonthlyHistory) },
                    new MasterDetailPageRainSaveFlyoutMenuItem { Id = 2, Title = "Cost Saved", TargetType=typeof(CostSaved) },
                    new MasterDetailPageRainSaveFlyoutMenuItem { Id = 2, Title = "About", TargetType=typeof(About)},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}