﻿using System;
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


        public void add_data(string s, double h, List<Category> c)
        {
            try
            {
                for (int i = 0; i < data.Count; ++i)
                {
                    if (data[i].name.ToLower().Replace(" ", "") == s.ToLower().Replace(" ", ""))
                    {
                        // TODO: CREATE POPUP WARNING DUPLICATE
                        // TODO: HANDLE NUMBER INPUTS
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

        public void remove_data(string identifier)
        {
            try
            {
                Skill skillToRemove = data.Find(x => x.identifier == identifier);
                data.Remove(skillToRemove);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            write_data();
        }

        public void update_data(string s, double i)
        {
            try
            {
                data.Find(x => x.identifier == s).hours += i;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            write_data();
        }

        public void update_name(string newName, string identifier)
        {
            try
            {
                data.Find(x => x.identifier == identifier).name = newName;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            write_data();
        }

        public void fetch()
        {
           data = read_data();
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
                Console.WriteLine("No File found, or read-error occurred.");
                return new List<Skill>();
            }
        }

    }
}
