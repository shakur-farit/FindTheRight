using System;
using Data;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Utility;
using Zenject;

namespace CellContent
{
	public class Content : MonoBehaviour
	{
		private PersistentProgressService _persistentProgressService;

		[field: SerializeField] public SpriteRenderer ContentSprite { get; set; }
		public ContentType Type { get; set; }
		public string Id { get; set; }

		[Inject]
		public void Constructor(PersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void Start()
		{
			ContentData contentData = _persistentProgressService.Progress.ContentData;

			Debug.Log($"{contentData.Type} / {contentData.Id}");

			ContentSprite.sprite = contentData.Sprite;
			Type = contentData.Type;
			Id = contentData.Id;

			NormalizeContentSprite();
		}

		private void NormalizeContentSprite() => 
			HelperUtility.NumberSpriteNormalize(Type, ContentSprite.transform, Id);
	}
}
