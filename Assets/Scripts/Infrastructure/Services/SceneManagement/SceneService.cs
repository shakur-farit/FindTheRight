using StaticEvents;
using UI.Services.Window;

namespace Infrastructure.Services.SceneManagement
{
	public class SceneService : IRestartable
	{
		private readonly WindowService _windowsService;
		private readonly SceneCleaner _sceneCleaner;

		public SceneService(WindowService windowsService, SceneCleaner sceneCleaner)
		{
			_windowsService = windowsService;
			_sceneCleaner = sceneCleaner;
		}

		public void RestartScene()
		{
			CleanScene();
			OpenLoadScene();
			CleanLists();
			StaticEventsHandler.CallRestartGameEvent();
		}

		private void OpenLoadScene() => 
			_windowsService.Open(WindowId.Load);

		private void CleanScene() => 
			_sceneCleaner.CleanScene();

		private void CleanLists() => 
			_sceneCleaner.CleanLists();
	}
}