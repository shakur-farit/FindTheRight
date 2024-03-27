using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Game;
using UI.Services.Factory;
using UI.Services.Window;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class EnterPoint : MonoBehaviour
	{
		private Game _game;

		private StaticDataService _staticDataService;
		private GameFactory _gameFactory;
		private UIFactory _uiFactory;
		private PersistentProgressService _persistentProgressService;
		private RandomService _randomService;
		private WindowService _windowService;
		private ILoadService _loadService;
		private IBouncer _bouncer;

		[Inject]
		public void Constructor(StaticDataService staticDataService, GameFactory gameFactory, UIFactory uiFactory,
			PersistentProgressService persistentProgressService, ILoadService loadService, RandomService randomService,
			WindowService windowService, IBouncer bouncer)
		{
			_staticDataService = staticDataService;
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_persistentProgressService = persistentProgressService;
			_loadService = loadService;
			_randomService = randomService;
			_windowService = windowService;
			_bouncer = bouncer;
		}

		private void Awake()
		{
			_game = new Game(_staticDataService, _gameFactory, _uiFactory,
				_persistentProgressService, _loadService, _randomService, _windowService, _bouncer);

			_game.GameStateMachine.Enter<LoadStaticDataState>();
		}
	}
}
