using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowEngine
{
    public class CallWebService : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Calling a web service");
        }
    }
}
