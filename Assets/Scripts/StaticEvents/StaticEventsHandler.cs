using System;

namespace StaticEvents
{
	public static class StaticEventsHandler
	{
		public static event Action OnRestartedGame;
		public static event Action OnLevelComplete;
		public static event Action OnSearchIntentChanged;
		public static event Action<string> OnDebug;


		public static void CallLevelCompleteEvent() => 
			OnLevelComplete?.Invoke();

		public static void CallSearchIntentChangedEvent() => 
			OnSearchIntentChanged?.Invoke();

		public static void CallRestartGameEvent() => 
			OnRestartedGame?.Invoke();

		public static void CallOnDebug(string text) => 
			OnDebug?.Invoke(text);
	}
}
