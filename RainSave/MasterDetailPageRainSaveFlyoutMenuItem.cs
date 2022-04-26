using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainSave
{
    public class MasterDetailPageRainSaveFlyoutMenuItem
    {
        public MasterDetailPageRainSaveFlyoutMenuItem()
        {
            TargetType = typeof(MasterDetailPageRainSaveFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}