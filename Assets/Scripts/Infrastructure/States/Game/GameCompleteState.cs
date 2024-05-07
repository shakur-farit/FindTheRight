using ClickDetector.Factory;
using Cysharp.Threading.Tasks;
using Events;
using FX;
using GridLogic.Factory;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
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
		private readonly IUIFactory _uiFactory;
		private readonly IGridFactory _gridFactory;
		private readonly IFXFactory _fxFactory;
		private readonly IGameRestartEvent _gameRestartEvent;
		private readonly IHudFactory _hudFactory;
		private readonly IClickDetectorFactory _clickerDetectorFactory;

		public GameCompleteState(GameStateMachine gameStateMachine, WindowService windowService, 
			PersistentProgressService persistentProgressService, IUIFactory uiFactory, IGridFactory gridFactory, IFXFactory fxFactory, 
			IHudFactory hudFactory, IClickDetectorFactory clickerDetectorFactory, IGameRestartEvent gameRestartEvent)
		{
			_gameStateMachine = gameStateMachine;
			_windowService = windowService;
			_persistentProgressService = persistentProgressService;
			_uiFactory = uiFactory;
			_gridFactory = gridFactory;
			_fxFactory = fxFactory;
			_hudFactory = hudFactory;
			_clickerDetectorFactory = clickerDetectorFactory;
			_gameRestartEvent = gameRestartEvent;
		}

		public async void Enter()
		{
			_gameRestartEvent.GameRestarted += GameRestartScene;

			await _windowService.Open(WindowId.GameComplete);

			await _uiFactory.GameCompleteWindow.GetComponent<WindowAnimator>().DoFadeIn();

			ReturnClicks();
		}

		private void ReturnClicks() => 
			_persistentProgressService.Progress.ClickDetectorData.CanClick = false;


		public async void GameRestartScene()
		{
			DestroyGameObjects();
			DestroyFXObjects();

			CleanLists();

			await CloseGameCompleteWindow();

			DestroyUIObjects();

			_gameRestartEvent.GameRestarted -= GameRestartScene;
			
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
			_gridFactory.DestroyGridParent();
			_hudFactory.DestroyHud();
			_clickerDetectorFactory.DestroyClickDetector();
		}

		private void CleanLists()
		{
			_persistentProgressService.Progress.ContentData.UsedInGame.Clear();
			_persistentProgressService.Progress.ContentData.UsedInLevel.Clear();
		}
	}
}