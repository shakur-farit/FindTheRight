using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Windows.Animation
{
	public interface IFadeIn
	{
		UniTask DoFadeIn(CanvasGroup canvasGroup);
	}
}