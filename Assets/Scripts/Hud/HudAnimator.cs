using Infrastructure.Services.Animation;
using UnityEngine;
using Zenject;

namespace Hud
{
	public class HudAnimator : MonoBehaviour
	{
		private const float EndFadeValue = 1f;
		private const float Duration = 2f;

		[SerializeField] private CanvasGroup _canvasGroup;

		private IFadeInOut _fadeInOut;

		[Inject]
		public void Constructor(IFadeInOut fadeInOut) => 
			_fadeInOut = fadeInOut;

		private void Start()
		{
			_canvasGroup.alpha = 0f;

			DoFadeOut();
		}

		private void DoFadeOut() => 
			_fadeInOut.DoFade(_canvasGroup,EndFadeValue,Duration);
	}
}