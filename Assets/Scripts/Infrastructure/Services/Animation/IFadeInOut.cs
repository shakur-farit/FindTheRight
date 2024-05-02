using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public interface IFadeInOut
	{
		UniTask DoFade(CanvasGroup canvasGroup, float endValue, float duration);
	}
}