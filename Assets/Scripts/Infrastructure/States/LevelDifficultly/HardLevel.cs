using CellGrid;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Game;
using SearchIntent;
using StaticEvents;

namespace Infrastructure.States.LevelDifficultly
{
	public class HardLevel : IExitable
	{
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

			SetupGridData();
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

		private void SetupGridData()
		{
			_persistentProgressService.Progress.GridData.RowsNumber = _staticData.ForHardLevelGrid.RowsNumber;
			_persistentProgressService.Progress.GridData.ColumnNumber = _staticData.ForHardLevelGrid.ColumnsNumber;
			_persistentProgressService.Progress.GridData.CellSize = _staticData.ForHardLevelGrid.CellSize;
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
	}
}