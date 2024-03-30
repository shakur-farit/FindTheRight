using Infrastructure.Services.PersistentProgress;
using StaticEvents;
using UI.Services.Window;
using UnityEngine;

namespace Infrastructure.States.Game
{
	public class GameCompleteState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly WindowService _windowService;
		private readonly PersistentProgressService _persistentProgressService;

		public GameCompleteState(GameStateMachine gameStateMachine, WindowService windowService, 
			PersistentProgressService persistentProgressService)
		{
			_gameStateMachine = gameStateMachine;
			_windowService = windowService;
			_persistentProgressService = persistentProgressService;
		}

		public async void Enter()
		{
			StaticEventsHandler.OnRestartedGame += RestartGame;

			Debug.Log("OpenWindow");
			await _windowService.Open(WindowId.GameComplete);

			ReturnClicks();
		}

		private void ReturnClicks() => 
			_persistentProgressService.Progress.ClickDetectorData.CanClick = false;

		private void RestartGame()
		{
			_gameStateMachine.Enter<LoadStaticDataState>();

			StaticEventsHandler.OnRestartedGame -= RestartGame;
		}
	}
}