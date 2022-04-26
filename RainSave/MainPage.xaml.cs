using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RainSave
{
    public partial class MainPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }
        async void OnSaveRecord(object sender, EventArgs e)
        {
            var selectdate = selectDate.Date;
            var liter = Double.Parse(inputLiter.Text);
            var tariff = Double.Parse(inputTariff.Text);
            var saved = Math.Round(((liter / 1000)*tariff),2);
            var dum = 1;
            await firebaseHelper.AddRecord(selectdate, liter, tariff, saved, dum);

            inputLiter.Text = null;
            inputTariff.Text = null;

            await DisplayAlert("Record saved!", "Water Collected has been saved", "Nice");
        }
        void OnReset(object sender, EventArgs e)
        {
            inputLiter.Text = null;
            inputTariff.Text = null;
            selectDate.Date = DateTime.Now;
        }
        void onDatePickerSelected(object sender, DateChangedEventArgs e)
        {
            var selectedDate = e.NewDate.ToString();
        }

    }
}
