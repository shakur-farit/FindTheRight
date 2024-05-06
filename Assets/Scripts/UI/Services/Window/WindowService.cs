using Cysharp.Threading.Tasks;
using UI.Services.Factory;

namespace UI.Services.Window
{
	public class WindowService
	{
		private readonly IUIFactory _uiFactory;

		public WindowService(IUIFactory uiFactory) =>
			_uiFactory = uiFactory;

		public async UniTask Open(WindowId windowId)
		{
			switch (windowId)
			{
				case WindowId.None:
					break;
				case WindowId.GameComplete:
					await _uiFactory.CreateGameCompleteWindow(_uiFactory.UIRoot);
					break;

			}
		}

		public void Close(WindowId windowId)
		{
			switch (windowId)
			{
				case WindowId.None:
					break;
				case WindowId.GameComplete:
					 _uiFactory.DestroyGameCompleteWindow();
					break;
			}
		}
	}
}