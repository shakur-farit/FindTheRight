using ClickDetector.Factory;
using Cysharp.Threading.Tasks;
using GridLogic.Factory;
using Hud.Factory;
using Infrastructure.States.LevelDifficultly;
using UI.Services.Factory;

namespace Infrastructure.States.Game
{
	public class LoadSceneState : IState
	{
		private readonly IGridFactory _gridFactory;
		private readonly IUIFactory _uiFactory;
		private readonly LevelStateMachine _levelStateMachine;
		private readonly IHudFactory _hudFactory;
		private readonly IClickDetectorFactory _clickDetectorFactory;

		public LoadSceneState(LevelStateMachine levelStateMachine, IGridFactory gridFactory, IUIFactory uiFactory, 
			IHudFactory hudFactory, IClickDetectorFactory clickDetectorFactory)
		{
			_gridFactory = gridFactory;
			_uiFactory = uiFactory;
			_levelStateMachine = levelStateMachine;
			_hudFactory = hudFactory;
			_clickDetectorFactory = clickDetectorFactory;
		}

		public async void Enter()
		{
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
			await _gridFactory.CreateGridParent();

		private async UniTask CreateGrid() => 
			await _gridFactory.CreateGrid();

		private async UniTask CreateHud() => 
			await _hudFactory.CreateHud();

		private async UniTask CreateUIRoot() => 
			await _uiFactory.CreateUIRoot();

		private async void CreateClickDetector() => 
			await _clickDetectorFactory.CreateClickDetector();

		private void EnterInEasyLevelState() =>
			_levelStateMachine.Enter<EasyLevelState>();
	}
}