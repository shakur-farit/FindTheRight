using UI.Services.Window;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows
{
	public abstract class WindowBase : MonoBehaviour
	{
		public Button ActionButton;
		public Button QuitButton;
		public WindowAnimator Animator;

		protected WindowService WindowsService;

		[Inject]
		public void Constructor(WindowService windowsService) => 
			WindowsService = windowsService;

		private void Awake() =>
			OnAwake();

		protected abstract void OnAwake();

		protected abstract void CloseWindow();
	}
}