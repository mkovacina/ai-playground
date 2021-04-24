namespace snn
{
	using System;

	public class RandomizeTraining
	{
		public NeuralNet Net { get; }
		public double[][][] TrainingData { get; }
		public RandomizeTraining(NeuralNet net, double[][][] trainingData)
		{
			Net = net;
			TrainingData = trainingData;
		}

		public void Train()
		{

		}

	}
	class App
	{
		public static void Main(string[] args)
		{
			//#error version

			double[] input = new double[] {9624/16000.0, 6753/9000.0, 8706/16000.0, 7466/16000.0, 1162/16000.0, 9/180.0, 9876/16000.0, 6543/9000.0};
			var nn = new SimpleNeuralNetworkFactory(1234).Create(input.Length,4,1);

			var data = new double[,]
			{
				{1,1},
				{5,5},
				{-6,-6}
			};

			for(var x = 0; x < data.GetLength(0); x++)
			{
				var output = nn.run(data[x, 0]);
				var delta = data[x,1]-output[0];
			Console.WriteLine($"[ {data[x,0]} -> {output[0]}, {delta} ]");
			//foreach (var o in output)
			//{
				//Console.Write(o + " ");
			//}
		   // Console.WriteLine("]");
			}


		}
	}
}
