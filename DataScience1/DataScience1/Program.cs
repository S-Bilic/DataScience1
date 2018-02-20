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
            InterfaceAlgorithm newAlgorithm = null;
            DataSet data = new DataSet();

            while (true)
            {
                Console.WriteLine("Choose your Algorithm: (1 = Euclidean, 2 = Pearson, 3 = Cosine)");
                String input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        newAlgorithm = new Euclidean();
                        break;
                    case "2":
                        newAlgorithm = new Pearson();
                        break;
                    case "3":
                        newAlgorithm = new Cosine();
                        break;
                }

                data.setAlgorithm(newAlgorithm);
                data.Init();
            }

            //Dictionary<int, Dictionary<int, double>> dict = new Dictionary<int, Dictionary<int, double>>();
            //String fileName = "C:\\Users\\Stefan\\Documents\\Inf4\\DataScience1\\userItem.data";

            //using (var sr = new StreamReader(fileName))
            //{
            //    while (!sr.EndOfStream)
            //    {
            //        var line = sr.ReadLine();

            //        if (line != null)
            //        {
            //            //split each line
            //            var values = line.Split(',');

            //            //checks if a userID key exists, if not, the userID key is made.
            //            if (dict.Count(k => k.Key == int.Parse(values[0])) > 0)
            //            {
            //                var tempdict = dict.Single(d => d.Key == int.Parse(values[0])).Value;
            //                tempdict.Add(int.Parse(values[1]), double.Parse(values[2].Replace('.', ',')));

            //                dict[int.Parse(values[0])] = tempdict;
            //            }
            //            else
            //            {
            //                dict.Add(int.Parse(values[0]), new Dictionary<int, double>() { { int.Parse(values[1]), double.Parse(values[2].Replace('.', ',')) } });
            //            }
            //        }
            //    }
            //}

            //foreach (var user in dict)
            //{ 
            //    foreach (var art in user.Value)
            //    {
            //        Console.WriteLine("User:" + user.Key + "---Article:" + art.Key + "---Rating:" + art.Value);
            //        Console.ReadLine();
            //    }
            //}
        }

    }
}
