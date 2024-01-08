using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritence;

namespace Inheritence
{


    internal class Program
    {
        static void Main(string[] args)
        {
            var text = new Text();
            text.Width = 100; 
            text.Copy();
        }
    }
}
