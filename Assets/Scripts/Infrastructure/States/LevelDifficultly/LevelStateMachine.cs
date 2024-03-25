using Infrastructure.Services.StaticData;
using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgressService;

namespace Infrastructure.States.LevelDifficultly
{
	public class LevelStateMachine
	{
		private readonly Dictionary<Type, IState> _statesDictionary;

		private IState _activeState;

		public LevelStateMachine(PersistentProgressService persistentProgressService, StaticDataService staticData,
			GameFactory gameFactory)
		{
			_statesDictionary = new Dictionary<Type, IState>()
			{
				[typeof(EasyLevel)] = new EasyLevel(this, persistentProgressService, staticData, gameFactory),
				[typeof(MediumLevel)] = new MediumLevel(this, persistentProgressService, staticData)
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