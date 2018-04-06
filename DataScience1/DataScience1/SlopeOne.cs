using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience1
{
    class SlopeOne : InterfaceAlgorithm
    {
        public void Use(Dictionary<string, List<string>> userItems, string targetUser, Dictionary<string, Dictionary<string, double>> context, double simmthreshold)
        {
            //<Item Key, <Item Key ref, List<Deviation, NUsers>>>
            Dictionary<string, Dictionary<string, List<double>>> dictDev = new Dictionary<string, Dictionary<string, List<double>>>();

            foreach (var user in context)
            {
                foreach (var firstItem in user.Value)//EDIT
                {
                    foreach (var secondItem in user.Value)//EDIT user count klopt niet
                    {
                        if (firstItem.Key != secondItem.Key)
                        {
                            int firstItemCount = dictDev.Count(x => x.Key == firstItem.Key);
                            int secondItemCount = dictDev.Count(x => x.Key == secondItem.Key);
                            if (firstItemCount == 0 && secondItemCount == 0)
                            {
                                dictDev.Add(firstItem.Key, new Dictionary<string, List<double>>() { { secondItem.Key, new List<double>() { firstItem.Value - secondItem.Value, 1 } } });
                            }
                            else if (firstItemCount > 0 && secondItemCount == 0) //Has the first item
                            {
                                var item = dictDev.SingleOrDefault(x => x.Key == firstItem.Key).Value.SingleOrDefault(y => y.Key == secondItem.Key); //Finds if the second item exists
                                if (item.Key != null)//Exist add value and user count + 1
                                {
                                    item.Value[0] += firstItem.Value - secondItem.Value;
                                    item.Value[1] ++;
                                }
                                else //Not found add new list with dev and 1 user
                                {
                                    dictDev.Single(x => x.Key == firstItem.Key).Value.Add(secondItem.Key, new List<double>() { firstItem.Value - secondItem.Value, 1 });
                                }
                            }
                            else if (firstItemCount == 0 && secondItemCount > 0)
                            {
                                var item = dictDev.SingleOrDefault(x => x.Key == secondItem.Key).Value.SingleOrDefault(y => y.Key == firstItem.Key); //Finds if the second item exists
                                if (item.Key != null)//Exist add value and user count + 1
                                {
                                    item.Value[0] += secondItem.Value - firstItem.Value;
                                    item.Value[1]++;
                                }
                                else //Not found add new list with dev and 1 user
                                {
                                    dictDev.Single(x => x.Key == secondItem.Key).Value.Add(firstItem.Key, new List<double>() { secondItem.Value - firstItem.Value, 1 });
                                }
                            }
                        }
                    }
                }
            }
            foreach (var item in dictDev)
            {
                foreach (var item2 in item.Value)
                {
                    Console.WriteLine(item.Key + " --- " + item2.Key + "  Dev " + item2.Value[0] + " n users " + item2.Value[1]);
                }
            }

            foreach (var user in userItems)
            {
                Dictionary<string, double> userRatings = context.SingleOrDefault(x => x.Key == user.Key).Value;
                if (userRatings != null)
                {
                    foreach (var item in user.Value)
                    {
                        double predRating = 0;
                        foreach (var rating in userRatings)
                        {
                        }
                    }
                }
            }
        }
    }
}
