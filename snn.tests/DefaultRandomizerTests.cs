namespace snn.tests
{
	using System;
	using Xunit;

	public class DefaultRandomizerTests
	{
		private readonly Random rng;
		private readonly DefaultRandomizer randomizer;

		public DefaultRandomizerTests()
		{
			rng = new Random(1234);
			randomizer = new DefaultRandomizer(1234);
		}

		// yes yes, i know these tests know a little too much about
		// the implementation (meaning linear assignment of numbers),
		// but it will work for now.

		[Fact]
		public void RandomFill_OneDimension()
		{
			double[] data = new double[3];
			randomizer.RandomFill(data);
			foreach(var x in data)
			{
				Assert.True(x == rng.NextDouble());
			}
		}

		[Fact]
		public void RandomFill_TwoDimension()
		{
			double[,] data = new double[3,3];
			randomizer.RandomFill(data);
			foreach( var x in data)
			{
				Assert.True(x == rng.NextDouble());
			}
		}
	}
}
