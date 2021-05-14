using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp9
{
    public class Battery : IBattery
    {
        public int ChargeValue { get; private set; }

        public event voidArgInt ChargeChanged;

        public Battery()
        {
            ChargeValue = 50;
        }

        public void Charge(int delta)
        {
            if ((ChargeValue + delta) > 100)
                throw new OutOfLimitsException("A bateria não suporta essa carga!!!", ChargeValue);
            ChargeValue += delta;

            if (ChargeChanged != null)
                ChargeChanged(ChargeValue);
        }

        public void Descharge(int delta)
        {
            if ((ChargeValue - delta) < 0)
                throw new OutOfLimitsException("A bateria não suporta essa descarga!!!", ChargeValue);
            ChargeValue -= delta;

            if (ChargeChanged != null)
                ChargeChanged(ChargeValue);
        }
    }
}
