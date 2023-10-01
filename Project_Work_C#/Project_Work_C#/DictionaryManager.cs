using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_C_
{
    internal class DictionaryManager
    {
        private Dictionary<string, List<string>> MyDictionary;
        public DictionaryManager() { MyDictionary = new(); }
        public DictionaryManager(Dictionary<string, List<string>> dictionary)
        {
            MyDictionary = dictionary;
        }
        public void Add(string key, string value)
        {
            List<string> list = new List<string>() { value };

            MyDictionary.Add(key, list);
        }
        public void AddTranslete(string key, string value)
        {
            if (MyDictionary[key].Count == 10)
            {
                throw new InvalidOperationException("The value cannot be added, the maximum number of translation options has been reached.");
            }
            else
            {
                MyDictionary[key].Add(value);
            }
        }
        public void DeleteTranslete(string key, string value)
        {
            if (MyDictionary[key].Count == 1)
            {
                throw new Exception("The value cannot be deleted.");
            }
            else
            {
                foreach (var item in MyDictionary[key])
                {
                    if (item.Equals(value))
                    {
                        MyDictionary[key].Remove(item);
                    }
                }
            }
        }
        public void ChangeTranslete(string key, string word, string newWord)
        {
            foreach (var item in MyDictionary[key])
            {
                if (item.Equals(word))
                {
                    MyDictionary[key].Replace(word, newWord);
                }
                else
                {
                    throw new Exception("This translation is not in the dictionary.");
                }
            }
        }
        public List<string> GetTranslete(string key)
        {
            if (!MyDictionary.ContainsKey(key))
            {
                throw new Exception("There's no such word in the dictionary.");
            }
            return MyDictionary[key];
        }

        public Dictionary<string, List<string>> GetDictionary()
        {
            return MyDictionary;
        }

    }
}
