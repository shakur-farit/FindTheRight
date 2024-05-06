using System;

namespace Events
{
	public interface ISearchIntentChangeEvent
	{
		event Action SearchIntentChanged;
		void CallSearchIntentChangedEvent();
	}
}