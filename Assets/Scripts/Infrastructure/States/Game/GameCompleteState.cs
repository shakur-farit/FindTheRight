using ClickDetector.Factory;
using Events;
using FX;
using GridLogic.Factory;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using UI.Services.Window;

namespace Infrastructure.States.Game
{
	public class GameCompleteState : IState
	{
		private readonly GameStateMachine _gameStateMachine;
		private readonly WindowService _windowService;
		private readonly PersistentProgressService _persistentProgressService;
		private readonly IGridFactory _gridFactory;
		private readonly IFXFactory _fxFactory;
		private readonly IGameRestartEvent _gameRestartEvent;
		private readonly IHudFactory _hudFactory;
		private readonly IClickDetectorFactory _clickerDetectorFactory;

		public GameCompleteState(GameStateMachine gameStateMachine, WindowService windowService, 
			PersistentProgressService persistentProgressService, IGridFactory gridFactory, IFXFactory fxFactory, 
			IHudFactory hudFactory, IClickDetectorFactory clickerDetectorFactory, IGameRestartEvent gameRestartEvent)
		{
			_gameStateMachine = gameStateMachine;
			_windowService = windowService;
			_persistentProgressService = persistentProgressService;
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

			ReturnClicks();
		}

		private void ReturnClicks() => 
			_persistentProgressService.Progress.ClickDetectorData.CanClick = false;


		public void GameRestartScene()
		{
			DestroyGameObjects();
			DestroyFXObjects();

			CleanLists();

			_gameRestartEvent.GameRestarted -= GameRestartScene;
			
			_gameStateMachine.Enter<GamePlayLoopState>();
		}

		public void DestroyFXObjects() =>
			_fxFactory.DestroyStarFx();

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