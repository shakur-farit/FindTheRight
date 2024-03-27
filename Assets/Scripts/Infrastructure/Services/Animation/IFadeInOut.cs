using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public interface IFadeInOut
	{
		void DoFade(CanvasGroup canvasGroup, float endValue, float duration);
	}
}