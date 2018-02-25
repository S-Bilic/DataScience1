using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience1
{
    class Pearson : InterfaceAlgorithm
    {
        public void Use(string targetUser, Dictionary<string, Dictionary<string, double>> context, double simmthreshold)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            var mainUser = context.SingleOrDefault(u => u.Key == targetUser);
            if (mainUser.Key != null)
            {
                foreach (var user in context)
                {
                    if (user.Key != targetUser)
                    {
                        double pearsonX = 0;
                        double pearsonY = 0;
                        double pearsonX2 = 0;
                        double pearsonY2 = 0;
                        double pearsonXY = 0;
                        double pearson = 0;
                        foreach (var article in user.Value)
                        {
                            if (mainUser.Value.Keys.Contains(article.Key))
                            {
                                double mainUserRating = mainUser.Value.SingleOrDefault(v => v.Key == article.Key).Value;
                                pearsonXY += (mainUserRating * article.Value);
                                pearsonX += (mainUserRating);
                                pearsonY += (article.Value);
                                pearsonX2 += Math.Pow((mainUserRating),2);
                                pearsonY2 += Math.Pow((article.Value), 2);

                                pearson = (pearsonXY - ((pearsonX * pearsonY) / mainUser.Key.Count())) / (Math.Sqrt(pearsonX2 - (Math.Pow((pearsonX),2) / mainUser.Key.Count())) * (pearsonY2 - (Math.Pow((pearsonY), 2) / mainUser.Key.Count())));
                                Console.WriteLine(mainUser.Key.Count());
                                //Console.WriteLine("User 7 =" + mainUserRating + " all users =" + article.Value + " " + cosineSimDenumerator1 + " " + Math.Sqrt(cosineSimDenumerator1) + " " + cosineSimDenumerator2 + " " + Math.Sqrt(cosineSimDenumerator2) + " " + cosineSimDenumeratorTotal);

                            }
                        }
                        
                        if (pearson > simmthreshold)
                        {
                            dict.Add(user.Key, pearson);
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
