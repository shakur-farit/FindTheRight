using UI.Services.Factory;

namespace UI.Services.Window
{
	public class WindowService
	{
		private readonly UIFactory _uiFactory;

		public WindowService(UIFactory uiFactory) =>
			_uiFactory = uiFactory;

		public void Open(WindowId windowId)
		{

			switch (windowId)
			{
				case WindowId.None:
					break;
				case WindowId.GameComplete:
					_uiFactory.CreateGameCompleteWindow(_uiFactory.UIRoot);
					break;
				case WindowId.Load:
					_uiFactory.CreateLoadingWindow(_uiFactory.UIRoot);
					break;
			}
		}
	}
}