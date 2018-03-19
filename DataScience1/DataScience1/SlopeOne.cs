using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience1
{
    class SlopeOne : InterfaceAlgorithm
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
                        double deviation = 0;
                       
                        foreach (var article in user.Value)
                        {
                            if (mainUser.Value.Keys.Contains(article.Key))
                            {
                                
                               
                            }
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
