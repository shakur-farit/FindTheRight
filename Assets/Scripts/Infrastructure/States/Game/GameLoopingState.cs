using Infrastructure.States.LevelDifficultly;
using StaticEvents;

namespace Infrastructure.States.Game
{
	public class GameLoopingState : IState
	{
		private readonly LevelStateMachine _levelStateMachine;

		public GameLoopingState(LevelStateMachine levelStateMachine) => 
			_levelStateMachine = levelStateMachine;

		public void Enter()
		{
			StaticEventsHandler.CallDebug("GameLoop");

			_levelStateMachine.Enter<EasyLevelState>();
		}
	}
}