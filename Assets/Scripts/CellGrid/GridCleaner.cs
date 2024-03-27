using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CellGrid
{
	public class GridCleaner
	{
		private readonly GameFactory _gameFactory;
		private readonly PersistentProgressService _persistentProgressService;

		public GridCleaner(GameFactory gameFactory, PersistentProgressService persistentProgressService)
		{
			_gameFactory = gameFactory;
			_persistentProgressService = persistentProgressService;
		}

		public void Clean()
		{
			GameObject grid = _gameFactory.Grid;

			for (int i = 0; i < grid.transform.childCount; i++)
			{
				Transform cell = grid.transform.GetChild(i);
				Object.Destroy(cell.gameObject);
			}

			CleanUsedOnLevelContentList();
		}

		private void CleanUsedOnLevelContentList() => 
			_persistentProgressService.Progress.ContentData.UsedInLevel.Clear();
	}
}