using System.Collections.Generic;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using StaticData;
using StaticEvents;

namespace SearchIntent
{
	public class SearchIntentGenerator
	{
		private List<ContentStaticData> _contentList = new List<ContentStaticData>();

		private readonly RandomService _randomService;
		private readonly PersistentProgressService _persistentProgressService;
		

		public SearchIntentGenerator(RandomService randomService, PersistentProgressService persistentProgressService)
		{
			_randomService = randomService;
			_persistentProgressService = persistentProgressService;
		}

		public void GenerateSearchIntent()
		{
			_contentList = _persistentProgressService.Progress.ContentData.UsedInLevel;

			int randomIndex = _randomService.Next(0, _contentList.Count);

			string searchIntent = _contentList[randomIndex].ContentId.ToUpper();

			_persistentProgressService.Progress.SearchIntentData.SearchIntent = searchIntent;

			StaticEventsHandler.CallSearchIntentChangedEvent();
		}
	}
}
