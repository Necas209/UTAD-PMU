using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAppA
{
    public class InvalidOperationException : ApplicationException
    {
        public InvalidOperationException(string msg) : base(msg)
        {
        }
    }
}
