using System;

namespace Events
{
	public class Eventer : IGameRestartEvent, ILevelCompleteEvent, ISearchIntentChangeEvent
	{
		public event Action RestartedGame;
		public event Action LevelCompleted;
		public event Action SearchIntentChanged;

		public void CallLevelCompleteEvent() => 
			LevelCompleted?.Invoke();

		public void CallSearchIntentChangedEvent() => 
			SearchIntentChanged?.Invoke();

		public void CallRestartedGameEvent() => 
			RestartedGame?.Invoke();
	}
}
