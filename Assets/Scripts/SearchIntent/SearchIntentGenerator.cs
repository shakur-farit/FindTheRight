using System.Collections.Generic;
using Events;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using StaticData;
using UnityEngine;

namespace SearchIntent
{
	public class SearchIntentGenerator : ISearchIntentGenerator
	{
		private List<ContentStaticData> _contentList = new List<ContentStaticData>();

		private readonly RandomService _randomService;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly ISearchIntentChangeEvent _searchIntentChangeEvent;


		public SearchIntentGenerator(RandomService randomService, PersistentProgressService persistentProgressService, 
			ISearchIntentChangeEvent searchIntentChangeEvent)
		{
			_randomService = randomService;
			_persistentProgressService = persistentProgressService;
			_searchIntentChangeEvent = searchIntentChangeEvent;
		}

		public void GenerateSearchIntent()
		{
			_contentList = _persistentProgressService.Progress.ContentData.UsedInLevel;

			int randomIndex = _randomService.Next(0, _contentList.Count);

			string searchIntent = _contentList[randomIndex].ContentId.ToUpper();

			_persistentProgressService.Progress.SearchIntentData.SearchIntent = searchIntent;

			_searchIntentChangeEvent.CallSearchIntentChangedEvent();
		}
	}
}
