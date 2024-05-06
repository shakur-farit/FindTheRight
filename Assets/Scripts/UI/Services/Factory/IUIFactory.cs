using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Services.Factory
{
	public interface IUIFactory
	{
		Transform UIRoot { get; }
		GameObject GameCompleteWindow { get; }
		UniTask CreateUIRoot();
		UniTask CreateGameCompleteWindow(Transform parentTransform);
		void DestroyUIRoot();
		void DestroyGameCompleteWindow();
	}
}