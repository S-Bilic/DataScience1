using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataScience1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, string> dict = new Dictionary<string, string>();
            String fileName = "C:\\Users\\Stefan\\Documents\\Inf4\\DataScience1\\userItem.data";

            using (var sr = new StreamReader(fileName))
            {
                string line = null;

                // while it reads a key
                while ((line = sr.ReadLine()) != null)
                {
                    // add the key and whatever it 
                    // can read next as the value
                    dict.Add(line, sr.ReadLine());              

                    // Get List of keys. [2]
                    List<string> keyList = new List<string>(dict.Keys);
                    // Display them.
                    foreach (var value in keyList)
                    {
                        Console.WriteLine(value.Split(','));
                    }

                    // Get List of values. [3]
                    List<string> valueList = new List<string>(dict.Values);
                    // Display them.
                    foreach (var value in valueList)
                    {
                        Console.WriteLine(value);
                    }

                    Console.ReadLine();
                    //List<KeyValuePair<string, string>> list = dict.ToList();
                    //// Loop over list.
                    //foreach (KeyValuePair<string, string> pair in list)
                    //{
                    //    Console.WriteLine(pair.Value.Split(','));

                    //}
                }
            }
        }
    }
}
