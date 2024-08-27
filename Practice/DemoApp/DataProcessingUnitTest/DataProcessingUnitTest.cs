using DataProcessing;

namespace DataProcessingUnitTest
{
    public class DataProcessingUnitTest
    {
        [Fact]
        public void TestNormalizeColumns()
        {
            var dp = new DataProcessing.DataProcessing(null, null);
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
            var dp = new DataProcessing.DataProcessing(null, null);
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
    }
}