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

			await _windowService.Open(WindowId.GameComplete);

			ReturnClicker();

			Debug.Log("Enter in Conplete");
		}

		private void ReturnClicker() => 
			_persistentProgressService.Progress.ClickDetectorData.CanClick = false;

		private void RestartGame()
		{
			Debug.Log("Restatr");


			_gameStateMachine.Enter<LoadStaticDataState>();

			StaticEventsHandler.OnRestartedGame -= RestartGame;
		}
	}
}