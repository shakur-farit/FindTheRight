using Infrastructure.Factory;
using UI.Services.Factory;

namespace Infrastructure.States.Game
{
	internal class LoadSceneState : IState
	{
		private readonly GameFactory _gameFactory;
		private readonly GameStateMachine _gameStateMachine;
		private readonly UIFactory _uiFactory;

		public LoadSceneState(GameStateMachine gameStateMachine, GameFactory gameFactory, UIFactory uiFactory)
		{
			_gameStateMachine = gameStateMachine;
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
		}

		public void Enter()
		{
			LoadSceneGameObjects();
			EnterGameLoopingState();
		}

		private void LoadSceneGameObjects()
		{
			CreateGrid();
			CreateHud();
			CreateUIRoot();
		}

		private void CreateGrid() => 
			_gameFactory.CreateGrid();

		private void CreateHud() => 
			_gameFactory.CreateHud();

		private void CreateUIRoot() => 
			_uiFactory.CreateUIRoot();

		private void EnterGameLoopingState() => 
			_gameStateMachine.Enter<GameLoopingState>();
	}
}