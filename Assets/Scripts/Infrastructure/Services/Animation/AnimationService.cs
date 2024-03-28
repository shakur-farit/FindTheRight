using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public class AnimationService : IBouncer, IShaker, IFadeInOut
	{
		public async Task DoBounceEffect(Transform transform, float scalingValue, float duration)
		{
			Vector3 originalScale = transform.localScale;
			Vector3 scaleTo = originalScale * scalingValue;

			await transform.DOScale(scaleTo, duration)
		 .SetEase(Ease.InOutSine)
		 .AsyncWaitForCompletion();
			
			await transform.DOScale(originalScale, duration)
			.SetEase(Ease.OutBack)
			.AsyncWaitForCompletion();
		}

		public async Task DoShakeEffect(Transform transform, float duration, float strength, int vibrato, float randomness) =>
			await transform.DOShakePosition(duration, strength, vibrato, randomness).AsyncWaitForCompletion();

		public async Task DoFade(CanvasGroup canvasGroup, float endValue, float duration) => 
			await canvasGroup.DOFade(endValue, duration).AsyncWaitForCompletion();
	}
}