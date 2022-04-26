using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RainSave
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public History()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            displayRecord.ItemsSource = await firebaseHelper.GetAllRainSaveHistory();
        }

    }
}