using CellContent;
using Infrastructure.Services.ContentCompare;
using UnityEngine;
using Zenject;

namespace ClickDetector
{
	public class ClickDetector : MonoBehaviour
	{
		private Camera _camera;

		private ContentCompareService _contentCompareService;

		[Inject]
		public void Constructor(ContentCompareService contentCompareService) => 
			_contentCompareService = contentCompareService;

		void Update() =>
			TryClickContent();

		private void TryClickContent()
		{
			if (Input.GetMouseButtonDown(0))
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
