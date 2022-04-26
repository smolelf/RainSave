using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace RainSave
{
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://rainsave-d379a-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public async Task AddRecord(DateTime dt, double wc, double wt, double ws, int dm)
        {
            await firebase
                .Child("RainSaveHistory")
                .PostAsync(new RainSaveHistory() { DateRecorded = dt, WaterCollect = wc, WaterTariff = wt, WaterSaved = ws, Dum = dm});
        }
        public async Task<List<RainSaveHistory>> GetAllRainSaveHistory()
        {
            return (await firebase
                .Child("RainSaveHistory")
                .OnceAsync<RainSaveHistory>()).Select(item => new RainSaveHistory
                {
                    DateRecorded = item.Object.DateRecorded,
                    DateString = item.Object.DateRecorded.ToString("dd/MM/yyyy"),
                    WaterCollect = item.Object.WaterCollect,
                    WaterTariff = item.Object.WaterTariff,
                    WaterSaved = item.Object.WaterSaved,
                    WaterSavedString = item.Object.WaterSaved.ToString("F")
                })
                .OrderByDescending(x => x.DateRecorded)
                .ToList();
        }
        public async Task<List<RainSaveHistory>> GetMonthlyRainSaveHistory()
        {
            var allHistory = await GetAllRainSaveHistory();

            return allHistory.GroupBy(x => new { x.DateRecorded.Month, x.DateRecorded.Year })
               .Select(x => new RainSaveHistory()
               {
                   DateString = string.Format("{0}/{1}", x.Key.Month, x.Key.Year),
                   WaterCollect = x.Sum(i => i.WaterCollect),
                   WaterSavedString = x.Sum(i => i.WaterSaved).ToString("F"),
               })
               .OrderByDescending(x => x.DateRecorded)
               .ToList();
        }
        public async Task<RainSaveHistory> CostSaved()
        {
            var allHistory = await GetAllRainSaveHistory();

            var q = allHistory.GroupBy(x => x.Dum)
                .Select(x => new RainSaveHistory()
                {
                    Dum = x.Key,
                    WaterSaved = x.Sum(i => i.WaterSaved),
                })
                .FirstOrDefault();

            Console.WriteLine(q.WaterSaved);

            return q;
        }
    }
}
