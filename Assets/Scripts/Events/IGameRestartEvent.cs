using System;

namespace Events
{
	public interface IGameRestartEvent
	{
		event Action RestartedGame;
		void CallRestartedGameEvent();
	}
}