using FX;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using UI.Services.Window;

namespace Infrastructure.Services.SceneManagement
{
	public class SceneService : IRestartable
	{
		private readonly GameFactory _gameFactory;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly FXFactory _fxFactory;
		private readonly WindowService _windowsService;

		public SceneService(GameFactory gameFactory, PersistentProgressService persistentProgressService, 
			FXFactory fxFactory, WindowService windowsService)
		{
			_gameFactory = gameFactory;
			_persistentProgressService = persistentProgressService;
			_fxFactory = fxFactory;
			_windowsService = windowsService;
		}

		public void RestartScene()
		{
			OpenLoadScene();

			CleanScene();
			CleanLists();

			CreateGameObjects();
		}

		private void CreateGameObjects()
		{
			CreateGrid();
			CreateHud();
		}

		private void OpenLoadScene() => 
			_windowsService.Open(WindowId.Load);

		private void CleanScene()
		{
			_gameFactory.DestroyGrid();
			_gameFactory.DestroyHud();
			_fxFactory.DestroyStarFx();
		}

		private void CleanLists()
		{
			_persistentProgressService.Progress.ContentData.UsedInGame.Clear();
			_persistentProgressService.Progress.ContentData.UsedInLevel.Clear();
		}
		private void CreateGrid() =>
			_gameFactory.CreateGrid();

		private void CreateHud() =>
			_gameFactory.CreateHud();
	}
}