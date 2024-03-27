using Infrastructure.Services.StaticData;

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

		public void Enter()
		{
			_staticDataService.Load();

			LoadProgressState();
		}

		private void LoadProgressState() =>
			_gameStateMachine.Enter<LoadProgressState>();
	}
}