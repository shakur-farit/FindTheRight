using System;

namespace Events
{
	public class Eventer : IGameRestartEvent, ILevelCompleteEvent, ISearchIntentChangeEvent, IContentSetupEvent
	{
		public event Action GameRestarted;
		public event Action LevelCompleted;
		public event Action SearchIntentChanged;
		public event Action ContentSetup;

		public void CallLevelCompleteEvent() => 
			LevelCompleted?.Invoke();

		public void CallSearchIntentChangedEvent() => 
			SearchIntentChanged?.Invoke();

		public void CallGameRestartedEvent() => 
			GameRestarted?.Invoke();

		public void CallContentSetup() => 
			ContentSetup?.Invoke();
	}
}
