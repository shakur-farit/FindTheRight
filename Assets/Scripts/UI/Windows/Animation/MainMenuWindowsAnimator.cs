using Cysharp.Threading.Tasks;
using Infrastructure.Services.Animation;
using Infrastructure.Services.StaticData;
using StaticData.Animation;
using UnityEngine;

namespace UI.Windows.Animation
{
	public class MainMenuWindowsAnimator : IFadeOut
	{
		private float _endFadeOutValue;
		private float _duration;

		protected StaticDataService StaticData;
		public readonly IFadeInOut FadeInOut;

		protected MainMenuWindowsAnimator(StaticDataService staticData, IFadeInOut fadeInOut)
		{
			StaticData = staticData;
			FadeInOut = fadeInOut;
		}

		public  async UniTask DoFadeOut(CanvasGroup canvasGroup)
		{
			FadeInOutAnimationStaticData staticData = StaticData.ForMainMenuWindowFadeOutAnimation;

			_endFadeOutValue = staticData.EndValue;
			_duration = staticData.Duration;

			await FadeInOut.DoFade(canvasGroup, _endFadeOutValue, _duration);
		}
	}
}