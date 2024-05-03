using Infrastructure.Services.PersistentProgress;
using StaticEvents;
using UI.Services.Factory;
using UI.Services.Window;
using UI.Windows;

namespace Infrastructure.States.Game
{
	public class GameCompleteState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly WindowService _windowService;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly UIFactory _uiFactory;

		public GameCompleteState(GameStateMachine gameStateMachine, WindowService windowService, 
			PersistentProgressService persistentProgressService, UIFactory uiFactory)
		{
			_gameStateMachine = gameStateMachine;
			_windowService = windowService;
			_persistentProgressService = persistentProgressService;
			_uiFactory = uiFactory;
		}

		public async void Enter()
		{
			StaticEventsHandler.CallDebug("GameComp");

			StaticEventsHandler.OnRestartedGame += RestartGame;

			await _windowService.Open(WindowId.GameComplete);
			await _uiFactory.GameCompleteWindow.GetComponent<WindowAnimator>().DoFadeIn();

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