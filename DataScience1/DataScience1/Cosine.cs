using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience1
{
    class Cosine : InterfaceAlgorithm
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
                        double cosineSimNumerator = 0;
                        double cosineSimDenumerator1 = 0;
                        double cosineSimDenumerator2 = 0;
                        double cosineSimDenumeratorTotal = 0;

                        foreach (var article in user.Value)
                        {
                            double mainUserRating = mainUser.Value.SingleOrDefault(v => v.Key == article.Key).Value;
                            cosineSimNumerator += mainUserRating * article.Value;
                            cosineSimDenumerator1 += Math.Pow((mainUserRating), 2);
                            cosineSimDenumerator2 += Math.Pow((article.Value), 2);

                            //Console.WriteLine("User 7 =" + mainUserRating + " all users =" + article.Value + " " + cosineSimDenumerator1 + " " + Math.Sqrt(cosineSimDenumerator1) + " " + cosineSimDenumerator2 + " " + Math.Sqrt(cosineSimDenumerator2) + " " + cosineSimDenumeratorTotal);   
                        }
                        cosineSimDenumeratorTotal = (Math.Sqrt(cosineSimDenumerator1)) * (Math.Sqrt(cosineSimDenumerator2));

                        double cosineSim = cosineSimNumerator / cosineSimDenumeratorTotal;
                        if (cosineSim > simmthreshold)
                        {               
                            var tempDict = from item in dict orderby item.Value descending select item;

                            if (dict.Count == 3 && tempDict.Last().Value < cosineSim)
                            {
                                dict.Remove(tempDict.Last().Key);
                            }

                            if (dict.Count < 3)
                            {
                                dict.Add(user.Key, cosineSim);
                            }
                            //dict.Add(user.Key, cosineSim);
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
