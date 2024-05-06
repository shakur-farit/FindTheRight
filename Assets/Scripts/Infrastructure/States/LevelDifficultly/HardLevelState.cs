using Events;
using GridLogic;
using GridLogic.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Game;
using SearchIntent;

namespace Infrastructure.States.LevelDifficultly
{
	public class HardLevelState : LevelDifficulty,IExitable
	{
		private const string HardDifficulty = "hard";

		private readonly GameStateMachine _gameStateMachine;

		public HardLevelState(StaticDataService staticData, PersistentProgressService persistentProgressService,
			RandomService randomService, IGridFactory gridFactory, IBouncer bouncer, GameStateMachine gameStateMachine,
			ILevelCompleteEvent levelCompleteEvent,
			ISearchIntentGenerator searchIntentGenerator, IGridGenerator gridGenerator)
			: base(staticData, persistentProgressService, randomService, gridFactory, bouncer,
				levelCompleteEvent, searchIntentGenerator, gridGenerator) =>
			_gameStateMachine = gameStateMachine;


		public void Exit() =>
			LevelCompleteEvent.LevelCompleted -= EnterNextState;

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