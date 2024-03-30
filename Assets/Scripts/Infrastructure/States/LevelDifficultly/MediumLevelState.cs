using CellGrid;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticEvents;

namespace Infrastructure.States.LevelDifficultly
{
	public class MediumLevelState : LevelDifficulty,IExitable
	{
		private const string MediumDifficulty = "medium";

		private readonly LevelStateMachine _levelStateMachine;

		public MediumLevelState(StaticDataService staticData, PersistentProgressService persistentProgressService, RandomService randomService,
			GameFactory gameFactory, IBouncer bouncer, LevelStateMachine levelStateMachine) 
			: base(staticData, persistentProgressService, randomService, gameFactory, bouncer) =>
			_levelStateMachine = levelStateMachine;

		public void Exit()
		{
			StaticEventsHandler.OnLevelComplete -= EnterNextState;

			CleanGird();
		}

		protected override void EnterNextState() => 
			_levelStateMachine.Enter<HardLevelState>();

		protected override void SetupLevelData()
		{
			LevelId = MediumDifficulty;
			CanAnimateGrid = false;
		}

		private void CleanGird()
		{
			GridCleaner cleaner = new GridCleaner(GameFactory, PersistentProgressService);
			cleaner.Clean();
		}
	}
}