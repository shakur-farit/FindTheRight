using System.Threading.Tasks;
using ClickDetector.Factory;
using Cysharp.Threading.Tasks;
using Infrastructure.States.LevelDifficultly;
using UI.Services.Factory;
using Zenject;

namespace Infrastructure.States.Game
{
	public class LoadSceneState : IState
	{
		private readonly IUIFactory _uiFactory;
		private readonly GameStateMachine _gameStateMachine;
		private readonly IClickDetectorFactory _detectorFactory;

		public LoadSceneState(IUIFactory uiFactory, GameStateMachine gameStateMachine, IClickDetectorFactory detectorFactory)
		{
			_uiFactory = uiFactory;
			_gameStateMachine = gameStateMachine;
			_detectorFactory = detectorFactory;
		}

		public async void Enter()
		{
			await CreateUIRoot();

			EnterInMainMenuState();
		}

		private async UniTask CreateClickDetector() => 
			await _detectorFactory.CreateClickDetector();

		private async UniTask CreateUIRoot() => 
			await _uiFactory.CreateUIRoot();

		private void EnterInMainMenuState() =>
			_gameStateMachine.Enter<MainMenuState>();
	}
}