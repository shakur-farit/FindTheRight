using System;

namespace Events
{
	public interface IContentSetupEvent
	{
		event Action ContentSetup;
		void CallContentSetup();
	}
}