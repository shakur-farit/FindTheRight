using CellContent;
using Cysharp.Threading.Tasks;
using Events;
using FX;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;

namespace Infrastructure.Services.ContentCompare
{
	public class ContentCompareService
	{
		private const float ScalingValue = 1.3f;
		private const float Duration = 0.5f;

		private readonly PersistentProgressService _persistentProgressService;
		private readonly IFXFactory _fxFactory;
		private readonly AnimationService _animationService;
		private readonly ILevelCompleteEvent _levelCompleteEvent;

		public ContentCompareService(PersistentProgressService persistentProgressService, IFXFactory fxFactory, AnimationService animationService, ILevelCompleteEvent levelCompleteEvent)
		{
			_persistentProgressService = persistentProgressService;
			_fxFactory = fxFactory;
			_animationService = animationService;
			_levelCompleteEvent = levelCompleteEvent;
		}

		public async void Compare(Content content)
		{
			string searchIntent = _persistentProgressService.Progress.SearchIntentData.SearchIntent;

			ContentAnimator animator = content.GetComponent<ContentAnimator>();

			if (content.ContentId == searchIntent)
			{
				await CreateStarEffect(content);
				await BounceContent(content,ScalingValue,Duration);

				_levelCompleteEvent.CallLevelCompleteEvent();
			}
			else
			{
				animator.DoShakeEffect();
			}
		}

		private async UniTask BounceContent(Content content, float scalingValue, float duration) => 
			await _animationService.DoBounceEffect(content.Transform, scalingValue, duration);

		private async UniTask CreateStarEffect(Content content)
		{
			await _fxFactory.CreateStarFx();
			_fxFactory.StarFx.transform.position = content.transform.position;
		}
	}
}