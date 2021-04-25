namespace snn
{
	using System;
	using Microsoft.Extensions.Logging;

	class App
	{
		public static void Main(string[] args)
		{
			//#error version

			var data = new double[3][][];

			for( var x = 0; x < data.Length; x ++)
			{
				data[x] = new double[][] { new double[] {x}, new double[] {x*2}};
			}
			var loggerFactory = LoggerFactory.Create(x =>
			{
				x.AddConsole();
				x.SetMinimumLevel(LogLevel.Debug);
			});
			var factory = new SimpleNeuralNetworkFactory(1234);
			var trainer = new RandomizedTrainer(factory, data, loggerFactory.CreateLogger<RandomizedTrainer>() );

			for(var x = 0; x < 5; x++ )
			{
				trainer.Train();
				Console.WriteLine($"epoch {x}: {trainer.BestError}");
			}
			//	{5,5},
			//{-6,-6}
			//};

			//var data = new double[,]
			//{
				//{1,1},
				//{5,5},
				//{-6,-6}
			//};

			//for (var x = 0; x < data.GetLength(0); x++)
			//{
				//var output = nn.run(data[x, 0]);
				//var delta = data[x, 1] - output[0];
				//Console.WriteLine($"[ {data[x, 0]} -> {output[0]}, {delta} ]");
				////foreach (var o in output)
				////{
				////Console.Write(o + " ");
				////}
				//// Console.WriteLine("]");
			//}


		}
	}
}
