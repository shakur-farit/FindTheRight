using Cysharp.Threading.Tasks;
using Infrastructure.Services.Animation;
using Infrastructure.Services.StaticData;
using StaticData.Animation;
using UnityEngine;

namespace UI.Windows
{
	public class MainMenuWindowsAnimator : WindowsAnimator
	{
		public MainMenuWindowsAnimator(StaticDataService staticData, IFadeInOut fadeInOut) : base(staticData, fadeInOut)
		{
		}

		public override async UniTask DoFadeIn(CanvasGroup canvasGroup)
		{
			FadeInOutAnimationStaticData staticData = StaticData.ForGameCompleteWindowFadeInAnimation;

			EndFadeInValue = staticData.EndValue;
			Duration = staticData.Duration;

			await FadeInOut.DoFade(canvasGroup, EndFadeInValue, Duration);
		}

		public override async UniTask DoFadeOut(CanvasGroup canvasGroup)
		{
			FadeInOutAnimationStaticData staticData = StaticData.ForMainMenuWindowFadeOutAnimation;

			EndFadeInValue = staticData.EndValue;
			Duration = staticData.Duration;

			await FadeInOut.DoFade(canvasGroup, EndFadeOutValue, Duration);
		}
	}
}