﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience1
{
    public interface InterfaceAlgorithm 
    {
        void Use(Dictionary<string, List<string>> userItems, string targetUser, Dictionary<string,Dictionary<string,double>> context, double simmthreshold);
    }
}
