using System.Threading.Tasks;
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

		public async void RestartScene()
		{
			OpenLoadScene();

			CleanScene();
			CleanLists();

			await CreateGameObjects();
		}

		private async Task CreateGameObjects()
		{
			await CreateGrid();
			await CreateHud();
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
		private async Task CreateGrid() =>
			await _gameFactory.CreateGrid();

		private async Task CreateHud() =>
			await _gameFactory.CreateHud();
	}
}