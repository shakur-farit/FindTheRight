using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace CellContent
{
	public class ContentGenerator
	{
		private readonly StaticDataService _staticDataService;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly RandomService _randomService;
		private readonly GameFactory _gameFactory;

		public void GenerateContent(Transform transform, List<Content> currentContentList)
		{
			List<Content> usedContentInGame = _persistentProgressService.Progress.ContentData.UsedInGame;
			List<Content> usedContentOnLevel = _persistentProgressService.Progress.ContentData.UsedInLevel;

			Content contentPrefab = GetUnusedContentPrefab(currentContentList, usedContentInGame);

			CreateContent(contentPrefab, transform, usedContentInGame, usedContentOnLevel);
		}

		public  ContentGenerator(StaticDataService staticDataService, PersistentProgressService persistentProgressService,
			RandomService randomService, GameFactory gameFactory)
		{
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
			_randomService = randomService;
			_gameFactory = gameFactory;
		}

		

		private Content GetUnusedContentPrefab(List<Content> currentContentList, List<Content> usedContentList)
		{
			Content contentPrefab = GetRandomContentPrefab(currentContentList);
			while (usedContentList.Contains(contentPrefab)) 
				contentPrefab = GetRandomContentPrefab(currentContentList);

			return contentPrefab;
		}

		private void CreateContent(Content contentPrefab, Transform transform, 
			List<Content> usedContentList, List<Content> usedContentOnLevel)
		{
			_gameFactory.CreateContent(contentPrefab.gameObject, transform);

			usedContentList.Add(contentPrefab);
			usedContentOnLevel.Add(contentPrefab);
		}

		private Content GetRandomContentPrefab(List<Content> contentList)
		{
			int randomIndex = _randomService.Next(0, contentList.Count);
			return contentList[randomIndex];
		}
	}
}