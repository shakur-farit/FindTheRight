using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;

namespace Infrastructure.States.Game
{
	public class LoadStaticDataState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly StaticDataService _staticDataService;
		private readonly PersistentProgressService _persistentProgressService;

		public LoadStaticDataState(GameStateMachine gameStateMachine, StaticDataService staticDataService, PersistentProgressService persistentProgressService)
		{
			_gameStateMachine = gameStateMachine;
			_staticDataService = staticDataService;
			_persistentProgressService = persistentProgressService;
		}

		public async void Enter()
		{
			await _staticDataService.Load();

			LoadProgressState();
		}

		private void LoadProgressState() =>
			_gameStateMachine.Enter<LoadProgressState>();
	}
}