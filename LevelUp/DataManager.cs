using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace LevelUp
{
    class DataManager
    {
        public List<Skill> data;

        public DataManager()
        {
            // if file exists, read it into data
            // else, create empty dictionary
            data = read_data();
        }


        public void add_data(string s, int h, List<Category> c)
        {
            try
            {
                for (int i = 0; i < data.Count; ++i)
                {
                    if (data[i].name.ToLower() == s.ToLower())
                    {
                        // TODO: CREATE POPUP WARNING DUPLICATE
                        return;
                    }
                }
                Skill new_skill = new Skill(s, DateTime.Now, h, c);
                data.Add(new_skill);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            write_data();


        }

        public void remove_data(Skill s)
        {
            try
            {
                data.Remove(s);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            write_data();
        }

        public void update_data(string s, int i)
        {
            try
            {
                data.Find(x => x.name == s).hours += i;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            write_data();
        }

        private void write_data()
        {
            string json = JsonConvert.SerializeObject(data);
            try
            {
                StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LevelUp");
                sw.WriteLine(json);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private List<Skill> read_data()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LevelUp");
                line = sr.ReadLine();
                sr.Close();
                return JsonConvert.DeserializeObject<List<Skill>>(line);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return new List<Skill>();
            }
        }

    }
}
