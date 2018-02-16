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
            
            Dictionary<int, Dictionary<int, double>> dict = new Dictionary<int, Dictionary<int, double>>();
            String fileName = "C:\\Users\\Stefan\\Documents\\Inf4\\DataScience1\\userItem.data";

            using (var sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();

                    if (line != null)
                    {
                        var values = line.Split(',');

                        if (dict.Count(k => k.Key == int.Parse(values[0])) > 0)
                        {
                            var tempdict = dict.Single(d => d.Key == int.Parse(values[0])).Value;
                            tempdict.Add(int.Parse(values[1]), double.Parse(values[2].Replace('.', ',')));

                            dict[int.Parse(values[0])] = tempdict;
                        }
                        else
                        {
                            dict.Add(int.Parse(values[0]), new Dictionary<int, double>() { { int.Parse(values[1]), double.Parse(values[2].Replace('.', ',')) } });
                        }
                    }
                }
            }

            foreach (var user in dict)
            {
                foreach (var art in user.Value)
                {
                    Console.WriteLine("User:" + user.Key + "---Article:" + art.Key + "---Rating" + art.Value);
                    Console.ReadLine();
                }
            }
        }
    }
}
