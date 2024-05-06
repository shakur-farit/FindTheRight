using System;
using System.Collections.Generic;

namespace Infrastructure.States.Game
{
	public class GameStateMachine
	{

		private readonly Dictionary<Type, IState> _statesDictionary = new Dictionary<Type, IState>();

		public void Enter<TState>() where TState : IState
		{
			IState state = _statesDictionary[typeof(TState)];
			state.Enter();
		}

		public void RegisterState<TState>(TState state) where TState : IState =>
			_statesDictionary.Add(typeof(TState), state);
	}
}