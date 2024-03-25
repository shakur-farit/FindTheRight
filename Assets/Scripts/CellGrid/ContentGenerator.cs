using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.PersistentProgressService;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace CellGrid
{
	public class ContentGenerator : MonoBehaviour
	{
		[SerializeField] private Transform _contentContainer;

		List<Content> _contentList = new List<Content>();
		private Content _contentPrefab;

		private StaticDataService _staticDataService;
		private PersistentProgressService _persistentProgressService;
		private RandomService _randomService;

		[Inject]
		public void Construct(StaticDataService staticDataService, PersistentProgressService persistentProgressService,
			RandomService randomService)
		{
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
			_randomService = randomService;
		}

		private void Start() => 
			GenerateContent();

		private void GenerateContent()
		{
			_contentList = _staticDataService.ForContent.ToList();
			List<Content> usedContentList = _persistentProgressService.Progress.ContentData.UsedContent;

			_contentPrefab = GetRandomContentPrefab();

			while (usedContentList.Contains(_contentPrefab)) 
				_contentPrefab = GetRandomContentPrefab();

			Instantiate(_contentPrefab, _contentContainer);
			usedContentList.Add(_contentPrefab);
		}

		private Content GetRandomContentPrefab()
		{
			int randomIndex = _randomService.Next(0, _contentList.Count);
			return _contentList[randomIndex];
		}
	}
}