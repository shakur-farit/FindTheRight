using CellLogic;
using Cysharp.Threading.Tasks;
using GridLogic.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace GridLogic
{
	public class GridGenerator : IGridGenerator
	{
		private int _rowsNumber;
		private int _columnsNumber;
		private float _cellSize;

		private Transform _gridTransform;

		private readonly IGridFactory _gridFactory;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly IBouncer _bouncer;
		private readonly ICellGenerator _cellGenerator;

		public GridGenerator(IGridFactory gridFactory, PersistentProgressService persistentProgressService,
			IBouncer bouncer, ICellGenerator cellGenerator)
		{
			_gridFactory = gridFactory;
			_persistentProgressService = persistentProgressService;
			_bouncer = bouncer;
			_cellGenerator = cellGenerator;
		}

		public async UniTask GenerateGrid(bool canAnimate)
		{
			await CreateGrid();
			ResetGridPosition();
			SetupGridData();

			for (int row = 0; row < _rowsNumber; row++)
				for (int column = 0; column < _columnsNumber; column++)
					await _cellGenerator.CreateCell(column, row, _cellSize, _gridTransform);

			RecenterGrid();

			Transform gridParent = SetParent();

			await TryAnimateGrid(canAnimate, gridParent);
		}

		private async UniTask CreateGrid() => 
			await _gridFactory.CreateGrid();

		private void SetupGridData()
		{
			_rowsNumber = _persistentProgressService.Progress.GridData.RowsNumber;
			_columnsNumber = _persistentProgressService.Progress.GridData.ColumnNumber;
			_cellSize = _persistentProgressService.Progress.GridData.CellSize;
			_gridTransform = _gridFactory.Grid.transform;
		}

		private void RecenterGrid()
		{
			float gridWidth = _columnsNumber * _cellSize;
			float gridHeight = _rowsNumber * _cellSize;

			_gridTransform.position = new Vector2(-gridWidth / 2f + _cellSize / 2f, -gridHeight / 2f + _cellSize / 2f);
		}

		private void ResetGridPosition() => 
			_gridFactory.Grid.transform.position = Vector2.zero;

		private Transform SetParent()
		{
			Transform gridParent = _gridFactory.GridParent;
			_gridTransform.SetParent(gridParent);
			return gridParent;
		}

		private async UniTask TryAnimateGrid(bool canAnimate, Transform gridParent)
		{
			if (canAnimate)
			{
				float scalingValue = 1.5f;
				float duration = 1f;

				await _bouncer.DoBounceEffect(gridParent, scalingValue, duration);
			}
		}
	}
}
