using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharingPicsEFCore.Data
{
    public class Picture
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public DateTime DateUploaded { get; set; }
        public int Likes { get; set; }
    }
}
