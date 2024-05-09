using Infrastructure.AssetsManagement;

namespace Infrastructure.States.Game
{
	public class WarmUpState : IState
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly GameStateMachine _gameStateMachine;

		public WarmUpState(AssetsProvider assetsProvider, GameStateMachine gameStateMachine)
		{
			_assetsProvider = assetsProvider;
			_gameStateMachine = gameStateMachine;
		}

		public void Enter()
		{
			InitializeAssets();

			AssetsReferenceWarmUp();

			EnterInLoadStaticDataState();
		}

		private void InitializeAssets()
		{
			_assetsProvider.Initialize();
			_assetsProvider.CleanUp();
		}

		private async void AssetsReferenceWarmUp() => 
			await _assetsProvider.Load<GameObjectsAssetsReference>(AssetsAddress.GameObjectsAssetsReferenceAddress);

		private void EnterInLoadStaticDataState() => 
			_gameStateMachine.Enter<LoadStaticDataState>();
	}
}