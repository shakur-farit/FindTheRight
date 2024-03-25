using System;

namespace StaticEvents
{
	public static class StaticEventsHandler
	{
		public static event Action OnLevelComplete;

		public static void CallLevelCompleteEvent() => 
			OnLevelComplete?.Invoke();
	}
}
