using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowEngine
{
    // Create an interface for activities
    public class ChangeStatus : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Changing the status of the video record in the database to “Processing”");
        }
    }
}
