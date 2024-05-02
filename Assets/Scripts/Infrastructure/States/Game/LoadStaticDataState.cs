using Infrastructure.Services.StaticData;
using StaticEvents;

namespace Infrastructure.States.Game
{
	public class LoadStaticDataState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly StaticDataService _staticDataService;

		public LoadStaticDataState(GameStateMachine gameStateMachine, StaticDataService staticDataService)
		{
			_gameStateMachine = gameStateMachine;
			_staticDataService = staticDataService;
		}

		public async void Enter()
		{
			await _staticDataService.Load();

			LoadProgressState();

			StaticEventsHandler.CallOnDebug("Load Static Data");
		}

		private void LoadProgressState() =>
			_gameStateMachine.Enter<LoadProgressState>();
	}
}