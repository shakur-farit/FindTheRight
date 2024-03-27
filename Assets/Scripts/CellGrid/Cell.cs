using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace CellGrid
{
	public class Cell : MonoBehaviour
	{
		private float _size;

		private PersistentProgressService _persistentProgressService;

		[Inject]
		public void Constructor(PersistentProgressService persistentProgressService) => 
			_persistentProgressService = persistentProgressService;

		private void Start() => 
			SetupCellSize();

		private void SetupCellSize()
		{
			_size = _persistentProgressService.Progress.LevelData.Level.CellSize;
			transform.localScale = new Vector2(_size, _size);
		}
	}
}
