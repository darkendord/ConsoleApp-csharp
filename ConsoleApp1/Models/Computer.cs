using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
        public string Motherboard { get; set; }
        public int? CPUCores { get; set; }
        public bool? HasWifi { get; set; }
        public bool? HasLTE { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? Price { get; set; }
        public string? VideoCard { get; set; }
    public Computer()
    {
            if (Motherboard == null){Motherboard = "";}
            if (VideoCard == null) { VideoCard = ""; }
            if (CPUCores == null) { CPUCores = 0; }
            if (ReleaseDate == null) { ReleaseDate = DateTime.Now; }
        }
    }

}
