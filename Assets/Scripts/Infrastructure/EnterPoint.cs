using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgressService;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
	public class EnterPoint : MonoBehaviour
	{
		private Game _game;

		private StaticDataService _staticDataService;
		private GameFactory _gameFactory;
		private PersistentProgressService _persistentProgressService;
		private ILoadService _loadService;

		[Inject]
		public void Constructor(StaticDataService staticDataService, GameFactory gameFactory, 
			PersistentProgressService persistentProgressService, ILoadService loadService)
		{
			_staticDataService = staticDataService;
			_gameFactory = gameFactory;
			_persistentProgressService = persistentProgressService;
			_loadService = loadService;
		}

		private void Awake()
		{
			_game = new Game(_staticDataService, _gameFactory, _persistentProgressService, _loadService);

			_game.GameStateMachine.Enter<LoadStaticDataState>();
		}
	}
}
