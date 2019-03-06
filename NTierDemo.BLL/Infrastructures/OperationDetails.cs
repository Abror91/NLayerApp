using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierDemo.BLL.Infrastructures
{
    public class OperationDetails
    {
        public OperationDetails(bool succedded, string message, string property)
        {
            Succedded = succedded;
            Property = property;
            Message = message;
        }
        public bool Succedded { get; private set; }
        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}
