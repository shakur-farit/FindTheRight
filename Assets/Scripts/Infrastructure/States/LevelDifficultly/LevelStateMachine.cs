using System;
using System.Collections.Generic;

namespace Infrastructure.States.LevelDifficultly
{
	public class LevelStateMachine
	{
		private readonly Dictionary<Type, IExitable> _statesDictionary = new Dictionary<Type, IExitable>();
		private IExitable _activeState;

		public void RegisterState<TState>(TState state) where TState : IExitable=>
			_statesDictionary.Add(typeof(TState), state);


		public void Enter<TState>() where TState : IExitable
		{
			_activeState?.Exit();
			IExitable state = _statesDictionary[typeof(TState)];
			_activeState = state;
			state.Enter();
		}
	}
}