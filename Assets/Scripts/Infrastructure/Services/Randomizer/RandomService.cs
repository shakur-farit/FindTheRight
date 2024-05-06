using StaticData;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.Randomizer
{
	public class RandomService
	{
		public int Next(int min, int max) =>
			Random.Range(min, max);

		public List<ContentStaticData> GetRandomContentList(List<List<ContentStaticData>> contentList)
		{
			int randomIndex = Random.Range(0, contentList.Count);

			return contentList[randomIndex];
		}
	}
}