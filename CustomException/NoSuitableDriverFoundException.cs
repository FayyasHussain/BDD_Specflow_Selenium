using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Specflow_Selenium.CustomException
{
    public class NoSuitableDriverFoundException : Exception
    {
        public NoSuitableDriverFoundException(string message) : base (message)
        {
        }
    }
}
