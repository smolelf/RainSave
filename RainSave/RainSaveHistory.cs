using System;
using System.Collections.Generic;
using System.Text;

namespace RainSave
{
    class RainSaveHistory
    {
        public DateTime DateRecorded { get; set; }
        public double WaterCollect { get; set; }
        public double WaterTariff { get; set; }
        public double WaterSaved { get; set; }
        public string DateString { get; set; }
        public string CostSaved { get; set; }
        public int Dum { get; set; }
        public string WaterCollectString { get; set; }
        public string WaterSavedString { get; set; }
    }
}
