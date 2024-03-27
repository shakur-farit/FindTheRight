using CellGrid;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using SearchIntent;
using StaticEvents;

namespace Infrastructure.States.LevelDifficultly
{
	internal class MediumLevel : IExitable
	{
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

			SetupGridData();
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

		private void SetupGridData()
		{
			_persistentProgressService.Progress.GridData.RowsNumber = _staticData.ForMediumLevelGrid.RowsNumber;
			_persistentProgressService.Progress.GridData.ColumnNumber = _staticData.ForMediumLevelGrid.ColumnsNumber;
			_persistentProgressService.Progress.GridData.CellSize = _staticData.ForMediumLevelGrid.CellSize;
		}

		private void GenerateGrid()
		{
			GridGenerator generator = new GridGenerator(_gameFactory, _persistentProgressService,
				_staticData, _randomService, _bouncer);
			generator.GenerateGrid(false);
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