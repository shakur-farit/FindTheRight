using Cysharp.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Services.Animation;
using Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
	public abstract class WindowsAnimator
	{
		protected float EndFadeInValue;
		protected float EndFadeOutValue;
		protected float Duration;

		protected StaticDataService StaticData;
		public readonly IFadeInOut FadeInOut;

		protected WindowsAnimator(StaticDataService staticData, IFadeInOut fadeInOut)
		{
			StaticData = staticData;
			FadeInOut = fadeInOut;
		}

		//private IFadeInOut _fadeInOut;

		//[Inject]
		//public void Constructor(IFadeInOut fadeInOut) =>
		//	_fadeInOut = fadeInOut;

		//private void Awake() => 
		//	_canvasGroup.alpha = _alphaStartValue;

		//private void OnDestroy() => 
		//	DOTween.Kill(_canvasGroup);

		//public async UniTask DoFadeIn() => 
		//	await _fadeInOut.DoFade(_canvasGroup, _endFadeInValue, _duration);

		//public async UniTask DoFadeOut() => 
		//	await _fadeInOut.DoFade(_canvasGroup, _endFadeOutValue, _duration);

		public abstract UniTask DoFadeIn(CanvasGroup canvasGroup);
		public abstract UniTask DoFadeOut(CanvasGroup canvasGroup);
	}
}
