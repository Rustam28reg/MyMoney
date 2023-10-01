using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_Work_C_
{
    static class MenuManager
    {
        public static void CreateDictionary(ref Dictionary<string, DictionaryManager> dictionaryes)
        {
            
            while (true)
            {
                string keyDict = SelectInterface();
                if (keyDict == "5") { Console.Clear(); break; }
                Console.Clear();

                if (dictionaryes.ContainsKey(keyDict))
                {
                    Console.WriteLine("An instance of the selected dictionary already exists\n\n");
                }
                else
                {
                    dictionaryes.Add(keyDict, new DictionaryManager());
                    Console.WriteLine("The dictionary has been created\n\n");
                }
            }
        }

        public static void DeleteDictionary(ref Dictionary<string, DictionaryManager> dictionaryes)
        {
            while (true)
            {
                string keyDict = SelectInterface();
                if (keyDict == "5") { Console.Clear(); break; }
                Console.Clear();

                if (!dictionaryes.ContainsKey(keyDict))
                {
                    throw new Exception("The dictionary does not exist.");
                }
                dictionaryes.Remove(keyDict);

            }
        }

        public static void DictionaryManager(ref Dictionary<string, DictionaryManager> dictionaryes)
        {
            Dictionary<string, string> patterns = new();
            patterns["RU"] = "^[А-Яа-я]+$";
            patterns["EN"] = "^[A-Za-z]+$";
            patterns["FR"] = "^[A-Za-zÀ-ÖØ-öø-ÿ]+$";

            while (true)
            {
                string keyDict = SelectInterface();
                if (keyDict == "5") { Console.Clear(); break; }
                Console.Clear();

                if (!dictionaryes.ContainsKey(keyDict))
                {
                    Console.Write("This dictionary has not been created.\n" +
                         "1. Create a dictionary.\n" +
                         "2. Go back.\n" +
                         "Enter selection - ");
                    string choice1 = Console.ReadLine();

                    if (!Regex.IsMatch(choice1.ToString(), "^[1-2]{1}$"))
                    {
                        throw new Exception("Input error in dictionary manager");
                    }

                    Console.Clear();

                    switch (choice1)
                    {
                        case "1":
                            dictionaryes.Add(keyDict, new DictionaryManager());
                            break;
                        case "2":
                            continue;
                        default:
                            break;
                    }
                }

                bool key1 = true;
                while (key1)
                {
                    Console.Write("1. Find translation.\n" +
                             "2. Add a new word and translation.\n" +
                             "3. Add translation.\n" +
                             "4. Delete translation.\n" +
                             "5. Change translation.\n" +
                             "6. Print the entire dictionary.\n" +
                             "7. Go back.\n" +
                             "Enter selection - ");
                    string choice2 = Console.ReadLine();

                    if (!Regex.IsMatch(choice2.ToString(), "^[1-7]{1}$"))
                    {
                        throw new Exception("Input error in dictionary manager");
                    }

                    Console.Clear();

                    switch (choice2)
                    {
                        case "1":                                                                        

                            while (true)
                            {
                                Console.Write("Enter 0 to exit.\n" + "Enter word - ");
                                string word = Console.ReadLine();

                                if (word == "0") { break; }
                                try
                                {
                                    if (!Regex.IsMatch(word, patterns[keyDict.Substring(0, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    List<string> words = dictionaryes[keyDict].GetTranslete(word);

                                    Console.Write($"{word} - ");
                                    for (int i = 0; i < words.Count; i++)
                                    {
                                        Console.WriteLine($"{words[i]} ");
                                    }

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Input error in case 1 (DictionaryManager) - " + e.Message);
                                    continue;
                                }
                                break;
                            }
                            Console.Clear();
                            break;

                        case "2":                                                                                 
                            while (true)
                            {
                                Console.Write("Enter 0 to exit.\n" + "Enter word - ");
                                string word2 = Console.ReadLine();
                                if (word2 == "0") { break; }
                                try
                                {
                                    if (!Regex.IsMatch(word2, patterns[keyDict.Substring(0, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }
                                    Console.Write("Enter translete - ");
                                    string translete2 = Console.ReadLine();
                                    if (!Regex.IsMatch(translete2, patterns[keyDict.Substring(3, 2)]))
                                    {
                                        throw new Exception("Incorrect input language");
                                    }
                                    dictionaryes[keyDict].Add(word2, translete2);

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Input error in case 2 (DictionaryManager) - " + e.Message);
                                    continue;
                                }
                                break;
                            }
                            Console.Clear();
                            break;

                        case "3":                                                                                 
                            while (true)
                            {
                                Console.Write("Enter 0 to exit.\n\n" + "Enter word - ");
                                string word3 = Console.ReadLine();
                                if (word3 == "0") { break; }
                                try
                                {
                                    if (!Regex.IsMatch(word3, patterns[keyDict.Substring(0, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    Console.Write("Enter translete - ");
                                    string translete3 = Console.ReadLine();

                                    if (!Regex.IsMatch(translete3, patterns[keyDict.Substring(3, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    dictionaryes[keyDict].AddTranslete(word3, translete3);

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Input error in case 3 (DictionaryManager) - " + e.Message);
                                    continue;
                                }
                                break;
                            }
                            Console.Clear();
                            break;

                        case "4":                                                                                 

                            while (true)
                            {
                                Console.Write("Enter 0 to exit.\n\n" + "Enter word - ");
                                string word4 = Console.ReadLine();

                                if (word4 == "0") { break; }
                                try
                                {
                                    if (!Regex.IsMatch(word4, patterns[keyDict.Substring(0, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    Console.Write("Enter translete - ");
                                    string translete4 = Console.ReadLine();
                                    if (!Regex.IsMatch(translete4.ToString(), patterns[keyDict.Substring(3, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    dictionaryes[keyDict].DeleteTranslete(word4, translete4);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Input error in case 4 (DictionaryManager) - " + e.Message);
                                    continue;
                                }
                                break;
                            }
                            Console.Clear();
                            break;
                        case "5":                                                                                                       

                            while (true)
                            {

                                Console.Write("Enter 0 to exit.\n\n" + "Enter word - ");
                                string word5 = Console.ReadLine();
                                if (word5 == "0") { break; }
                                try
                                {
                                    if (!Regex.IsMatch(word5, patterns[keyDict.Substring(0, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    Console.Write("Enter translete - ");
                                    string translete5 = Console.ReadLine();
                                    if (!Regex.IsMatch(translete5.ToString(), patterns[keyDict.Substring(3, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    Console.Write("Enter new translete - ");
                                    string newTranslete5 = Console.ReadLine();
                                    if (!Regex.IsMatch(newTranslete5.ToString(), patterns[keyDict.Substring(3, 2)]))
                                    {
                                        throw new Exception("Invalid input language.");
                                    }

                                    dictionaryes[keyDict].ChangeTranslete(word5, translete5, newTranslete5);

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Input error in case 5 (DictionaryManager) - " + e.Message);
                                    continue;
                                }
                                break;
                            }
                            Console.Clear();
                            break;

                        case "6":                                                                                         

                            Dictionary<string, List<string>> dictionary = dictionaryes[keyDict].GetDictionary();

                            foreach (var item in dictionary)
                            {
                                Console.Write($"{item.Key} - ");
                                for (int i = 0; i < item.Value.Count; i++)
                                {
                                    Console.Write($"{item.Value[i]} ");
                                }
                                Console.WriteLine("\n");
                            }
                            Console.WriteLine("\n");

                            break;
                        case "7":
                            key1 = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static string SelectInterface()
        {
            Console.Write("Select a dictionary to delete:\n" +
                                "1. Russian-English dictionary\n" +
                                "2. English-Russian\n" +
                                "3. Russian-French\n" +
                                "4. Franco-Russian\n" +
                                "5. Exit\n" +
                                "Enter choice - ");
            string choice = Console.ReadLine();

            if (!Regex.IsMatch(choice.ToString(), "^[1-5]{1}$"))
            {
                throw new Exception("Input error");
            }            
            string[] arrKey = new string[5] { "RU-EN", "EN-RU", "RU-FR", "FR-RU", "5" };
            string keyDict = arrKey[int.Parse(choice) - 1];

            return keyDict;
        }
    }
}
