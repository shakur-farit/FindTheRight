using Infrastructure.Factory;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace CellGrid
{
	public class GridGenerator : MonoBehaviour
	{
		private int _rowsNumber;
		private int _columnsNumber;
		private float _cellSize;

		private StaticDataService _staticDataService;
		private GameFactory _gameFactory;

		[Inject]
		public void Constructor(StaticDataService staticDataService, GameFactory gameFactory)
		{
			_staticDataService = staticDataService;
			_gameFactory = gameFactory;
		}

		private void Start()
		{
			_rowsNumber = _staticDataService.ForGrid.RowsNumber;
			_columnsNumber = _staticDataService.ForGrid.ColumnsNumber;
			_cellSize = _staticDataService.ForGrid.CellSize;

			GenerateGrid();
		}

		private void GenerateGrid()
		{
			for (int row = 0; row < _rowsNumber; row++)
			{
				for (int column = 0; column < _columnsNumber; column++)
				{
					GameObject cell = _gameFactory.CreateCell(transform);


					float cellXPosition = column * _cellSize;
					float cellYPosition = row * -_cellSize;

					cell.transform.position = new Vector2(cellXPosition, cellYPosition);
				}
			}

			float gridWidth = _columnsNumber * _cellSize;
			float gridHeight = _rowsNumber * _cellSize;

			transform.position = new Vector2(-gridWidth / 2 + _cellSize / 2, gridHeight / 2 - _cellSize / 2);
		}
	}
}
