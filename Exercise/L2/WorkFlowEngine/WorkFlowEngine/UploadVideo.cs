using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkFlowEngine
{
    // Create classes that implement the interface
    public class UploadVideo : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Uploading a video");
        }
    }
}
