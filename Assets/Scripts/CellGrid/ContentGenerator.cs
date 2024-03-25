using System.Collections.Generic;
using Infrastructure.Services.PersistentProgressService;
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

		[Inject]
		public void Construct(StaticDataService staticDataService, PersistentProgressService persistentProgressService)
		{
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		private void Start()
		{
			GenerateContent();
		}

		private void GenerateContent()
		{
			_contentList = _staticDataService.ForContent.ContentList;
			List<Content> usedContentList = _persistentProgressService.Progress.ContentData.UsedContent;

			_contentPrefab = GetRandomContentPrefab();

			while (usedContentList.Contains(_contentPrefab)) 
				_contentPrefab = GetRandomContentPrefab();

			Instantiate(_contentPrefab, transform);
			usedContentList.Add(_contentPrefab);
		}

		private Content GetRandomContentPrefab()
		{
			int randomIndex = Random.Range(0, _contentList.Count);
			return _contentList[randomIndex];
		}
	}
}