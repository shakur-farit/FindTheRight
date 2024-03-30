using CellGrid;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using StaticEvents;

namespace Infrastructure.States.LevelDifficultly
{
	public class EasyLevelState : LevelDifficulty, IExitable
	{
		private const string EasyDifficulty = "easy";

		private readonly LevelStateMachine _levelStateMachine;

		public EasyLevelState(StaticDataService staticData, PersistentProgressService persistentProgressService, RandomService randomService, 
			GameFactory gameFactory, IBouncer bouncer, LevelStateMachine levelStateMachine) 
			: base(staticData, persistentProgressService, randomService, gameFactory, bouncer)
		{
			_levelStateMachine = levelStateMachine;
		}

		public void Exit()
		{
			StaticEventsHandler.OnLevelComplete -= EnterNextState;

			CleanGird();
		}

		protected override void EnterNextState() => 
			_levelStateMachine.Enter<MediumLevelState>();

		protected override void SetupLevelData()
		{
			LevelId = EasyDifficulty;
			CanAnimateGrid = true;
		}

		private void CleanGird()
		{
			GridCleaner cleaner = new GridCleaner(GameFactory, PersistentProgressService);
			cleaner.Clean();
		}
	}
}