using Infrastructure.Factory;

namespace Infrastructure.States
{
	internal class LoadSceneState : IState
	{
		private readonly GameFactory _gameFactory;

		public LoadSceneState(GameFactory gameFactory) => 
			_gameFactory = gameFactory;

		public void Enter() => 
			LoadSceneGameObjects();

		private void LoadSceneGameObjects() => 
			_gameFactory.CreateGrid();

		public void Exit()
		{
		}
	}
}