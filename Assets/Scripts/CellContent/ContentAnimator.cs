using Cysharp.Threading.Tasks;
using Infrastructure.Services.Animation;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;

namespace CellContent
{
	public class ContentAnimator : IContentAnimator
	{
		private readonly IShaker _shaker;
		private readonly IBouncer _bouncer;
		private readonly StaticDataService _staticDataService;

		public ContentAnimator(IShaker shaker, IBouncer bouncer, StaticDataService staticDataService)
		{
			_shaker = shaker;
			_bouncer = bouncer;
			_staticDataService = staticDataService;
		}

		public void DoShakeEffect(Transform transform)
		{
			ShakeAnimationStaticData animationData = _staticDataService.ForContentShakeAnimation;

			float shakeDurationValue = animationData.ShakeDuration;
			float shakeStrengthValue = animationData.ShakeStrength;
			int shakeVibratoValue = animationData.ShakeVibrato;
			float shakeRandomnessValue = animationData.ShakeRandomness;

			_shaker.DoShakeEffect(transform, shakeDurationValue, shakeStrengthValue, shakeVibratoValue, shakeRandomnessValue);
		}

		public async UniTask BounceContent(Transform transform)
		{
			BounceAnimationStaticData animationData = _staticDataService.ForContentBounceAnimation;

			float bounceScalingValue = animationData.BounceScaling;
			float bounceDurationValue = animationData.BounceDuration;

			await _bouncer.DoBounceEffect(transform, bounceScalingValue, bounceDurationValue);
		}
	}
}