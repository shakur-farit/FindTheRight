using CellGrid;
using FX;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using SearchIntent;
using StaticEvents;

namespace Infrastructure.States.LevelDifficultly
{
	public class EasyLevel : IExitable
	{
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

			SetupGridData();
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

		private void SetupGridData()
		{
			_persistentProgressService.Progress.GridData.RowsNumber = _staticData.ForEasyLevelGrid.RowsNumber;
			_persistentProgressService.Progress.GridData.ColumnNumber= _staticData.ForEasyLevelGrid.ColumnsNumber;
			_persistentProgressService.Progress.GridData.CellSize= _staticData.ForEasyLevelGrid.CellSize;
		}

		private void GenerateGrid()
		{
			GridGenerator generator = new GridGenerator(_gameFactory, _persistentProgressService, 
				_staticData, _randomService, _bouncer);
			generator.GenerateGrid(true);
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