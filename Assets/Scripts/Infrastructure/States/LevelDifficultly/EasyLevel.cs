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
	public class EasyLevel : IExitable
	{
		private const string LevelEasy = "easy";

		private LevelStaticData _level;

		private readonly PersistentProgressService _persistentProgressService;
		private readonly StaticDataService _staticData;
		private readonly LevelStateMachine _levelStateMachine;
		private readonly GameFactory _gameFactory;
		private readonly RandomService _randomService;
		private readonly IBouncer _bouncer;

		public EasyLevel(LevelStateMachine levelStateMachine,PersistentProgressService persistentProgressService, 
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
			StaticEventsHandler.OnLevelComplete += EnterMediumLevelState;

			SetupLevel();
			SetupGridData();
			SetupContent(); 
			GenerateGrid();
			GenerateSearchIntent();
		}

		public void Exit()
		{
			StaticEventsHandler.OnLevelComplete -= EnterMediumLevelState;

			CleanGird();
		}

		private void EnterMediumLevelState() => 
			_levelStateMachine.Enter<MediumLevel>();

		private void SetupLevel()
		{
			foreach (LevelStaticData level in _staticData.ForLevels)
			{
				if (level.LevelId == LevelEasy)
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
			await generator.GenerateGrid(true);
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