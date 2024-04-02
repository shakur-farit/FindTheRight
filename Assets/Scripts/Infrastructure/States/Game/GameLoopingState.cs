using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.LevelDifficultly;

namespace Infrastructure.States.Game
{
	public class GameLoopingState : IState
	{
		private LevelStateMachine _levelStateMachine;

		private readonly GameStateMachine _gameStateMachine;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly StaticDataService _stateDataService;
		private readonly GameFactory _gameFactory;
		private readonly RandomService _randomService;
		private readonly IBouncer _bouncer;

		public GameLoopingState(GameStateMachine gameStateMachine, PersistentProgressService persistentProgressService, 
			StaticDataService stateDataService, GameFactory gameFactory, RandomService randomService, IBouncer bouncer)
		{
			_persistentProgressService = persistentProgressService;
			_stateDataService = stateDataService;
			_gameFactory = gameFactory;
			_randomService = randomService;
			_bouncer = bouncer;
			_gameStateMachine = gameStateMachine;
		}

		public void Enter()
		{
			_levelStateMachine = new LevelStateMachine(_persistentProgressService, _stateDataService, _gameFactory,
				_gameStateMachine, _randomService, _bouncer);

			_levelStateMachine.Enter<EasyLevelState>();
		}
	}
}