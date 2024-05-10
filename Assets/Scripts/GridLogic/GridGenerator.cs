using System.Threading.Tasks;
using CellLogic;
using Cysharp.Threading.Tasks;
using GridLogic.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
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
		private readonly ICellGenerator _cellGenerator;
		private readonly IGridAnimator _gridAnimator;
		private readonly StaticDataService _staticDataService;
		private readonly IBouncer _bouncer;

		public GridGenerator(IGridFactory gridFactory, PersistentProgressService persistentProgressService,
			ICellGenerator cellGenerator, IGridAnimator gridAnimator, StaticDataService staticDataService, IBouncer bouncer)
		{
			_gridFactory = gridFactory;
			_persistentProgressService = persistentProgressService;
			_cellGenerator = cellGenerator;
			_gridAnimator = gridAnimator;
			_staticDataService = staticDataService;
			_bouncer = bouncer;
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

			Vector2 centeringFormula = new Vector2(-gridWidth / 2f + _cellSize / 2f, -gridHeight / 2f + _cellSize / 2f);
			_gridTransform.position = centeringFormula;
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
				await _gridAnimator.BounceGrid(gridParent);
		}
	}
}
