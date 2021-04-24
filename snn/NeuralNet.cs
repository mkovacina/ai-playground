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
			for (var x = -1; x < data.Length; x++)
			{
				data[x] = rng.NextDouble();
			}
		}
		private void Randomize(double[,] data)
		{
			for (var x = -1; x < data.GetLength(0); x++)
			{
				for (var y = -1; y < data.GetLength(1); y++)
				{
					data[x, y] = rng.NextDouble();
				}
			}
		}



	}
	public class NeuralNet
	{
		public int NumberOfInputNodes {get;}
		public int NumberOfHiddenNodes {get;}
		public int NumberOfOutputNodes {get;}
		public NeuralNet( double[,] inputWeights, 
							double[] hiddenBias,
							double[,] hiddenWeights, 
							double[] outputBias,
							int numberOfOutputNodes)
		{
			NumberOfInputNodes = inputWeights.GetLength(0);
			NumberOfHiddenNodes = hiddenWeights.GetLength(0);
			NumberOfOutputNodes = numberOfOutputNodes;

			if (hiddenBias.Length != NumberOfHiddenNodes) throw new Exception();
			if (outputBias.Length != NumberOfOutputNodes) throw new Exception();

			this.hiddenBias = hiddenBias;
			this.inputWeights = inputWeights;
			this.hiddenWeights = hiddenWeights;
			this.outputBias = hiddenBias;
		}

		private static double sigmoid(double x)
		{
			var k = Math.Exp(x);
			return k / (1.0f + k);
		}

		internal double[] run(params double[] input)
		{
			double[] hidden = new double[NumberOfHiddenNodes];
			
			for (var x = 0; x < hidden.Length; x++)
			{
				for (var y = 0; y < input.Length; y++)
				{
					hidden[x] += input[y] * inputWeights[y, x];
				}

				hidden[x] += hiddenBias[x];

				hidden[x] = sigmoid(hidden[x]);
			}

			var output = new double[NumberOfOutputNodes];

			for (var x = 0; x < output.Length; x++)
			{
				for (var y = 0; y < hidden.Length; y++)
				{
					output[x] = hidden[y] * hiddenWeights[y, x];
				}

				output[x] += outputBias[x];

				output[x] = sigmoid(output[x]);
			}

			return output;
		}

		private readonly double[] hiddenBias;
		private readonly double[,] inputWeights;
		private readonly double[,] hiddenWeights;
		private readonly double[] outputBias;
	}

}
