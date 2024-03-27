using System.Collections.Generic;
using CellContent;
using CellGrid;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using StaticEvents;

namespace SearchIntent
{
	public class SearchIntentGenerator
	{
		private List<Content> _contentList = new List<Content>();

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
