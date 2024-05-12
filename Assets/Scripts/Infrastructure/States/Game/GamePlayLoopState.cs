using ClickDetector.Factory;
using Cysharp.Threading.Tasks;
using GridLogic.Factory;
using Hud.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.States.LevelDifficultly;

namespace Infrastructure.States.Game
{
	public class GamePlayLoopState : IState
	{
		private readonly IGridFactory _gridFactory;
		private readonly LevelStateMachine _levelStateMachine;
		private readonly IHudFactory _hudFactory;
		private readonly IClickDetectorFactory _clickDetectorFactory;
		private readonly PersistentProgressService _progressService;

		public GamePlayLoopState(LevelStateMachine levelStateMachine, IGridFactory gridFactory,
			IHudFactory hudFactory, IClickDetectorFactory clickDetectorFactory, PersistentProgressService progressService)
		{
			_gridFactory = gridFactory;
			_levelStateMachine = levelStateMachine;
			_hudFactory = hudFactory;
			_clickDetectorFactory = clickDetectorFactory;
			_progressService = progressService;
		}

		public async void Enter()
		{
			await LoadSceneGameObjects();
			EnterInEasyLevelState();
		}

		private async UniTask LoadSceneGameObjects()
		{
			await CreateGridParent();
			await CreateHud();
			CreateClickDetector();
		}

		private async UniTask CreateGridParent() =>
			await _gridFactory.CreateGridParent();

		private async UniTask CreateHud() =>
			await _hudFactory.CreateHud();

		private async void CreateClickDetector()
		{
			await _clickDetectorFactory.CreateClickDetector();

			SetupClickDetectorData();
		}

		private void SetupClickDetectorData() =>
			_progressService.Progress.ClickDetectorData.CanClick = true;

		private void EnterInEasyLevelState() =>
			_levelStateMachine.Enter<EasyLevelState>();
	}
}