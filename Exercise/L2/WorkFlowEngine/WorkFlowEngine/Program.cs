using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowEngine
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Execute the workflow engine 
            var workFlow = new WorkFlow();
            workFlow.Add(new UploadVideo());
            workFlow.Add(new CallWebService());
            workFlow.Add(new SendEmail());
            workFlow.Add(new ChangeStatus());

            var workFlowEngine = new WorkFlowEngine();
            workFlowEngine.Run(workFlow);

        }

    }
}
