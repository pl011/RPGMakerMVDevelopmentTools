using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMakerDatabaseToCsv
{
    public class Skills
    {
        public int id { get; set; }
        public int animationId { get; set; }
        public Damage damage { get; set; }
        public string description { get; set; }
        public Effect[] effects { get; set; }
        public int hitType { get; set; }
        public int iconIndex { get; set; }
        public string message1 { get; set; }
        public string message2 { get; set; }
        public int mpCost { get; set; }
        public string name { get; set; }
        public string note { get; set; }
        public int occasion { get; set; }
        public int repeats { get; set; }
        public int requiredWtypeId1 { get; set; }
        public int requiredWtypeId2 { get; set; }
        public int scope { get; set; }
        public int speed { get; set; }
        public int stypeId { get; set; }
        public int successRate { get; set; }
        public int tpCost { get; set; }
        public int tpGain { get; set; }
    }

    public class Damage
    {
        public bool critical { get; set; }
        public int elementId { get; set; }
        public string formula { get; set; }
        public int type { get; set; }
        public int variance { get; set; }
    }

    public class Effect
    {
        public int code { get; set; }
        public int dataId { get; set; }
        public float value1 { get; set; }
        public int value2 { get; set; }
    }
}




