using Cysharp.Threading.Tasks;
using Infrastructure.Services.Animation;
using Infrastructure.Services.StaticData;
using StaticData.Animation;
using UnityEngine;

namespace UI.Windows.Animation
{
	public class GameCompleteWindowAnimator : IFadeIn, IFadeOut
	{
		private float _endFadeInValue;
		private float _endFadeOutValue;
		private float _duration;

		protected StaticDataService StaticData;
		public readonly IFadeInOut FadeInOut;

		protected GameCompleteWindowAnimator(StaticDataService staticData, IFadeInOut fadeInOut)
		{
			StaticData = staticData;
			FadeInOut = fadeInOut;
		}

		public async UniTask DoFadeIn(CanvasGroup canvasGroup)
		{
			FadeInOutAnimationStaticData staticData = StaticData.ForGameCompleteWindowFadeInAnimation;

			_endFadeInValue = staticData.EndValue;
			_duration = staticData.Duration;

			await FadeInOut.DoFade(canvasGroup, _endFadeInValue, _duration);
		}

		public async UniTask DoFadeOut(CanvasGroup canvasGroup)
		{
			FadeInOutAnimationStaticData staticData = StaticData.ForGameCompleteWindowFadeOutAnimation;

			_endFadeOutValue = staticData.EndValue;
			_duration = staticData.Duration;

			await FadeInOut.DoFade(canvasGroup, _endFadeOutValue, _duration);
		}
	}
}