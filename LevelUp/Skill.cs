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
        public double hours { get; set; }
        public List<Category> category { get; set; }
        public string identifier;


        public Skill(string name, DateTime created, double hours, List<Category> category)
        {
            this.name = name;
            this.created = created;
            this.category = category;
            this.hours = hours;
            this.identifier = "_" + System.Guid.NewGuid().ToString().Replace("-","");
        }
    }
}
