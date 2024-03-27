using StaticEvents;
using UI.Services.Window;

namespace Infrastructure.States.Game
{
	public class GameCompleteState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly WindowService _windowService;

		public GameCompleteState(GameStateMachine gameStateMachine, WindowService windowService)
		{
			_gameStateMachine = gameStateMachine;
			_windowService = windowService;
		}

		public void Enter()
		{
			StaticEventsHandler.OnStartedGamePlay += EnterGameLoopingSceneState;

			_windowService.Open(WindowId.GameComplete);
		}

		private void EnterGameLoopingSceneState()
		{
			_gameStateMachine.Enter<GameLoopingState>();

			StaticEventsHandler.OnStartedGamePlay -= EnterGameLoopingSceneState;
		}
	}
}