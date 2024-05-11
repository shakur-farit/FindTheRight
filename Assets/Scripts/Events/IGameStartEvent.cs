using System;

namespace Events
{
	public interface IGameStartEvent
	{
		event Action GameStarted;
		void CallGameStartedEvent();
	}
}