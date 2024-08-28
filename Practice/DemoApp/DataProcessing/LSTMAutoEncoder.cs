using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;

namespace DataProcessing
{
    public class LSTMAutoEncoder
    {
        private InferenceSession _session;
        DataProcessing dataProcessing = new DataProcessing(null, null);
        DataVisualizer dataVisualizer = new DataVisualizer();
        double threshold = 0.00018678485066629904;

        public void LoadModel()
        {
            _session = new InferenceSession("C:\\Users\\nq9093\\CodeSpace\\DeepLearningAI\\DeepLearning\\PyTorchBasics\\practice\\anomaly_detection\\anomalyDetectionMultiChannel.onnx");
            Console.WriteLine("Model loaded successfully");
        }

        public void RunAnomalyDetection(double[,] data)
        {
            int sequenceLength = 30;
            var sequences = dataProcessing.CreateSequences(data, sequenceLength);
            var indices_anomalies = new List<int>();
            int cnt = 0;

            foreach (var sequence in sequences)
            {
                var inputTensor = new DenseTensor<float>(new[] { 1, sequenceLength, 7 });

                for (int i = 0; i < sequenceLength; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        inputTensor[0, i, j] = (float)sequence[i, j];
                    }
                }

                var input = new NamedOnnxValue[]
                {
                    NamedOnnxValue.CreateFromTensor("input", inputTensor)
                };

                using IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results = _session.Run(input);

                var outputTensor = results.First().AsTensor<float>();

                double error = 0;
                for (int j = 0; j < 7; j++)
                {
                    var diff = inputTensor[0, sequenceLength - 1, j] - outputTensor[0, sequenceLength - 1, j];
                    error += Math.Pow(diff, 2);
                }

                if (error > threshold)
                {
                    indices_anomalies.Add(cnt);
                }
                cnt++;
                Console.WriteLine(cnt);
            }
        }
    }
}
