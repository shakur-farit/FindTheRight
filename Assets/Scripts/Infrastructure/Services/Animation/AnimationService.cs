using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public class AnimationService : IBouncer, IShaker, IFadeInOut, IRotator
	{
		public async UniTask DoBounceEffect(Transform transform, float scalingValue, float duration)
		{
			Vector3 originalScale = transform.localScale;
			Vector3 scaleTo = originalScale * scalingValue;

			await transform.DOScale(scaleTo, duration)
		 .SetEase(Ease.InOutSine)
		 .AsyncWaitForCompletion();
			
			await transform.DOScale(originalScale, duration)
			.SetEase(Ease.OutBack)
			.AsyncWaitForCompletion();

			DOTween.Kill(transform);
		}

		public async UniTask DoShakeEffect(Transform transform, float duration, float strength, int vibrato, float randomness)
		{
			await transform.DOShakePosition(duration, strength, vibrato, randomness).AsyncWaitForCompletion();

			DOTween.Kill(transform);
		}

		public async UniTask DoFade(CanvasGroup canvasGroup, float endValue, float duration)
		{
			await canvasGroup.DOFade(endValue, duration).AsyncWaitForCompletion();

			DOTween.Kill(canvasGroup);
		}

		public async UniTask DoRotate(Transform transform, Vector3 endValue, float duration)
		{
			await transform.DORotate(endValue, duration).AsyncWaitForCompletion();

			DOTween.Kill(transform);
		}
	}
}