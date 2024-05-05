using Cysharp.Threading.Tasks;
using Infrastructure.Factory;
using Infrastructure.States.LevelDifficultly;
using StaticEvents;
using UI.Services.Factory;
using UnityEngine;

namespace Infrastructure.States.Game
{
	public class LoadSceneState : IState
	{
		private readonly GameFactory _gameFactory;
		private readonly UIFactory _uiFactory;
		private readonly LevelStateMachine _levelStateMachine;

		public LoadSceneState(GameFactory gameFactory, UIFactory uiFactory, LevelStateMachine levelStateMachine)
		{
			_gameFactory = gameFactory;
			_uiFactory = uiFactory;
			_levelStateMachine = levelStateMachine;
		}

		public async void Enter()
		{
			StaticEventsHandler.CallDebug("Scene");

			await LoadSceneGameObjects();
			EnterInEasyLevelState();
		}

		private async UniTask LoadSceneGameObjects()
		{

			await CreateGridParent();
			await CreateGrid();
			await CreateUIRoot();
			await CreateHud();
			CreateClickDetector();
		}

		private async UniTask CreateGridParent() => 
			await _gameFactory.CreateGridParent();

		private async UniTask CreateGrid() => 
			await _gameFactory.CreateGrid();

		private async UniTask CreateHud() => 
			await _gameFactory.CreateHud();

		private async UniTask CreateUIRoot() => 
			await _uiFactory.CreateUIRoot();

		private async void CreateClickDetector() => 
			await _gameFactory.CreateClickDetector();

		private void EnterInEasyLevelState() =>
			_levelStateMachine.Enter<EasyLevelState>();
	}
}