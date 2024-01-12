using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowEngine
{
    public class SendEmail : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Sending an email");
        }
    }
}
