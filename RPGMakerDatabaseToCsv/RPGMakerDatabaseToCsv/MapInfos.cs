using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMakerDatabaseToCsv
{
    public class MapInfos
    {
        public int id { get; set; }
        public bool expanded { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public int parentId { get; set; }
        public float scrollX { get; set; }
        public float scrollY { get; set; }
    }

}
