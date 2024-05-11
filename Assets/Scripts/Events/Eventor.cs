using System;

namespace Events
{
	public class Eventor : IGameRestartEvent, ILevelCompleteEvent, ISearchIntentChangeEvent, IContentSetupEvent, IGameStartEvent
	{
		public event Action GameStarted;
		public event Action ContentSetup;
		public event Action SearchIntentChanged;
		public event Action LevelCompleted;
		public event Action GameRestarted;

		public void CallGameStartedEvent() => 
			GameStarted?.Invoke();

		public void CallContentSetup() => 
			ContentSetup?.Invoke();

		public void CallSearchIntentChangedEvent() => 
			SearchIntentChanged?.Invoke();

		public void CallLevelCompleteEvent() => 
			LevelCompleted?.Invoke();

		public void CallGameRestartedEvent() => 
			GameRestarted?.Invoke();
	}
}
