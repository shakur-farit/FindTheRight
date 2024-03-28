using System.Threading.Tasks;
using CellContent;
using FX;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using StaticEvents;

namespace Infrastructure.Services.ContentCompare
{
	public class ContentCompareService
	{
		private const float ScalingValue = 1.3f;
		private const float Duration = 0.5f;

		private readonly PersistentProgressService _persistentProgressService;
		private readonly FXFactory _fxFactory;
		private readonly AnimationService _animationService;

		public ContentCompareService(PersistentProgressService persistentProgressService, FXFactory fxFactory, AnimationService animationService)
		{
			_persistentProgressService = persistentProgressService;
			_fxFactory = fxFactory;
			_animationService = animationService;
		}

		public async void Compare(Content content)
		{
			string searchIntent = _persistentProgressService.Progress.SearchIntentData.SearchIntent;

			ContentAnimator animator = content.GetComponent<ContentAnimator>();

			if (content.ContentId == searchIntent)
			{
				await CreateStarEffect(content);

				await BounceContent(content,ScalingValue,Duration);

				StaticEventsHandler.CallLevelCompleteEvent();
			}
			else
			{
				animator.DoShakeEffect();
			}
		}

		private async Task BounceContent(Content content, float scalingValue, float duration) => 
			await _animationService.DoBounceEffect(content.Transform, scalingValue, duration);

		private async Task CreateStarEffect(Content content)
		{
			await _fxFactory.CreateStarFx();
			_fxFactory.StarFx.transform.position = content.transform.position;
		}
	}
}