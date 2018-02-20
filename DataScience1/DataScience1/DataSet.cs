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

        public void setAlgorithm(InterfaceAlgorithm newAlgorithm)
        {
            IAlgorithm = newAlgorithm;
        }

        public void Init()
        {
            IAlgorithm.Use();
        }
    }
}
