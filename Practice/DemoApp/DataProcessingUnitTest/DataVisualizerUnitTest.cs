using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessing;

namespace DataProcessingUnitTest
{
    public class DataVisualizerUnitTest
    {
        [Fact]
        public void TestLinePlot()
        {
            var dv = new DataVisualizer();
            double[] x = new double[] { 1, 2, 3 };
            double[] y = new double[] { 4, 5, 6 };

            string line = dv.LinePlot(x, y);

            Assert.NotNull(line);
        }
    }
}
