using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandvik.Coromant.CoroPlus.Tooling.SilentTools.BlazorApp.Pages.Playground.DevelopmentModules.AnomalyDetector;


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

            dv.LinePlot(x, y);
        }
    }
}
