using System.Collections.Generic;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using StaticData;

namespace CellContent
{
	public class ContentTypeRandomizer
	{
		private readonly RandomService _randomService;
		private readonly PersistentProgressService _persistentProgressService;

		public ContentTypeRandomizer(PersistentProgressService persistentProgressService, RandomService randomService)
		{
			_randomService = randomService;
			_persistentProgressService = persistentProgressService;
		}

		public List<ContentStaticData> GetRandomContentList()
		{
			List<List<ContentStaticData>> contentList = new List<List<ContentStaticData>>
			{
				_persistentProgressService.Progress.ContentData.Letters,
				_persistentProgressService.Progress.ContentData.Numbers
			};

			int randomIndex = _randomService.Next(0, contentList.Count);

			return contentList[randomIndex];
		}
	}
}