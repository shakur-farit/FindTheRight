using UnityEngine;

namespace Infrastructure.Services.Randomizer
{
	public class RandomService
	{
		public int Next(int min, int max) =>
			Random.Range(min, max);
	}
}