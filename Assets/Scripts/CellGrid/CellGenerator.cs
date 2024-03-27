using System.Collections.Generic;
using CellContent;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace CellGrid
{
	public class CellGenerator
	{
		private readonly GameFactory _gameFactory;
		private readonly StaticDataService _staticDataService;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly RandomService _randomService;

		public CellGenerator(GameFactory gameFactory, StaticDataService staticDataService, 
			PersistentProgressService persistentProgressService, RandomService randomService)
		{
			_gameFactory = gameFactory;
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
			_randomService = randomService;
		}

		public void CreateCell(int column, int row, float cellSize, Transform parentTransform,
			List<Content> content)
		{
			GameObject cellPrefab = _gameFactory.CreateCell(parentTransform);

			SetupCellPosition(column, row, cellSize, cellPrefab);

			CreateContent(cellPrefab, content);
		}

		private void SetupCellPosition(int column, int row, float cellSize, GameObject cell)
		{
			float cellXPosition = column * cellSize;
			float cellYPosition = row * cellSize;

			cell.transform.position = new Vector2(cellXPosition, cellYPosition);
		}

		private void CreateContent(GameObject cell, List<Content> content)
		{
			ContentGenerator generator =
				new ContentGenerator(_staticDataService, _persistentProgressService, _randomService, _gameFactory);
			generator.GenerateContent(cell.transform, content);
		}
	}
}