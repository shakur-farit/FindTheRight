using FX;
using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Game;
using StaticEvents;
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
		private FXFactory _fxFactory;
		private PersistentProgressService _persistentProgressService;
		private RandomService _randomService;
		private WindowService _windowService;
		private IBouncer _bouncer;
		private Assets _assets;

		[Inject]
		public void Constructor(StaticDataService staticDataService, GameFactory gameFactory, UIFactory uiFactory,
			FXFactory fxFactory, PersistentProgressService persistentProgressService, 
			RandomService randomService, WindowService windowService, IBouncer bouncer, Assets assets)
		{
			_staticDataService = staticDataService;
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_fxFactory = fxFactory;
			_persistentProgressService = persistentProgressService;
			_randomService = randomService;
			_windowService = windowService;
			_bouncer = bouncer;
			_assets = assets;
		}

		private void Awake()
		{

			_game = new Game(_staticDataService, _gameFactory, _uiFactory,
				_persistentProgressService, _randomService, _windowService, _bouncer, _assets, _fxFactory);

			_game.GameStateMachine.Enter<LoadStaticDataState>();
		}
	}
}
