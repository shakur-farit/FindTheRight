using Infrastructure.Factory;

namespace Infrastructure.States.Game
{
	internal class LoadSceneState : IState
	{
		private readonly GameFactory _gameFactory;
		private readonly GameStateMachine _gameStateMachine;

		public LoadSceneState(GameStateMachine gameStateMachine, GameFactory gameFactory)
		{
			_gameStateMachine = gameStateMachine;
			_gameFactory = gameFactory;
		}

		public void Enter()
		{
			LoadSceneGameObjects();
			EnterGameLoopingState();
		}

		public void Exit()
		{
		}

		private void LoadSceneGameObjects() => 
			_gameFactory.CreateGrid();

		private void EnterGameLoopingState() => 
			_gameStateMachine.Enter<GameLoopingState>();
	}
}