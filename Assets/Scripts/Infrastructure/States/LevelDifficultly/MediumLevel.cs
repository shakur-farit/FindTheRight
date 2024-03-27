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
using System.Collections.Generic;

namespace Infrastructure.States.LevelDifficultly
{
	internal class MediumLevel : IExitable
	{
		private const string LevelMedium = "medium";

		private LevelStaticData _level;

		private readonly PersistentProgressService _persistentProgressService;
		private readonly StaticDataService _staticData;
		private readonly LevelStateMachine _levelStateMachine;
		private readonly GameFactory _gameFactory;
		private readonly RandomService _randomService;
		private readonly IBouncer _bouncer;


		public MediumLevel(LevelStateMachine levelStateMachine, PersistentProgressService persistentProgressService, 
			StaticDataService staticData, GameFactory gameFactory, RandomService randomService, IBouncer bouncer)
		{
			_persistentProgressService = persistentProgressService;
			_staticData = staticData;
			_gameFactory = gameFactory;
			_randomService = randomService;
			_bouncer = bouncer;
			_levelStateMachine = levelStateMachine;
		}

		public void Enter()
		{
			StaticEventsHandler.OnLevelComplete += EnterHardLevelState;

			SetupLevel();
			SetupGridData();
			SetupContent();
			GenerateGrid();
			GenerateSearchIntent();
		}

		public void Exit()
		{
			StaticEventsHandler.OnLevelComplete -= EnterHardLevelState;

			CleanGird();
		}

		private void EnterHardLevelState() =>
		_levelStateMachine.Enter<HardLevel>();

		private void SetupLevel()
		{
			foreach (LevelStaticData level in _staticData.ForLevels)
			{
				if (level.LevelId == LevelMedium)
				{
					_persistentProgressService.Progress.LevelData.Level = level;
					_level = level;
				}
			}
		}

		private void SetupGridData()
		{
			_persistentProgressService.Progress.GridData.RowsNumber = _level.RowsNumber;
			_persistentProgressService.Progress.GridData.ColumnNumber = _level.ColumnsNumber;
			_persistentProgressService.Progress.GridData.CellSize = _level.CellSize;
		}

		private void SetupContent()
		{
			ContentTypeRandomizer randomizer = new ContentTypeRandomizer(_persistentProgressService, _randomService);
			List<ContentStaticData> currentContent = randomizer.GetRandomContentList();
			_persistentProgressService.Progress.ContentData.CurrentContent = currentContent;
		}

		private async void GenerateGrid()
		{
			GridGenerator generator = new GridGenerator(_gameFactory, _persistentProgressService, _randomService, _bouncer);
			await generator.GenerateGrid(false);
		}

		private void GenerateSearchIntent()
		{
			SearchIntentGenerator generator = new SearchIntentGenerator(_randomService, _persistentProgressService);
			generator.GenerateSearchIntent();
		}

		private void CleanGird()
		{
			GridCleaner cleaner = new GridCleaner(_gameFactory, _persistentProgressService);
			cleaner.Clean();
		}
	}
}