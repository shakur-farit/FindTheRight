using FX;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using UI.Services.Factory;

namespace Infrastructure.Services.SceneManagement
{
	public class SceneCleaner
	{
		private readonly GameFactory _gameFactory;
		private readonly UIFactory _uiFactory;
		private readonly FXFactory _fxFactory;
		private readonly PersistentProgressService _persistentProgressService;

		public SceneCleaner(GameFactory gameFactory, UIFactory uiFactory, FXFactory fxFactory, PersistentProgressService persistentProgressService)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_fxFactory = fxFactory;
			_persistentProgressService = persistentProgressService;
		}

		public void CleanScene()
		{
			_gameFactory.DestroyGridParent();
			_gameFactory.DestroyHud();
			_gameFactory.DestroyClickDetector();
			_uiFactory.DestroyUIRoot();
			_fxFactory.DestroyStarFx();
		}

		public void CleanLists()
		{
			_persistentProgressService.Progress.ContentData.UsedInGame.Clear();
			_persistentProgressService.Progress.ContentData.UsedInLevel.Clear();
		}
	}
}