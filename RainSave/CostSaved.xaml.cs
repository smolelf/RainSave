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
    public partial class CostSaved : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public CostSaved()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var res = await firebaseHelper.CostSaved();
            display.Text = "So far, you saved RM";
            display.Text += res.WaterSaved.ToString("F");
            display.Text += " by recycling rain water instead of using freshwaters.";
        }
    }
}