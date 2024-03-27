using System;
using UnityEngine;

namespace StaticEvents
{
	public static class StaticEventsHandler
	{
		public static event Action OnLevelComplete;
		public static event Action OnSearchIntentChanged;
		public static event Action OnStartedGamePlay;

		public static void CallLevelCompleteEvent() => 
			OnLevelComplete?.Invoke();

		public static void CallSearchIntentChangedEvent() => 
			OnSearchIntentChanged?.Invoke();

		public static void CallStartedGamePlayEvent() => 
			OnStartedGamePlay?.Invoke();
	}
}
