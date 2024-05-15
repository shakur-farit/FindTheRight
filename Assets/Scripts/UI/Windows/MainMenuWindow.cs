using Events;
using UI.Services.Window;
using UI.Windows.Animation;
using Zenject;

namespace UI.Windows
{
	public class MainMenuWindow : WindowBase
	{
		private IGameStartEvent _eventor;
		private MainMenuWindowsAnimator _windowsAnimator;

		[Inject]
		public void Constructor(IGameStartEvent eventor, MainMenuWindowsAnimator windowsAnimator)
		{
			_eventor = eventor;
			_windowsAnimator = windowsAnimator;
		}

		protected override void OnAwake()
		{
			ActionButton.onClick.AddListener(StartGamePlay);
			QuitButton.onClick.AddListener(QuitGame);
		}

		public void StartGamePlay()
		{
			_eventor.CallGameStartedEvent();

			CloseWindow();
		}

		protected override async void CloseWindow()
		{
			await _windowsAnimator.DoFadeOut(CanvasGroup);

			WindowsService.Close(WindowId.MainMenu);
		}

		protected override void QuitGame() => 
			Quitable.Quit();
	}
}