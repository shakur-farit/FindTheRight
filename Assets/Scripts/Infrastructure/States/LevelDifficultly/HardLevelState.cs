using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Game;
using StaticEvents;

namespace Infrastructure.States.LevelDifficultly
{
	public class HardLevelState : LevelDifficulty,IExitable
	{
		private const string HardDifficulty = "hard";

		private readonly GameStateMachine _gameStateMachine;

		public HardLevelState(StaticDataService staticData, PersistentProgressService persistentProgressService, RandomService randomService,
			GameFactory gameFactory, IBouncer bouncer, GameStateMachine gameStateMachine) 
			: base(staticData, persistentProgressService, randomService, gameFactory, bouncer) =>
			_gameStateMachine = gameStateMachine;


		public void Exit() =>
			StaticEventsHandler.OnLevelComplete -= EnterNextState;

		protected override void EnterNextState()
		{
			_gameStateMachine.Enter<GameCompleteState>();
			Exit();
		}

		protected override void SetupLevelData()
		{
			LevelId = HardDifficulty;
			CanAnimateGrid = false;
		}
	}
}