using System.Collections.Generic;
using CellContent.Factory;
using Cysharp.Threading.Tasks;
using Data;
using Events;
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
		private readonly IContentSetupEvent _contentSetupEvent;

		public  ContentGenerator(PersistentProgressService persistentProgressService, RandomService randomService, 
			IContentFactory contentFactory, IContentSetupEvent contentSetupEvent)
		{
			_persistentProgressService = persistentProgressService;
			_randomService = randomService;
			_contentFactory = contentFactory;
			_contentSetupEvent = contentSetupEvent;
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

		private async UniTask CreateContent(ContentStaticData contentStaticData, Transform transform, 
			List<ContentStaticData> usedContentList, List<ContentStaticData> usedContentOnLevel)
		{
			await _contentFactory.CreateContent(transform);

			SetupContentData(contentStaticData);

			usedContentList.Add(contentStaticData);
			usedContentOnLevel.Add(contentStaticData);
		}

		private void SetupContentData(ContentStaticData contentStaticData)
		{
			ContentData contentData = _persistentProgressService.Progress.ContentData;

			contentData.Type = contentStaticData.Type;
			contentData.Id = contentStaticData.Id.ToUpper();
			contentData.Sprite = contentStaticData.Sprite;

			_contentSetupEvent.CallContentSetup();
		}

		private ContentStaticData GetRandomContent(List<ContentStaticData> contentList)
		{
			int randomIndex = _randomService.Next(0, contentList.Count);
			return contentList[randomIndex];
		}
	}
}