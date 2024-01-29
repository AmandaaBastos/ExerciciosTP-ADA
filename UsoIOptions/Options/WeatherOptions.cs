using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOptions.Options
{
    public class WeatherOptions
    {
        public bool UseFixedValue { get; set; }
        public string? FixedDate { get; set; }
        public int Temperature { get; set; }
    }
}
