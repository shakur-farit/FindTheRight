using CellContent;
using FX;
using Infrastructure.Services.PersistentProgress;
using StaticEvents;

namespace Infrastructure.Services.ContentCompare
{
	public class ContentCompareService
	{
		private readonly PersistentProgressService _persistentProgressService;
		private readonly FXFactory _fxFactory;

		public ContentCompareService(PersistentProgressService persistentProgressService, FXFactory fxFactory)
		{
			_persistentProgressService = persistentProgressService;
			_fxFactory = fxFactory;
		}

		public void Compare(Content content)
		{
			string searchIntent = _persistentProgressService.Progress.SearchIntentData.SearchIntent;

			ContentAnimator animator = content.GetComponent<ContentAnimator>();

			if (content.ContentId == searchIntent)
			{
				_fxFactory.CreateStarFx();
				_fxFactory.StarFx.transform.position = content.transform.position;

				StaticEventsHandler.CallLevelCompleteEvent();
			}
			else
			{
				animator.DoShakeEffect();
			}
	
		}
	}
}