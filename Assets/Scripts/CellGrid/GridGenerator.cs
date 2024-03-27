using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using System.Collections.Generic;
using CellContent;
using Infrastructure.Services.Animation;
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
		private readonly StaticDataService _staticDataService;
		private readonly RandomService _randomService;
		private readonly IBouncer _bouncer;

		public GridGenerator(GameFactory gameFactory, PersistentProgressService persistentProgressService, 
			StaticDataService staticDataService, RandomService randomService, IBouncer bouncer)
		{
			_gameFactory = gameFactory;
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
			_randomService = randomService;
			_bouncer = bouncer;
		}

		public void GenerateGrid(bool canAnimate)
		{
			CellGenerator generator = new CellGenerator(_gameFactory, _staticDataService,
				_persistentProgressService, _randomService);

			ResetGridPosition();
			SetupGridData();

			List<Content> content = GetRandomContent();

			for (int row = 0; row < _rowsNumber; row++)
				for (int column = 0; column < _columnsNumber; column++)
					generator.CreateCell(column, row, _cellSize, _gridTransform, content);

			RecenterGrid();

			if (canAnimate)
			{
				GameObject objectToBounce = new GameObject();
				_gridTransform.SetParent(objectToBounce.transform);

				_bouncer.DoBounceEffect(objectToBounce.transform, 1.5f, 1f);
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

		private List<Content> GetRandomContent()
		{
			ContentTypeRandomizer randomizer = new ContentTypeRandomizer(_staticDataService, _randomService);

			List<Content> currentContentList = randomizer.GetRandomContentList();

			return currentContentList;
		}
	}
}
