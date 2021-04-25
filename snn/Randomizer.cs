namespace snn
{
	using System;

	public interface Randomizer
	{
		public int Seed {get;}

		public void RandomFill(double[] data);
		public void RandomFill(double[,] data);
	}
}