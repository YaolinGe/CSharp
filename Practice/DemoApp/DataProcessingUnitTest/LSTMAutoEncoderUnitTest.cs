using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sandvik.Coromant.CoroPlus.Tooling.SilentTools.BlazorApp.Pages.Playground.DevelopmentModules.AnomalyDetector
{
    public class LSTMAutoEncoderUnitTest
    {
        [Fact]
        public void TestCreateSequences()
        {
            var lstm = new LSTMAutoEncoder();

            double[,] data = new double[,]
            {
                        {1, 2, 3},
                        {4, 5, 6},
                        {7, 8, 9},
                        {10, 11, 12},
                        {13, 14, 15}
            };

            int sequenceLength = 3;
            var sequences = lstm.CreateSequences(data, sequenceLength);

            for (int i = 0; i < sequences.GetLength(0); i++)
            {
                for (int j = 0; j < sequences.GetLength(1); j++)
                {
                    for (int k = 0; k < sequences.GetLength(2); k++)
                    {
                        System.Diagnostics.Debug.Write($"{sequences[i, j, k]} ");
                    }
                    System.Diagnostics.Debug.WriteLine("");
                }
                System.Diagnostics.Debug.WriteLine("");
            }
        }

        [Fact]
        public void TestRunAnomaly()
        {
            var lstm = new LSTMAutoEncoder();

            double[,] fakeInput = new double[100, 7];

            lstm.RunAnomalyDetection(fakeInput);
        }
    }
}
