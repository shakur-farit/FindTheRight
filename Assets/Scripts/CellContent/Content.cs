using Data;
using Events;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Utility;
using Zenject;

namespace CellContent
{
	public class Content : MonoBehaviour
	{
		[SerializeField] private SpriteRenderer _mainContentSprite;

		private ContentType _type;
		private string _id;

		private bool _isSet;

		private PersistentProgressService _persistentProgressService;
		private IContentSetupEvent _contentSetupEvent;

		public Transform MainContentTransform => _mainContentSprite.transform;
		public string Id => _id;

		[Inject]
		public void Constructor(PersistentProgressService persistentProgressService, IContentSetupEvent contentSetupEvent)
		{
			_persistentProgressService = persistentProgressService;
			_contentSetupEvent = contentSetupEvent;
		}

		private void OnEnable() => 
			_contentSetupEvent.ContentSetup += TrySetupData;

		private void OnDisable() => 
			_contentSetupEvent.ContentSetup -= TrySetupData;

		private void TrySetupData()
		{
			if(_isSet)
				return;

			SetupData();
		}


		private void SetupData()
		{
			ContentData contentData = _persistentProgressService.Progress.ContentData;

			_mainContentSprite.sprite = contentData.Sprite;
			_type = contentData.Type;
			_id = contentData.Id;

			NormalizeContentSprite();

			_isSet = true;
		}

		private void NormalizeContentSprite() => 
			HelperUtility.NumberSpriteNormalize(_type, _mainContentSprite.transform, _id);
	}
}
