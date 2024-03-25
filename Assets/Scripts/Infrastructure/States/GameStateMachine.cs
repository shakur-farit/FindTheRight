using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgressService;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticData;

namespace Infrastructure.States
{
	public class GameStateMachine
	{
		private readonly Dictionary<Type, IState> _statesDictionary;

		private IState _activeState;

		public GameStateMachine(StaticDataService staticDataService, GameFactory gameFactory,
			PersistentProgressService persistentProgressService, ILoadService loadService)
		{
			_statesDictionary = new Dictionary<Type, IState>()
			{
				[typeof(LoadStaticDataState)] = new LoadStaticDataState(this, staticDataService),
				[typeof(LoadProgressState)] = new LoadProgressState(this, persistentProgressService, loadService),
				[typeof(LoadSceneState)] = new LoadSceneState(gameFactory),
			};
		}

		public void Enter<TState>() where TState : IState
		{
			_activeState?.Exit();
			IState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}
	}
}