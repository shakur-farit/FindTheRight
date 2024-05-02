using Cysharp.Threading.Tasks;
using UI.Services.Factory;

namespace UI.Services.Window
{
	public class WindowService
	{
		private readonly UIFactory _uiFactory;

		public WindowService(UIFactory uiFactory) =>
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