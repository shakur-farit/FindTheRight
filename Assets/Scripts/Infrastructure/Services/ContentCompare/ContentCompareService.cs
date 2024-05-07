using CellContent;
using Events;
using FX;
using Infrastructure.Services.PersistentProgress;

namespace Infrastructure.Services.ContentCompare
{
	public class ContentCompareService
	{
		private readonly PersistentProgressService _persistentProgressService;
		private readonly ILevelCompleteEvent _levelCompleteEvent;
		private readonly IContentAnimator _contentAnimator;
		private readonly IFXCreator _fxCreator;

		public ContentCompareService(PersistentProgressService persistentProgressService, 
			ILevelCompleteEvent levelCompleteEvent, IContentAnimator contentAnimator, IFXCreator fxCreator)
		{
			_persistentProgressService = persistentProgressService;
			_levelCompleteEvent = levelCompleteEvent;
			_contentAnimator = contentAnimator;
			_fxCreator = fxCreator;
		}

		public async void Compare(Content content)
		{
			string searchIntent = _persistentProgressService.Progress.SearchIntentData.SearchIntent;

			if (content.Id == searchIntent)
			{
				await _fxCreator.CreateStarEffect(content.transform);
				await _contentAnimator.BounceContent(content.MainContentTransform);

				_levelCompleteEvent.CallLevelCompleteEvent();
			}
			else
			{
				_contentAnimator.DoShakeEffect(content.transform);
			}
		}
	}
}