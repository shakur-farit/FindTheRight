using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Infrastructure.States
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

		public void Exit()
		{
		}

		private void LoadProgressState() =>
			_gameStateMachine.Enter<LoadProgressState>();
	}
}