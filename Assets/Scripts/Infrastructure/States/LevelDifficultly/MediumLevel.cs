using Infrastructure.Services.PersistentProgressService;
using Infrastructure.Services.StaticData;
using StaticEvents;
using UnityEngine;

namespace Infrastructure.States.LevelDifficultly
{
	internal class MediumLevel : IState
	{
		private readonly PersistentProgressService _persistentProgressService;
		private readonly StaticDataService _staticData;
		private readonly LevelStateMachine _levelStateMachine;

		public MediumLevel(LevelStateMachine levelStateMachine, PersistentProgressService persistentProgressService, 
			StaticDataService staticData)
		{
			_persistentProgressService = persistentProgressService;
			_staticData = staticData;
			_levelStateMachine = levelStateMachine;

		}

		public void Enter()
		{
			StaticEventsHandler.OnLevelComplete += EnterHardLevelState;

			SetupGridData();
		}

		public void Exit() =>
			StaticEventsHandler.OnLevelComplete -= EnterHardLevelState;

		private void SetupGridData()
		{
			_persistentProgressService.Progress.GridData.RowsNumber = _staticData.ForMediumLevelGrid.RowsNumber;
			_persistentProgressService.Progress.GridData.ColumnNumber = _staticData.ForMediumLevelGrid.ColumnsNumber;
			_persistentProgressService.Progress.GridData.CellSize = _staticData.ForMediumLevelGrid.CellSize;
		}


		private void EnterHardLevelState() =>
			Debug.Log("Enter to Hard");
		//_levelStateMachine.Enter<MediumLevel>();
	}
}