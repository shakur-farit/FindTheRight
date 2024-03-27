using CellContent;
using CellGrid;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Game;
using SearchIntent;
using StaticData;
using StaticEvents;
using System.Collections.Generic;

namespace Infrastructure.States.LevelDifficultly
{
	public class HardLevel : IExitable
	{
		private const string LevelHard = "hard";

		private LevelStaticData _level;

		private readonly PersistentProgressService _persistentProgressService;
		private readonly StaticDataService _staticData;
		private readonly GameFactory _gameFactory;
		private readonly GameStateMachine _gameStateMachine;
		private readonly RandomService _randomService;
		private readonly IBouncer _bouncer;


		public HardLevel(PersistentProgressService persistentProgressService,
			StaticDataService staticData, GameFactory gameFactory, GameStateMachine gameStateMachine,
			RandomService randomService, IBouncer bouncer)
		{
			_persistentProgressService = persistentProgressService;
			_staticData = staticData;
			_gameFactory = gameFactory;
			_gameStateMachine = gameStateMachine;
			_randomService = randomService;
			_bouncer = bouncer;
		}

		public void Enter()
		{
			StaticEventsHandler.OnLevelComplete += EnterGameCompleteState;

			SetupLevel();
			SetupGridData();
			SetupContent();
			GenerateGrid();
			GenerateSearchIntent();
		}

		public void Exit() =>
			StaticEventsHandler.OnLevelComplete -= EnterGameCompleteState;

		private void EnterGameCompleteState()
		{
			_gameStateMachine.Enter<GameCompleteState>();

			Exit();
		}

		private void SetupLevel()
		{
			foreach (LevelStaticData level in _staticData.ForLevels)
			{
				if (level.LevelId == LevelHard)
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

		private void GenerateGrid()
		{
			GridGenerator generator = new GridGenerator(_gameFactory, _persistentProgressService, _randomService, _bouncer);
			generator.GenerateGrid(false);
		}

		private void GenerateSearchIntent()
		{
			SearchIntentGenerator generator = new SearchIntentGenerator(_randomService, _persistentProgressService);
			generator.GenerateSearchIntent();
		}
	}
}