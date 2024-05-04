using Cysharp.Threading.Tasks;
using FX;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using StaticEvents;
using UI.Services.Factory;
using UI.Services.Window;
using UI.Windows;

namespace Infrastructure.States.Game
{
	public class GameCompleteState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly WindowService _windowService;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly UIFactory _uiFactory;
		private readonly GameFactory _gameFactory;
		private readonly FXFactory _fxFactory;

		public GameCompleteState(GameStateMachine gameStateMachine, WindowService windowService, 
			PersistentProgressService persistentProgressService, UIFactory uiFactory, GameFactory gameFactory, FXFactory fxFactory)
		{
			_gameStateMachine = gameStateMachine;
			_windowService = windowService;
			_persistentProgressService = persistentProgressService;
			_uiFactory = uiFactory;
			_gameFactory = gameFactory;
			_fxFactory = fxFactory;
		}

		public async void Enter()
		{
			StaticEventsHandler.CallDebug("GameComp");

			StaticEventsHandler.OnRestartedGame += RestartScene;

			await _windowService.Open(WindowId.GameComplete);
			await _uiFactory.GameCompleteWindow.GetComponent<WindowAnimator>().DoFadeIn();

			ReturnClicks();
		}

		private void ReturnClicks() => 
			_persistentProgressService.Progress.ClickDetectorData.CanClick = false;


		public async void RestartScene()
		{
			DestroyGameObjects();
			DestroyFXObjects();

			CleanLists();

			await CloseGameCompleteWindow();

			DestroyUIObjects();

			StaticEventsHandler.OnRestartedGame -= RestartScene;
			
			_gameStateMachine.Enter<LoadStaticDataState>();
		}

		private void DestroyUIObjects() => 
			_uiFactory.DestroyUIRoot();

		public void DestroyFXObjects() =>
			_fxFactory.DestroyStarFx();

		private async UniTask CloseGameCompleteWindow()
		{
			await _uiFactory.GameCompleteWindow.GetComponent<WindowAnimator>().DoFadeOut();
			_windowService.Close(WindowId.GameComplete);
		}
		public void DestroyGameObjects()
		{
			_gameFactory.DestroyGridParent();
			_gameFactory.DestroyHud();
			_gameFactory.DestroyClickDetector();
		}

		private void CleanLists()
		{
			_persistentProgressService.Progress.ContentData.UsedInGame.Clear();
			_persistentProgressService.Progress.ContentData.UsedInLevel.Clear();
		}
	}
}