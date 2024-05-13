using CellContent;
using Infrastructure.Services.ContentCompare;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace ClickDetector
{
	public class ClickDetector : MonoBehaviour
	{
		private Camera _camera;
		private bool _canClick;

		private ContentCompareService _contentCompareService;
		private PersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(ContentCompareService contentCompareService,
			PersistentProgressService persistentProgressService)
		{
			_contentCompareService = contentCompareService;
			_persistentProgressService = persistentProgressService;
		}

		void Update() =>
			TryClickContent();

		private void TryClickContent()
		{
			_canClick = _persistentProgressService.Progress.ClickDetectorData.CanClick;

			if (_canClick && Input.GetMouseButtonDown(0))
			{
				_camera = Camera.main;

				Vector2 clickPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
				Collider2D collider = Physics2D.OverlapPoint(clickPosition);

				if (collider != null && collider.TryGetComponent(out Content content))
					_contentCompareService.Compare(content);
			}
		}
	}
}
