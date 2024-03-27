using System.Threading.Tasks;
using FX;
using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using UI.Services.Factory;
using UnityEngine;

namespace Infrastructure.States.Game
{
	internal class LoadSceneState : IState
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
			InitializeAssets();
			await WarmUpFactories();
			await LoadSceneGameObjects();
			EnterGameLoopingState();
		}

		private void InitializeAssets()
		{
			_assets.Initialize();
			_assets.CleanUp();
		}

		private async Task WarmUpFactories()
		{
			await _gameFactory.WarmUp();
			await _uiFactory.WarmUp();
			await _fxFactory.WarmUp();
		}

		private async Task LoadSceneGameObjects()
		{
			await CreateGrid();
			await CreateUIRoot();
			await CreateHud();
		}

		private async Task CreateGrid() => 
			await _gameFactory.CreateGrid();

		private async Task CreateHud() => 
			await _gameFactory.CreateHud();

		private async Task CreateUIRoot() => 
			await _uiFactory.CreateUIRoot();

		private void EnterGameLoopingState() => 
			_gameStateMachine.Enter<GameLoopingState>();
	}
}