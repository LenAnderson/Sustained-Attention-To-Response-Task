using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SART
{
    public class LogEntry
    {
        public int Sequence { get; set; }
        public string Symbol { get; set; }
        public int PressedSpace { get; set; } = 0;
        public long Millis { get; set; }
    }
}
