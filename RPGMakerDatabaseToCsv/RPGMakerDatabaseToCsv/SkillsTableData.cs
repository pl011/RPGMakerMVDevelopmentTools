using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMakerDatabaseToCsv
{
    public class SkillsTableData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<string> ClassesThatLearnThisSkill { get; set; } = new List<string>();
    }
}
