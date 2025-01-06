using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMakerDatabaseToCsv
{
    public class Classes
    {
        public int id { get; set; }
        public int[] expParams { get; set; }
        public Trait[] traits { get; set; }
        public Learning[] learnings { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public int[][] _params { get; set; }
    }

    public class Trait
    {
        public int code { get; set; }
        public int dataId { get; set; }
        public float value { get; set; }
    }

    public class Learning
    {
        public int level { get; set; }
        public string note { get; set; }
        public int skillId { get; set; }
    }

}
