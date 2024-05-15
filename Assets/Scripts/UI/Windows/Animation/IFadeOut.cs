using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Windows.Animation
{
	public interface IFadeOut
	{
		UniTask DoFadeOut(CanvasGroup canvasGroup);
	}
}