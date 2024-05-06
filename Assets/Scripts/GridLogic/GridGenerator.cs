using CellLogic;
using Cysharp.Threading.Tasks;
using GridLogic.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using UnityEngine;

namespace GridLogic
{
	public class GridGenerator : IGridGenerator
	{
		private int _rowsNumber;
		private int _columnsNumber;
		private float _cellSize;

		private Transform _gridTransform;

		private readonly IGridFactory _gameFactory;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly RandomService _randomService;
		private readonly IBouncer _bouncer;
		private readonly ICellGenerator _cellGenerator;

		public GridGenerator(IGridFactory gameFactory, PersistentProgressService persistentProgressService, RandomService randomService, 
			IBouncer bouncer, ICellGenerator cellGenerator)
		{
			_gameFactory = gameFactory;
			_persistentProgressService = persistentProgressService;
			_randomService = randomService;
			_bouncer = bouncer;
			_cellGenerator = cellGenerator;
		}

		public async UniTask GenerateGrid(bool canAnimate)
		{
			ResetGridPosition();
			SetupGridData();

			for (int row = 0; row < _rowsNumber; row++)
				for (int column = 0; column < _columnsNumber; column++)
					await _cellGenerator.CreateCell(column, row, _cellSize, _gridTransform);

			RecenterGrid();

			if (canAnimate)
			{
				float scalingValue = 1.5f;
				float duration = 1f;

				Transform gridParent = _gameFactory.GridParent;
				_gridTransform.SetParent(gridParent);

				await _bouncer.DoBounceEffect(gridParent, scalingValue, duration);
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
	}
}
