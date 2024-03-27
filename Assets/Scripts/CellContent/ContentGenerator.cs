using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using StaticData;
using UnityEngine;

namespace CellContent
{
	public class ContentGenerator
	{
		private readonly PersistentProgressService _persistentProgressService;
		private readonly RandomService _randomService;
		private readonly GameFactory _gameFactory;

		public  ContentGenerator(PersistentProgressService persistentProgressService, RandomService randomService, GameFactory gameFactory)
		{
			_persistentProgressService = persistentProgressService;
			_randomService = randomService;
			_gameFactory = gameFactory;
		}

		public void GenerateContent(Transform transform, List<ContentStaticData> currentContentList)
		{
			List<ContentStaticData> usedContentInGame = _persistentProgressService.Progress.ContentData.UsedInGame;
			List<ContentStaticData> usedContentOnLevel = _persistentProgressService.Progress.ContentData.UsedInLevel;
			
			ContentStaticData contentData = GetUnusedContentPrefab(currentContentList, usedContentInGame);

			CreateContent(contentData, transform, usedContentInGame, usedContentOnLevel);
		}

		private ContentStaticData GetUnusedContentPrefab(List<ContentStaticData> currentContentList, List<ContentStaticData> usedContentList)
		{
			ContentStaticData contentPrefab = GetRandomContent(currentContentList);
			while (usedContentList.Contains(contentPrefab))
				contentPrefab = GetRandomContent(currentContentList);

			return contentPrefab;
		}

		private void CreateContent(ContentStaticData contentData, Transform transform, 
			List<ContentStaticData> usedContentList, List<ContentStaticData> usedContentOnLevel)
		{
			Content contentPrefab = _gameFactory.CreateContent(transform).GetComponent<Content>();

			contentPrefab.type = contentData.Type;
			contentPrefab.ContentId = contentData.ContentId;
			contentPrefab.Sprite = contentData.Sprite;

			usedContentList.Add(contentData);
			usedContentOnLevel.Add(contentData);
		}

		private ContentStaticData GetRandomContent(List<ContentStaticData> contentList)
		{
			int randomIndex = _randomService.Next(0, contentList.Count);
			return contentList[randomIndex];
		}
	}
}