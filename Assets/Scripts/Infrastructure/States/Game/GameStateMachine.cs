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

		private readonly Dictionary<Type, IState> _statesDictionary = new Dictionary<Type, IState>();
		private IState _activeState;

		public void Enter<TState>() where TState : IState
		{
			IState state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : IState =>
			_statesDictionary.Add(typeof(TState), state);
	}
}