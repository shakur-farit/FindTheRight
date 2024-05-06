using Events;
using GridLogic;
using GridLogic.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using SearchIntent;

namespace Infrastructure.States.LevelDifficultly
{
	public class EasyLevelState : LevelDifficulty, IExitable
	{
		private const string EasyDifficulty = "easy";

		private readonly LevelStateMachine _levelStateMachine;
		private readonly IGridCleaner _gridCleaner;

		public EasyLevelState(StaticDataService staticData, PersistentProgressService persistentProgressService,
			RandomService randomService, IGridFactory gridFactory, IBouncer bouncer, LevelStateMachine levelStateMachine,
			ILevelCompleteEvent levelCompleteEvent,
			ISearchIntentGenerator searchIntentGenerator, IGridGenerator gridGenerator, IGridCleaner gridCleaner) 
			: base(staticData, persistentProgressService, randomService, gridFactory, bouncer, 
				levelCompleteEvent, searchIntentGenerator, gridGenerator)
		{
			_levelStateMachine = levelStateMachine;
			_gridCleaner = gridCleaner;
		}

		public void Exit()
		{
			LevelCompleteEvent.LevelCompleted -= EnterNextState;

			CleanGird();
		}

		protected override void EnterNextState() => 
			_levelStateMachine.Enter<MediumLevelState>();

		protected override void SetupLevelData()
		{
			LevelId = EasyDifficulty;
			CanAnimateGrid = true;
		}

		private void CleanGird() => 
			_gridCleaner.Clean();
	}
}