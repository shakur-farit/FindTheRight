using System.Threading.Tasks;
using DG.Tweening;
using Infrastructure.Services.Animation;
using UnityEngine;
using Zenject;

namespace UI.Windows
{
	public class WindowAnimator : MonoBehaviour
	{
		[SerializeField] private CanvasGroup _canvasGroup;
		[SerializeField] private float _alphaStartValue = 0f;
		[SerializeField] private float _endFadeInValue = 1f;
		[SerializeField] private float _endFadeOutValue = 0f;
		[SerializeField] private float _duration = 0.5f;

		private IFadeInOut _fadeInOut;

		[Inject]
		public void Constructor(IFadeInOut fadeInOut) =>
			_fadeInOut = fadeInOut;

		private void Awake() => 
			_canvasGroup.alpha = _alphaStartValue;

		private void OnDestroy() => 
			DOTween.Kill(_canvasGroup);

		public async Task DoFadeIn() => 
			await _fadeInOut.DoFade(_canvasGroup, _endFadeInValue, _duration);

		public async Task DoFadeOut() => 
			await _fadeInOut.DoFade(_canvasGroup, _endFadeOutValue, _duration);
	}
}
