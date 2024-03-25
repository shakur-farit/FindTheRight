using CellGrid;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgressService;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;

namespace Infrastructure.States.LevelDifficultly
{
	public class EasyLevel : IState
	{
		private readonly PersistentProgressService _persistentProgressService;
		private readonly StaticDataService _staticData;
		private readonly LevelStateMachine _levelStateMachine;
		private readonly GameFactory _gameFactory;

		public EasyLevel(LevelStateMachine levelStateMachine,PersistentProgressService persistentProgressService, 
			StaticDataService staticData, GameFactory gameFactory)
		{
			_persistentProgressService = persistentProgressService;
			_staticData = staticData;
			_gameFactory = gameFactory;
			_levelStateMachine = levelStateMachine;
		}

		public void Enter()
		{
			StaticEventsHandler.OnLevelComplete += EnterMediumLevelState;

			SetupGridData();
			GenerateGrid();
		}

		public void Exit() => 
			StaticEventsHandler.OnLevelComplete -= EnterMediumLevelState;

		private void GenerateGrid()
		{
			GridGenerator generator = new GridGenerator(_gameFactory, _persistentProgressService);
			generator.GenerateGrid();
		}

		private void SetupGridData()
		{
			_persistentProgressService.Progress.GridData.RowsNumber = _staticData.ForEasyLevelGrid.RowsNumber;
			_persistentProgressService.Progress.GridData.ColumnNumber= _staticData.ForEasyLevelGrid.ColumnsNumber;
			_persistentProgressService.Progress.GridData.CellSize= _staticData.ForEasyLevelGrid.CellSize;
		}

		private void EnterMediumLevelState() => 
			_levelStateMachine.Enter<MediumLevel>();
	}
}