using Infrastructure.States.LevelDifficultly;

namespace Infrastructure.States.Game
{
	public class GameLoopingState : IState
	{
		private readonly LevelStateMachine _levelStateMachine;

		public GameLoopingState(LevelStateMachine levelStateMachine) => 
			_levelStateMachine = levelStateMachine;

		public void Enter() => 
			_levelStateMachine.Enter<EasyLevel>();

		public void Exit()
		{
		}
	}
}