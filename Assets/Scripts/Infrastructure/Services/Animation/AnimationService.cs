using DG.Tweening;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public class AnimationService : IBouncer, IShaker, IFadeInOut
	{
		public void DoBounceEffect(Transform transform, float scalingValue, float duration)
		{
			Vector3 originalScale = transform.localScale;
			Vector3 scaleTo = originalScale * scalingValue;

			transform.DOScale(scaleTo, duration)
				.SetEase(Ease.InOutSine)
				.OnComplete(() =>
				{
					transform.DOScale(originalScale, duration)
						.SetEase(Ease.OutBack);
				});

		}

		public void DoShakeEffect(Transform transform, float duration, float strength, int vibrato, float randomness) =>
			transform.DOShakePosition(duration, strength, vibrato, randomness);

		public void DoFade(CanvasGroup canvasGroup, float endValue, float duration) => 
			canvasGroup.DOFade(endValue, duration);
	}
}