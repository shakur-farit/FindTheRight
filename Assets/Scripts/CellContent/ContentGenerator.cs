using System.Collections.Generic;
using CellContent.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using StaticData;
using UnityEngine;

namespace CellContent
{
	public class ContentGenerator : IContentGenerator
	{
		private readonly PersistentProgressService _persistentProgressService;
		private readonly RandomService _randomService;
		private readonly IContentFactory _contentFactory;

		public  ContentGenerator(PersistentProgressService persistentProgressService, RandomService randomService, IContentFactory contentFactory)
		{
			_persistentProgressService = persistentProgressService;
			_randomService = randomService;
			_contentFactory = contentFactory;
		}

		public async UniTask GenerateContent(Transform transform, List<ContentStaticData> currentContentList)
		{
			List<ContentStaticData> usedContentInGame = _persistentProgressService.Progress.ContentData.UsedInGame;
			List<ContentStaticData> usedContentOnLevel = _persistentProgressService.Progress.ContentData.UsedInLevel;
			
			ContentStaticData contentData = GetUnusedContentPrefab(currentContentList, usedContentInGame);

			await CreateContent(contentData, transform, usedContentInGame, usedContentOnLevel);
		}

		private ContentStaticData GetUnusedContentPrefab(List<ContentStaticData> currentContentList, List<ContentStaticData> usedContentList)
		{
			ContentStaticData contentPrefab = GetRandomContent(currentContentList);
			while (usedContentList.Contains(contentPrefab))
			{
				if (usedContentList.Count >= currentContentList.Count)
				{
					Debug.LogError($"Not enough {currentContentList[0].Type} Type content. Add more data");
					return null;
				}
				
				contentPrefab = GetRandomContent(currentContentList);
			}

			return contentPrefab;
		}

		private async UniTask CreateContent(ContentStaticData contentData, Transform transform, 
			List<ContentStaticData> usedContentList, List<ContentStaticData> usedContentOnLevel)
		{
			GameObject prefab = await _contentFactory.CreateContent(transform);
			Content contentPrefab = prefab.GetComponent<Content>();

			contentPrefab.Type = contentData.Type;
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