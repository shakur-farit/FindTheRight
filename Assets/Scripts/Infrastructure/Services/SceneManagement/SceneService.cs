using System.Threading.Tasks;
using StaticEvents;
using UI.Services.Factory;
using UI.Services.Window;
using UI.Windows;
using UnityEngine;

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
			Debug.Log("Press on res");

			await CloserGameCompleteWindow();
			await OpenLoadScene();
			//CleanScene();
			_sceneCleaner.DestroyGameObjects();
			_sceneCleaner.DestroyFXObjects();
			CleanLists();

			StaticEventsHandler.CallRestartGameEvent();
		}

		private async Task CloserGameCompleteWindow()
		{
			await _uiFactory.GameCompleteWindow.GetComponent<WindowAnimator>().DoFadeIn();
			_windowsService.Close(WindowId.GameComplete);
		}

		private async Task OpenLoadScene() => 
			await _windowsService.Open(WindowId.Load);

		private void CleanScene() => 
			_sceneCleaner.CleanScene();

		private void CleanLists() => 
			_sceneCleaner.CleanLists();
	}
}