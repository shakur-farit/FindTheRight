using Infrastructure.Services.StaticData;
using System;
using System.Collections.Generic;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.States.Game;

namespace Infrastructure.States.LevelDifficultly
{
	public class LevelStateMachine
	{
		private readonly Dictionary<Type, IExitable> _statesDictionary;

		private IExitable _activeState;

		public LevelStateMachine(PersistentProgressService persistentProgressService, StaticDataService staticData,
			GameFactory gameFactory, GameStateMachine gameStateMachine, RandomService randomService, IBouncer bouncer)
		{
			_statesDictionary = new Dictionary<Type, IExitable>()
			{
				[typeof(EasyLevel)] = new EasyLevel(this, persistentProgressService, staticData, gameFactory, randomService, bouncer),
				[typeof(MediumLevel)] = new MediumLevel(this, persistentProgressService, staticData, gameFactory, randomService, bouncer),
				[typeof(HardLevel)] = new HardLevel(persistentProgressService, staticData, gameFactory, gameStateMachine, randomService, bouncer),
			};
		}

		public void Enter<TState>() where TState : IExitable
		{
			_activeState?.Exit();
			IExitable state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}
	}
}