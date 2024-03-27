using System.Collections.Generic;
using System.Threading.Tasks;
using CellContent;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using StaticData;
using UnityEngine;

namespace CellGrid
{
	public class CellGenerator
	{
		private readonly GameFactory _gameFactory;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly RandomService _randomService;

		public CellGenerator(GameFactory gameFactory, PersistentProgressService persistentProgressService, RandomService randomService)
		{
			_gameFactory = gameFactory;
			_persistentProgressService = persistentProgressService;
			_randomService = randomService;
		}

		public async Task CreateCell(int column, int row, float cellSize, Transform parentTransform)
		{
			List<ContentStaticData> content = _persistentProgressService.Progress.ContentData.CurrentContent;

			GameObject cellPrefab = await _gameFactory.CreateCell(parentTransform);

			SetupCellPosition(column, row, cellSize, cellPrefab);

			CreateContent(cellPrefab, content);
		}

		private void SetupCellPosition(int column, int row, float cellSize, GameObject cell)
		{
			float cellXPosition = column * cellSize;
			float cellYPosition = row * cellSize;

			cell.transform.position = new Vector2(cellXPosition, cellYPosition);
		}

		private async void CreateContent(GameObject cell, List<ContentStaticData> content)
		{
			ContentGenerator generator = new ContentGenerator(_persistentProgressService, _randomService, _gameFactory);
			await generator.GenerateContent(cell.transform, content);
		}
	}
}