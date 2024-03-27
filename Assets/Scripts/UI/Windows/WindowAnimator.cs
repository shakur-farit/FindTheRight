using DG.Tweening;
using Infrastructure.Services.Animation;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
	public class WindowAnimator : MonoBehaviour
	{
		[SerializeField] private CanvasGroup _canvasGroup;
		[SerializeField] private  float _alphaStartValue = 0f; 
		[SerializeField] private  float _endFadeValue = 1f;
		[SerializeField] private  float _duration = 0.5f;

		private IFadeInOut _fadeInOut;

		[Inject]
		public void Constructor(IFadeInOut fadeInOut) =>
			_fadeInOut = fadeInOut;

		private void Start()
		{
			_canvasGroup.alpha = _alphaStartValue;

			DoFadeIn(_canvasGroup, _endFadeValue, _duration);
		}

		private void OnDestroy() => 
			DOTween.Kill(transform);
		private void DoFadeIn(CanvasGroup canvas, float endValue, float duration) =>
			_fadeInOut.DoFade(canvas, endValue, duration);
	}
}
