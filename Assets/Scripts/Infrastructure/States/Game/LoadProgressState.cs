using Data;
using Infrastructure.Services.PersistentProgressService;
using Infrastructure.Services.SaveLoad;

namespace Infrastructure.States.Game
{
	public class LoadProgressState : IState
	{
		private readonly PersistentProgressService _progressService;
		private readonly GameStateMachine _gameStateMachine;
		private readonly ILoadService _loadService;

		public LoadProgressState(GameStateMachine gameStateMachine, PersistentProgressService progressService, 
			ILoadService loadService)
		{
			_gameStateMachine = gameStateMachine;
			_progressService = progressService;
			_loadService = loadService;
		}

		public void Enter()
		{
			LoadProgressOrInitNew();
			EnterLoadSceneState();
		}

		private void EnterLoadSceneState() => 
			_gameStateMachine.Enter<LoadSceneState>();

		public void Exit()
		{
		}

		private void LoadProgressOrInitNew() =>
			_progressService.Progress = _loadService.LoadProgress() ?? InitNewProgress();

		private Progress InitNewProgress() => 
			new Progress();
	}
}