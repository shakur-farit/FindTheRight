using System.Collections.Generic;
using CellContent;
using CellLogic.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.PersistentProgress;
using StaticData;
using UnityEngine;

namespace CellLogic
{
	public class CellGenerator : ICellGenerator
	{
		private readonly ICellFactory _cellFactory;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly IContentGenerator _contentGenerator;

		public CellGenerator(ICellFactory cellFactory, PersistentProgressService persistentProgressService, IContentGenerator contentGenerator)
		{
			_cellFactory = cellFactory;
			_persistentProgressService = persistentProgressService;
			_contentGenerator = contentGenerator;
		}

		public async UniTask CreateCell(int column, int row, float cellSize, Transform parentTransform)
		{
			List<ContentStaticData> content = _persistentProgressService.Progress.ContentData.CurrentContent;

			GameObject cellPrefab = await _cellFactory.CreateCell(parentTransform);
			SetupCellPosition(column, row, cellSize, cellPrefab);

			CreateContent(cellPrefab, content);
		}

		private void SetupCellPosition(int column, int row, float cellSize, GameObject cell)
		{
			float cellXPosition = column * cellSize;
			float cellYPosition = row * cellSize;

			cell.transform.position = new Vector2(cellXPosition, cellYPosition);
		}

		private async void CreateContent(GameObject cell, List<ContentStaticData> content) => 
			await _contentGenerator.GenerateContent(cell.transform, content);
	}
}