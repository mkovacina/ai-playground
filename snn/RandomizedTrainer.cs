namespace snn
{
	using System;
	using Microsoft.Extensions.Logging;
	
	public class RandomizedTrainer
	{
		private readonly double[][][] TrainingData;
		private readonly int NumberOfDataSets;
		private readonly int NumberOfInputs;
		private readonly int NumberOfOutputs;
		private readonly int NumberOfHiddenNodes;
		private readonly SimpleNeuralNetworkFactory Factory;
		private NeuralNet? BestNeuralNet;
		public double BestError { get; private set; } = Double.MaxValue;
		private readonly ILogger<RandomizedTrainer> Logger;

		public RandomizedTrainer(SimpleNeuralNetworkFactory factory, double[][][] trainingData, ILogger<RandomizedTrainer> logger)
		{
			// todo: consider going back to double[,,,]
			TrainingData = trainingData;
			NumberOfDataSets = trainingData.Length;
			NumberOfInputs = trainingData[0].Length;
			NumberOfOutputs = trainingData[0][0].Length;
			NumberOfHiddenNodes = 4;
			Factory = factory;
			Logger = logger;
		}

		public void Train()
		{
			for (int numberOfNets = 0; numberOfNets < 5; numberOfNets++)
			{
				var net = Factory.Create(NumberOfInputs, NumberOfHiddenNodes, NumberOfOutputs);

				var error = 0.0;

				for (int x = 0; x < NumberOfDataSets; x++)
				{
					var output = net.run(TrainingData[x][0]);

					for (int i = 0; i < output.Length; i++)
					{
						var temp = TrainingData[x][1][i] - output[i];
						error += (temp * temp);
					}
				}

				Logger.LogDebug("Error was {error}", error);

				if (error < BestError)
				{
					BestError = error;
					BestNeuralNet = net;
				}
			}
		}

	}
}
