using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace CellGrid
{
	public class Cell : MonoBehaviour
	{
		private float _size;

		private StaticDataService _staticDataService;

		[Inject]
		public void Constructor(StaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		private void Start() => 
			SetupCellSize();

		private void SetupCellSize()
		{
			_size = _staticDataService.ForGrid.CellSize;
			transform.localScale = new Vector2(_size, _size);
		}
	}
}
