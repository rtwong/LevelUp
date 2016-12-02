using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelUp
{
    public enum Category { STR, INT, CRT }

    class Skill
    {

        public string name { get; set; }
        public DateTime created { get; set; }
        public int hours { get; set; } = 0;
        public List<Category> category { get; set; }


        public Skill(string name, DateTime created, int hours, List<Category> category)
        {
            this.name = name;
            this.created = created;
            this.category = category;
        }
    }
}
