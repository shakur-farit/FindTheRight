using System;

namespace Events
{
	public interface ILevelCompleteEvent
	{
		event Action LevelCompleted;
		void CallLevelCompleteEvent();
	}
}