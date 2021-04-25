namespace snn
{
	using System;

	internal sealed class DefaultRandomizer : Randomizer
	{
		public int Seed {get;}
		private readonly Random rng;

		public DefaultRandomizer(int seed)
		{
			Seed = seed;	
			rng = new Random(seed);
		}

		public void RandomFill(double[] data)
		{
			for (var x = 0; x < data.Length; x++)
			{
				data[x] = rng.NextDouble();
			}
		}

		public void RandomFill(double[,] data)
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