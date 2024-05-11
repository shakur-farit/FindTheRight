using System.Threading.Tasks;
using Events;
using UI.Services.Window;

namespace Infrastructure.States.Game
{
	public class MainMenuState : IState
	{
		private readonly WindowService _windowsService;
		private readonly IGameStartEvent _eventor;
		private readonly GameStateMachine _gameStateMachine;

		public MainMenuState(WindowService windowsService, IGameStartEvent eventor, GameStateMachine gameStateMachine)
		{
			_windowsService = windowsService;
			_eventor = eventor;
			_gameStateMachine = gameStateMachine;
		}

		public async void Enter()
		{
			_eventor.GameStarted += EnterInGamePlayLoopState;

			await OpenMainMenuWindow();
		}

		private async Task OpenMainMenuWindow() => 
			await _windowsService.Open(WindowId.MainMenu);

		private void EnterInGamePlayLoopState() => 
			_gameStateMachine.Enter<GamePlayLoopState>();
	}
}