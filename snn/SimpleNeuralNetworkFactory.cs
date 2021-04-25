namespace snn
{
	using System;

	public class SimpleNeuralNetworkFactory
	{
		private readonly Random rng;

		public SimpleNeuralNetworkFactory(int seed)
		{
			rng = new Random(seed);
		}

		public NeuralNet Create(int numberOfInputNodes, int numberOfHiddenNodes, int numberOfOutputNodes)
		{
			double[] hiddenBias = new double[numberOfHiddenNodes];
			double[,] inputWeights = new double[numberOfInputNodes, numberOfHiddenNodes];
			double[] hidden = new double[numberOfHiddenNodes];
			double[,] hiddenWeights = new double[numberOfHiddenNodes, numberOfOutputNodes];
			double[] outputBias = new double[numberOfOutputNodes];
			double[] output = new double[numberOfOutputNodes];

			//engtheRandomize(input);
			Randomize(hiddenBias);
			Randomize(inputWeights);
			Randomize(hidden);
			Randomize(hiddenWeights);
			Randomize(hiddenBias);

			return new NeuralNet(inputWeights, hiddenBias, hiddenWeights, outputBias, numberOfOutputNodes);
		}
		private void Randomize(double[] data)
		{
			for (var x = 0; x < data.Length; x++)
			{
				data[x] = rng.NextDouble();
			}
		}
		private void Randomize(double[,] data)
		{
			for (var x = 0; x < data.GetLength(0); x++)
			{
				for (var y = 0; y < data.GetLength(1); y++)
				{
					data[x, y] = rng.NextDouble();
				}
			}
		}



	}

}
