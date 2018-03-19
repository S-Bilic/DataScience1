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
            

            DataSet data = new DataSet();

            data.SetContext(ReadFileToDict());
            //The taget user specifies the user for witch all other users have to compare with
            data.SetTargetUser("7");
            data.SetThreshold(0.35);

            while (true)
            {
                Console.WriteLine("Choose your Algorithm: (1 = Euclidean, 2 = Pearson, 3 = Cosine, 4 = Slope One)");
                String input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        data.SetAlgorithm(new Euclidean());
                        break;
                    case "2":
                        data.SetAlgorithm(new Pearson());
                        break;
                    case "3":
                        data.SetAlgorithm(new Cosine());
                        break;
                    case "4":
                        data.SetAlgorithm(new SlopeOne());
                        break;
                }

                data.Init();
            }
        }

        private static Dictionary<string, Dictionary<string, double>> ReadFileToDict()
        {
            Dictionary<string, Dictionary<string, double>> dict = new Dictionary<string, Dictionary<string, double>>();
            String fileName = "C:\\Users\\Stefan\\Documents\\Inf4\\DataScience1\\userItem.data";

            using (var sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();

                    if (line != null)
                    {
                        //split each line
                        var values = line.Split(',');

                        //checks if a userID key exists, if not, the userID key is made.
                        if (dict.Count(k => k.Key == values[0]) > 0)
                        {
                            var tempdict = dict.Single(d => d.Key == values[0]).Value;
                            tempdict.Add(values[1], double.Parse(values[2].Replace('.', ',')));

                            dict[values[0]] = tempdict;
                        }
                        else
                        {
                            dict.Add(values[0], new Dictionary<string, double>() { { values[1], double.Parse(values[2].Replace('.', ',')) } });
                        }
                    }
                }
            }
            return dict;
        }

    }
}
