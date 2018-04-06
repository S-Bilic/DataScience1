using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScience1
{
    class DataSet
    {
        private InterfaceAlgorithm IAlgorithm;

        private Dictionary<string, Dictionary<string, double>> Context;

        private Dictionary<string, List<string>> UserItems;

        private string TargetUser;

        private double SimmThreshhold;

        public void SetAlgorithm(InterfaceAlgorithm newAlgorithm)
        {
            IAlgorithm = newAlgorithm;
        }

        public void SetContext(Dictionary<string,Dictionary<string,double>> context)
        {
            Context = context;
        }

        public void SetUserItems(Dictionary<string, List<string>> userItems)
        {
            UserItems = userItems;
        }

        public void SetTargetUser(string targetUser)
        {
            TargetUser = targetUser;
        }

        public void SetThreshold(double simmthreshold)
        {
            SimmThreshhold = simmthreshold;
        }

        public void Init()
        {
            IAlgorithm.Use(UserItems, TargetUser, Context, SimmThreshhold);
        }
    }
}
