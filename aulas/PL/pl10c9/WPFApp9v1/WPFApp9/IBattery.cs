using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp9
{
    interface IBattery
    {
        int ChargeValue { get; set; }
        event voidArgInt ChargeChanged;
        void Charge(int delta);
        void Descharge(int delta);
    }
}
