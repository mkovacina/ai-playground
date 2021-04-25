namespace snn
{
	using System;
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
