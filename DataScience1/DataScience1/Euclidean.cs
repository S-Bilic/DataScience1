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
        public void Use(string targetUser, Dictionary<string, Dictionary<string, double>> context, double simmthreshold)
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
                        //                                          Sim threshhold
                        if ((1 / (1 + Math.Sqrt(sumSquaredDist))) > simmthreshold)
                        {
                            dict.Add(user.Key, Math.Sqrt(sumSquaredDist));
                        }
                    }
                }
                var sortedDict = from user in dict orderby user.Value select user;
                foreach (var user in sortedDict)
                {
                    Console.WriteLine(user.Key + "   distance " + user.Value);
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("User not found!");
                Console.ReadLine();
            }
        }
    }
}
