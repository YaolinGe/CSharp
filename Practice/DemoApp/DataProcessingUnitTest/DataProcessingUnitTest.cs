

namespace Sandvik.Coromant.CoroPlus.Tooling.SilentTools.BlazorApp.Pages.Playground.DevelopmentModules.AnomalyDetector
{
    public class DataProcessingUnitTest
    {
        [Fact]
        public void TestNormalizeColumns()
        {
            var dp = new DataProcessing(null, null);
            double[,] data = new double[,]
            {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
            };

            double[,] expected = new double[,]
            {
            { 0, 0, 0 },
            { .5, .5, .5 },
            { 1, 1, 1 }
            };

            double[,] result = dp.NormalizeData(data);

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    Assert.Equal(expected[i, j], result[i, j], 1e-6);
                }
            }

        }

        [Fact]
        public void TestNormalizeColumnsWithConstantValues()
        {
            var dp = new DataProcessing(null, null);
            double[,] data = new double[,]
            {
            { 5, 5, 5 },
            { 5, 5, 5 },
            { 5, 5, 5 }
            };

            double[,] expected = new double[,]
            {
            { .0, .0, .0 },
            { .0, .0, .0 },
            { .0, .0, .0 }
            };

            double[,] result = dp.NormalizeData(data);

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    Assert.Equal(expected[i, j], result[i, j], 1e-6);
                }
            }
        }

        private static bool AreEqual(double[,] array1, double[,] array2)
        {
            if (array1.GetLength(0) != array2.GetLength(0) || array1.GetLength(1) != array2.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    if (array1[i, j] != array2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [Fact]
        public void TestGetDataSeriesFromColumnIndex()
        {
            var dp = new DataProcessing(null, null);
            double[,] data = new double[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            double[] expected = new double[] { 2, 5, 8 };
            double[] result = dp.GetDataSeriesFromColumnIndex(data, 1);
            Assert.Equal(expected, result);

        }

        [Fact]
        public void TestInterpolation()
        {
            var dp = new DataProcessing(null, null);
            
        }
    }
}