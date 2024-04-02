using System.Threading.Tasks;
using StaticEvents;
using UI.Services.Factory;
using UI.Services.Window;
using UI.Windows;

namespace Infrastructure.Services.SceneManagement
{
	public class SceneService : IRestartable
	{
		private readonly WindowService _windowsService;
		private readonly SceneCleaner _sceneCleaner;
		private readonly UIFactory _uiFactory;

		public SceneService(WindowService windowsService, SceneCleaner sceneCleaner, UIFactory uiFactory)
		{
			_windowsService = windowsService;
			_sceneCleaner = sceneCleaner;
			_uiFactory = uiFactory;
		}

		public async void RestartScene()
		{
			CloserGameCompleteWindow();

			await OpenLoadScene();

			_sceneCleaner.DestroyGameObjects();
			_sceneCleaner.DestroyFXObjects();

			CleanLists();

			StaticEventsHandler.CallRestartGameEvent();

			await CloseLoadSceneWindow();

			DestroyUIObjects();
		}

		private void DestroyUIObjects() => 
			_sceneCleaner.DestroyUIObjects();

		private async void CloserGameCompleteWindow()
		{
			await _uiFactory.GameCompleteWindow.GetComponent<WindowAnimator>().DoFadeOut();
			_windowsService.Close(WindowId.GameComplete);
		}

		private async Task OpenLoadScene()
		{
			await _windowsService.Open(WindowId.Load);
			await _uiFactory.LoadSceneWindow.GetComponent<WindowAnimator>().DoFadeIn();
		}

		private async Task CloseLoadSceneWindow()
		{
			await _uiFactory.LoadSceneWindow.GetComponent<WindowAnimator>().DoFadeOut();
		 _windowsService.Close(WindowId.Load);
		}

		private void CleanLists() => 
			_sceneCleaner.CleanLists();
	}
}