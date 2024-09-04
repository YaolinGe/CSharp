using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;
using System.Diagnostics;
namespace Sandvik.Coromant.CoroPlus.Tooling.SilentTools.BlazorApp.Pages.Playground.DevelopmentModules.AnomalyDetector;


public class LSTMAutoEncoder
{
    private InferenceSession _session;
    double threshold = 0.00018678485066629904;
    public List<int> indicesAnomaly = new List<int>();
    public List<double> errorAnomaly = new List<double>();

    public LSTMAutoEncoder()
    {
        SessionOptions sessionOptions = new();
        //sessionOptions.AppendExecutionProvider_CUDA(0);

        _session = new InferenceSession("C:\\Users\\nq9093\\CodeSpace\\DeepLearningAI\\DeepLearning\\PyTorchBasics\\practice\\anomaly_detection\\anomalyDetectionMultiChannel.onnx", sessionOptions);
        Console.WriteLine("Model loaded successfully");
    }

    public void RunAnomalyDetection(double[,] data)
    {
        int sequenceLength = 30;
        double[,,] sequences = CreateSequences(data, sequenceLength);

        Stopwatch totalStopwatch = new Stopwatch();
        totalStopwatch.Start();

        for (int i = 0; i < sequences.GetLength(0); i++)
        {
            Stopwatch iterationStopwatch = new Stopwatch();
            iterationStopwatch.Start();

            DenseTensor<float> inputTensor = new DenseTensor<float>(new[] { 1, sequenceLength, sequences.GetLength(2) });

            for (int j = 0; j < sequences.GetLength(1); j++)
            {
                for (int k = 0; k < sequences.GetLength(2); k++)
                {
                    inputTensor[0, j, k] = (float)sequences[i, j, k];
                }
            }

            Tensor<float> outputTensor = GetInference(inputTensor);

            double error = CalculateError(outputTensor, inputTensor);

            iterationStopwatch.Stop();
            Console.WriteLine($"Error: {error} Time taken for inference: {iterationStopwatch.ElapsedMilliseconds} milliseconds");
            iterationStopwatch.Reset();

            if (error > threshold)
            {
                indicesAnomaly.Add(i);
                errorAnomaly.Add(error);
                Console.WriteLine($"Anomaly detected at index {i} with error {error}");
            }
        }
        totalStopwatch.Stop();
        Console.WriteLine($"Time taken for all inferences: {totalStopwatch.ElapsedMilliseconds} milliseconds");
    }

    public double[,,] CreateSequences(double[,] data, int sequenceLength)
    {
        int numSamples = data.GetLength(0);
        int numColumns = data.GetLength(1);  // No timestamp is included in the data, so the number of columns is the number of features

        double[,,] sequences = new double[numSamples - sequenceLength + 1, sequenceLength, numColumns];

        for (int i = 0; i <= numSamples - sequenceLength; i++)
        {
            for (int j = 0; j < sequenceLength; j++)
            {
                for (int k = 0; k < numColumns; k++)
                {
                    sequences[i, j, k] = data[i + j, k];
                }
            }
        }
        return sequences;
    }

    public Tensor<float> GetInference(DenseTensor<float> input)
    {
        NamedOnnxValue[] inputs = new NamedOnnxValue[]
        {
            NamedOnnxValue.CreateFromTensor("input", input)
        };

        using IDisposableReadOnlyCollection<DisposableNamedOnnxValue> results = _session.Run(inputs);

        Tensor<float> outputTensor = results.First().AsTensor<float>();
        return outputTensor;
    }

    public static double CalculateError(Tensor<float> inputTensor, Tensor<float> outputTensor)
    {
        ReadOnlySpan<int> outputShapeSpan = outputTensor.Dimensions;
        int[] outputShape = outputShapeSpan.ToArray();

        // Ensure the input and output tensors have the same shape
        if (!inputTensor.Dimensions.SequenceEqual(outputShape))
        {
            throw new InvalidOperationException("Input and output tensors must have the same shape.");
        }

        double error = 0;
        int batchSize = outputShape[0];
        int sequenceLength = outputShape[1];
        int featureSize = outputShape[2];

        for (int i = 0; i < batchSize; i++)
        {
            for (int j = 0; j < sequenceLength; j++)
            {
                for (int k = 0; k < featureSize; k++)
                {
                    double diff = inputTensor[i, j, k] - outputTensor[i, j, k];
                    error += diff * diff;
                }
            }
        }
        error /= (batchSize * sequenceLength * featureSize);
        return error;
    }
}
