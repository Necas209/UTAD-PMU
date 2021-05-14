using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp9
{
    public class OutOfLimitsException : System.ApplicationException
    {
        public int Charge;
        public OutOfLimitsException(string msg, int ActualCharge) : base(msg)
        {
            Charge = ActualCharge;
        }
    }
}
