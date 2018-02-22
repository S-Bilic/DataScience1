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
            Console.WriteLine("Using Pearson!");
        }
    }
}
