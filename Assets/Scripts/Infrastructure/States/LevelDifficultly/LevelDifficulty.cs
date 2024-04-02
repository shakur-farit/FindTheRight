using System.Collections.Generic;
using CellContent;
using CellGrid;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using SearchIntent;
using StaticData;
using StaticEvents;

namespace Infrastructure.States.LevelDifficultly
{
	public abstract class LevelDifficulty
	{
		protected string LevelId;
		protected bool CanAnimateGrid;
		protected LevelStaticData DifficultyLevel;

		protected readonly StaticDataService StaticData;
		protected readonly PersistentProgressService PersistentProgressService;
		protected readonly RandomService RandomService;
		protected readonly GameFactory GameFactory;
		protected readonly IBouncer Bouncer;
		
		protected LevelDifficulty(StaticDataService staticData, PersistentProgressService persistentProgressService,
			RandomService randomService, GameFactory gameFactory, IBouncer bouncer)
		{
			StaticData = staticData;
			PersistentProgressService = persistentProgressService;
			RandomService = randomService;
			GameFactory = gameFactory;
			Bouncer = bouncer;
		}

		public void Enter()
		{
			StaticEventsHandler.OnLevelComplete += EnterNextState;

			SetupLevelData();
			SetupLevel(LevelId);
			SetupGridData();
			SetupContent();
			GenerateGrid(CanAnimateGrid);
			GenerateSearchIntent();
		}

		protected abstract void EnterNextState();

		protected abstract void SetupLevelData();

		private void SetupLevel(string levelId)
		{
			foreach (LevelStaticData level in StaticData.ForLevels.LevelstList)
			{
				if (level.LevelId.ToUpper() == levelId.ToUpper())
				{
					PersistentProgressService.Progress.LevelData.Level = level;
					DifficultyLevel = level;
				}
			}
		}

		private void SetupGridData()
		{
			PersistentProgressService.Progress.GridData.RowsNumber = DifficultyLevel.RowsNumber;
			PersistentProgressService.Progress.GridData.ColumnNumber = DifficultyLevel.ColumnsNumber;
			PersistentProgressService.Progress.GridData.CellSize = DifficultyLevel.CellSize;
		}

		private void SetupContent()
		{
			ContentTypeRandomizer randomizer = new ContentTypeRandomizer(PersistentProgressService, RandomService);
			List<ContentStaticData> currentContent = randomizer.GetRandomContentList();
			PersistentProgressService.Progress.ContentData.CurrentContent = currentContent;
		}

		private async void GenerateGrid(bool canAnimate)
		{
			GridGenerator generator = new GridGenerator(GameFactory, PersistentProgressService, RandomService, Bouncer);
			await generator.GenerateGrid(canAnimate);
		}

		private void GenerateSearchIntent()
		{
			SearchIntentGenerator generator = new SearchIntentGenerator(RandomService, PersistentProgressService);
			generator.GenerateSearchIntent();
		}
	}
}