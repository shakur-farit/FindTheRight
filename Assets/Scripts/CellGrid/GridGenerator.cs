using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using System.Collections.Generic;
using System.Threading.Tasks;
using CellContent;
using Infrastructure.Services.Animation;
using StaticData;
using UnityEngine;

namespace CellGrid
{
	public class GridGenerator
	{
		private int _rowsNumber;
		private int _columnsNumber;
		private float _cellSize;

		private Transform _gridTransform;

		private readonly GameFactory _gameFactory;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly RandomService _randomService;
		private readonly IBouncer _bouncer;

		public GridGenerator(GameFactory gameFactory, PersistentProgressService persistentProgressService, RandomService randomService, IBouncer bouncer)
		{
			_gameFactory = gameFactory;
			_persistentProgressService = persistentProgressService;
			_randomService = randomService;
			_bouncer = bouncer;
		}

		public async Task GenerateGrid(bool canAnimate)
		{
			CellGenerator generator = new CellGenerator(_gameFactory ,_persistentProgressService, _randomService);

			ResetGridPosition();
			SetupGridData();

			for (int row = 0; row < _rowsNumber; row++)
				for (int column = 0; column < _columnsNumber; column++)
					await generator.CreateCell(column, row, _cellSize, _gridTransform);

			RecenterGrid();

			if (canAnimate)
			{
				GameObject objectToBounce = new GameObject();
				_gridTransform.SetParent(objectToBounce.transform);

				await _bouncer.DoBounceEffect(objectToBounce.transform, 1.5f, 1f);
			}
		}

		private void SetupGridData()
		{
			_rowsNumber = _persistentProgressService.Progress.GridData.RowsNumber;
			_columnsNumber = _persistentProgressService.Progress.GridData.ColumnNumber;
			_cellSize = _persistentProgressService.Progress.GridData.CellSize;
			_gridTransform = _gameFactory.Grid.transform;
		}

		private void RecenterGrid()
		{
			float gridWidth = _columnsNumber * _cellSize;
			float gridHeight = _rowsNumber * _cellSize;

			_gridTransform.position = new Vector2(-gridWidth / 2 + _cellSize / 2, -gridHeight / 2f + _cellSize / 2);
		}

		private void ResetGridPosition() => 
			_gameFactory.Grid.transform.position = Vector2.zero;

		private List<ContentStaticData> GetRandomContent()
		{
			ContentTypeRandomizer randomizer = new ContentTypeRandomizer(_persistentProgressService, _randomService);

			List<ContentStaticData> currentContentList = randomizer.GetRandomContentList();

			return currentContentList;
		}
	}
}
