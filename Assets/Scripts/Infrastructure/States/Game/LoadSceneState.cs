using Cysharp.Threading.Tasks;
using FX;
using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using StaticEvents;
using UI.Services.Factory;

namespace Infrastructure.States.Game
{
	public class LoadSceneState : IState
	{
		private readonly GameFactory _gameFactory;
		private readonly GameStateMachine _gameStateMachine;
		private readonly UIFactory _uiFactory;
		private readonly FXFactory _fxFactory;
		private readonly Assets _assets;

		public LoadSceneState(GameStateMachine gameStateMachine, GameFactory gameFactory, UIFactory uiFactory, Assets assets, FXFactory fxFactory)
		{
			_gameStateMachine = gameStateMachine;
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_assets = assets;
			_fxFactory = fxFactory;
		}

		public async void Enter()
		{
			StaticEventsHandler.CallOnDebug("Load Scene State");
			InitializeAssets(); 
			WarmUpFactories();
			await LoadSceneGameObjects();
			EnterGameLoopingState();
		}

		private void InitializeAssets()
		{
			_assets.Initialize();
			_assets.CleanUp();
		}

		private async void WarmUpFactories()
		{
			await _gameFactory.WarmUp();
			await _uiFactory.WarmUp();
			await _fxFactory.WarmUp();
		}

		private async UniTask LoadSceneGameObjects()
		{
			StaticEventsHandler.CallOnDebug("Load Game Objects");

			await CreateGridParent();
			await CreateGrid();
			await CreateUIRoot();
			await CreateHud();
			CreateClickDetector();
		}

		private async UniTask CreateGridParent()
		{
			await _gameFactory.CreateGridParent();
			StaticEventsHandler.CallOnDebug("Create Grid");

		}

		private async UniTask CreateGrid() => 
			await _gameFactory.CreateGrid();

		private async UniTask CreateHud() => 
			await _gameFactory.CreateHud();

		private async UniTask CreateUIRoot() => 
			await _uiFactory.CreateUIRoot();

		private void EnterGameLoopingState() => 
			_gameStateMachine.Enter<GameLoopingState>();

		private async void CreateClickDetector() => 
			await _gameFactory.CreateClickDetector();
	}
}