using System;

namespace Events
{
	public interface IGameRestartEvent
	{
		event Action GameRestarted;
		void CallGameRestartedEvent();
	}
}