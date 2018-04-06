using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience1
{
    class Pearson : InterfaceAlgorithm
    {
        public void Use(Dictionary<string, List<string>> userItems, string targetUser, Dictionary<string, Dictionary<string, double>> context, double simmthreshold)
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
                        int appearance = 0;
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
                                appearance++;

                                
                                //Console.WriteLine("User 7 =" + mainUserRating + " all users =" + article.Value + " " + cosineSimDenumerator1 + " " + Math.Sqrt(cosineSimDenumerator1) + " " + cosineSimDenumerator2 + " " + Math.Sqrt(cosineSimDenumerator2) + " " + cosineSimDenumeratorTotal);

                            }
                        }
                        double upperPart = pearsonXY - (pearsonX * pearsonY / appearance);
                        double lowerX = pearsonX2 - (Math.Pow(pearsonX, 2) / appearance);
                        double lowerY = pearsonY2 - (Math.Pow(pearsonY, 2) / appearance);
                        pearson = upperPart / (Math.Sqrt(lowerX * lowerY));

                        if (pearson > simmthreshold)
                        {
                            var tempDict = from item in dict orderby item.Value descending select item;

                            if (dict.Count == 3 && tempDict.Last().Value < pearson)
                            {
                                dict.Remove(tempDict.Last().Key);
                            }

                            if (dict.Count< 3)
                            {
                                dict.Add(user.Key, pearson);
                            }
                        }
                    }
                }
                var sortedDict = from user in dict orderby user.Value descending select user;
                foreach (var user in sortedDict)
                {
                    Console.WriteLine(" Neighbour " + user.Key + ": Sim = " + user.Value);
                }

                List<string> movieList = new List<string>() { "101", "103", "106" };

                CalculateRating(context, dict, movieList);

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Neighbour not found!");
                Console.ReadLine();
            }
        }

        private void CalculateRating(Dictionary<string, Dictionary<string, double>> context, Dictionary<string, double> dict, List<string> movies)
        {
            foreach (var movie in movies)
            {
                double sumPearsonCof = 0;
                double sumRatings = 0;
                foreach (var neighbor in dict)
                {
                    var user = context.SingleOrDefault(u => u.Key == neighbor.Key);
                    if (user.Key != null && user.Value.Count(m => m.Key == movie) > 0)
                    {
                        sumRatings += user.Value.SingleOrDefault(m => m.Key == movie).Value * neighbor.Value;
                        sumPearsonCof += neighbor.Value;
                    }
                }

                Console.WriteLine("Expected rating for:" + movie + " = " + (sumRatings / sumPearsonCof));
            }
        }
    }
}
