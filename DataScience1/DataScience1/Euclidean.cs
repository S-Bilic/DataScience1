using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience1
{
    public class Euclidean : InterfaceAlgorithm
    {
        //provide simm threshhold
        public void Use(Dictionary<string, List<string>> userItems, string targetUser, Dictionary<string, Dictionary<string, double>> context, double simmthreshold)
        {
            //Euclidean looks at each user and the calculates the difference between the same articles rate by the user and main user

            //Dictionary holding the distance for each user
            Dictionary<string, double> dict = new Dictionary<string, double>();
            var mainUser = context.SingleOrDefault(u => u.Key == targetUser);
            if (mainUser.Key != null)
            {
                foreach (var user in context)
                {
                    if (user.Key != targetUser)
                    {
                        double sumSquaredDist = 0;
                        foreach (var article in user.Value)
                        {
                            if (mainUser.Value.Keys.Contains(article.Key))
                            {
                                double mainUserRating = mainUser.Value.SingleOrDefault(v => v.Key == article.Key).Value;
                                sumSquaredDist += Math.Pow((mainUserRating - article.Value),2);
                            }
                        }
                        double similarity = (1 / (1 + Math.Sqrt(sumSquaredDist)));
                        //               Sim threshhold
                        if (similarity > simmthreshold)
                        {
                            dict.Add(user.Key, similarity);
                        }
                    }
                }
                var sortedDict = from user in dict orderby user.Value descending select user;
                foreach (var user in sortedDict)
                {
                    Console.WriteLine(" Neighbour " + user.Key + ": Sim = " + user.Value);
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Neighbour not found!");
                Console.ReadLine();
            }
        }
    }
}
