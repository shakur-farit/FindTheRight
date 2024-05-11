using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Services.Factory
{
	public interface IUIFactory
	{
		Transform UIRoot { get; }
		GameObject GameCompleteWindow { get; }
		GameObject MainMenuWindow { get; }
		UniTask CreateUIRoot();
		UniTask CreateGameCompleteWindow(Transform parentTransform);
		UniTask CreateMainMenuWindow(Transform parentTransform);
		void DestroyUIRoot();
		void DestroyGameCompleteWindow();
		void DestroyMainMenuWindow();
	}
}