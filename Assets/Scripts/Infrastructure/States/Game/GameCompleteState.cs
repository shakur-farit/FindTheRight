using Infrastructure.Services.PersistentProgress;
using StaticEvents;
using UI.Services.Window;

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

		public void Enter()
		{
			StaticEventsHandler.OnRestartedGame += RestartGame;

			_windowService.Open(WindowId.GameComplete);

			ReturnClicker();
		}

		private void ReturnClicker() => 
			_persistentProgressService.Progress.ClickDetectorData.CanClick = false;

		private void RestartGame()
		{
			_gameStateMachine.Enter<LoadStaticDataState>();

			StaticEventsHandler.OnRestartedGame -= RestartGame;
		}
	}
}