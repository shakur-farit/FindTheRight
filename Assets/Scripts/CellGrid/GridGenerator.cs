using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgressService;
using UnityEngine;

namespace CellGrid
{
	public class GridGenerator
	{
		private int _rowsNumber;
		private int _columnsNumber;
		private float _cellSize;

		private Transform _parentTransform;

		private readonly GameFactory _gameFactory;
		private readonly PersistentProgressService _persistentProgressService;

		public GridGenerator(GameFactory gameFactory, PersistentProgressService persistentProgressService)
		{
			_gameFactory = gameFactory;
			_persistentProgressService = persistentProgressService;
		}

		public void GenerateGrid()
		{
			SetupGridData();

			for (int row = 0; row < _rowsNumber; row++)
				for (int column = 0; column < _columnsNumber; column++) 
					CreateCell(column, row);

			RecenterGrid();
		}

		private void SetupGridData()
		{
			_rowsNumber = _persistentProgressService.Progress.GridData.RowsNumber;
			_columnsNumber = _persistentProgressService.Progress.GridData.ColumnNumber;
			_cellSize = _persistentProgressService.Progress.GridData.CellSize;
			_parentTransform = _gameFactory.Grid.transform;
		}

		private void CreateCell(int column, int row)
		{
			GameObject cell = _gameFactory.CreateCell(_parentTransform);

			float cellXPosition = column * _cellSize;
			float cellYPosition = row * -_cellSize;

			cell.transform.position = new Vector2(cellXPosition, cellYPosition);
		}

		private void RecenterGrid()
		{
			float gridWidth = _columnsNumber * _cellSize;
			float gridHeight = _rowsNumber * _cellSize;

			_parentTransform.position = new Vector2(-gridWidth / 2 + _cellSize / 2, gridHeight / 2 - _cellSize / 2);
		}
	}
}
