using System;
using System.Collections.Generic;
using FX;
using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using UI.Services.Factory;
using UI.Services.Window;

namespace Infrastructure.States.Game
{
	public class GameStateMachine
	{
		private readonly Dictionary<Type, IState> _statesDictionary;

		public GameStateMachine(StaticDataService staticDataService, GameFactory gameFactory, UIFactory uiFactory,
			PersistentProgressService persistentProgressService, RandomService randomService,
			WindowService windowService, IBouncer bouncer, Assets assets, FXFactory fxFactory)
		{
			_statesDictionary = new Dictionary<Type, IState>()
			{
				[typeof(LoadStaticDataState)] = new LoadStaticDataState(this, staticDataService),
				[typeof(LoadProgressState)] = new LoadProgressState(this, persistentProgressService, staticDataService),
				[typeof(LoadSceneState)] = new LoadSceneState(this, gameFactory, uiFactory, assets, fxFactory),
				[typeof(GameLoopingState)] = new GameLoopingState(this, persistentProgressService, staticDataService, 
					gameFactory, randomService, bouncer),
				[typeof(GameCompleteState)] = new GameCompleteState(this, windowService, persistentProgressService, uiFactory)
			};
		}

		public void Enter<TState>() where TState : IState
		{
			IState state = _statesDictionary[typeof(TState)];
			state.Enter();
		}
	}
}