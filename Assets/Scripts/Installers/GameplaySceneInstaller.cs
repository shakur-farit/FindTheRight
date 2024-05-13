using CellContent;
using CellContent.Factory;
using CellLogic;
using CellLogic.Factory;
using ClickDetector.Factory;
using Events;
using FX;
using GridLogic;
using GridLogic.Factory;
using Hud.Factory;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.Animation;
using Infrastructure.Services.ContentCompare;
using Infrastructure.Services.GameObjectsCreate;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Factory;
using Infrastructure.States.Game;
using Infrastructure.States.LevelDifficultly;
using SearchIntent;
using UI.Services.Factory;
using UI.Services.Window;
using UI.Windows;
using Utility;
using Zenject;

namespace Installers
{
	public class GamePlaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterFactories();
			RegisterStateMachines();
			RegisterServices();
			RegisterGenerators();
			RegisterAnimators();
		}

		private void RegisterStateMachines()
		{
			Container.Bind<GameStateMachine>().AsSingle();
			Container.Bind<LevelStateMachine>().AsSingle();
		}

		private void RegisterFactories()
		{
			RegisterGridFactory();
			RegisterCellFactory();
			RegisterContentFactory();
			RegisterClickDetectorFactory();
			RegisterHudFactory();
			RegisterUIFactory();
			RegisterFXFactory();
			RegisterStatesFactory();
		}

		private void RegisterServices()
		{
			RegisterStaticDataService();
			RegisterAssets();
			RegisterPersistentProgressService();
			RegisterRandomService();
			RegisterWindowService();
			RegisterContentCompareService();
			RegisterAnimationService();
			RegisterGameObjectsCreateService();
			RegisterEventer();
			RegisterGridCleaner();
			RegisterFXCreator();
			RegisterHelperUtility();
		}

		private void RegisterGenerators()
		{
			RegisterGridGenerator();
			RegisterSearchIntentGenerator();
			RegisterCellGenerator();
			RegisterContentGenerator();
		}

		private void RegisterStaticDataService() => 
			Container.Bind<StaticDataService>().AsSingle();

		private void RegisterGridFactory() => 
			Container.Bind<IGridFactory>().To<GridFactory>().AsSingle();

		private void RegisterAnimators()
		{
			RegisterContentAnimator();
			RegisterGridAnimator();
			RegisterRestartButtonAnimator();
			RegisterGameCompleteAnimator();
			RegisterMainMenuAnimator();
		}

		private void RegisterCellFactory() => 
			Container.Bind<ICellFactory>().To<CellFactory>().AsSingle();

		private void RegisterContentFactory() => 
			Container.Bind<IContentFactory>().To<ContentFactory>().AsSingle();

		private void RegisterClickDetectorFactory() => 
			Container.Bind<IClickDetectorFactory>().To<ClickDetectorFactory>().AsSingle();

		private void RegisterHudFactory() => 
			Container.Bind<IHudFactory>().To<HudFactory>().AsSingle();

		private void RegisterUIFactory() => 
			Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();

		private void RegisterFXFactory() =>
			Container.Bind<IFXFactory>().To<FXFactory>().AsSingle();

		private void RegisterStatesFactory() => 
			Container.BindInterfacesAndSelfTo<StatesFactory>().AsSingle();

		private void RegisterAssets() => 
			Container.Bind<AssetsProvider>().AsSingle();

		private void RegisterPersistentProgressService() => 
			Container.Bind<PersistentProgressService>().AsSingle();

		private void RegisterRandomService() => 
			Container.Bind<RandomService>().AsSingle();

		private void RegisterWindowService() => 
			Container.Bind<WindowService>().AsSingle();

		private void RegisterContentCompareService() => 
			Container.Bind<ContentCompareService>().AsSingle();

		private void RegisterAnimationService() =>
			Container.BindInterfacesAndSelfTo<AnimationService>().AsSingle();

		private void RegisterGameObjectsCreateService() => 
			Container.Bind<IGameObjectsCreateService>().To<GameObjectsCreateService>().AsSingle();

		private void RegisterEventer() => 
			Container.BindInterfacesAndSelfTo<Eventor>().AsSingle();

		private void RegisterGridGenerator() => 
			Container.Bind<IGridGenerator>().To<GridGenerator>().AsSingle();

		private void RegisterSearchIntentGenerator() => 
			Container.Bind<ISearchIntentGenerator>().To<SearchIntentGenerator>().AsSingle();

		private void RegisterCellGenerator() => 
			Container.Bind<ICellGenerator>().To<CellGenerator>().AsSingle();

		private void RegisterContentGenerator() => 
			Container.Bind<IContentGenerator>().To<ContentGenerator>().AsSingle();

		private void RegisterGridCleaner() => 
			Container.Bind<IGridCleaner>().To<GridCleaner>().AsSingle();

		private void RegisterContentAnimator() => 
			Container.Bind<IContentAnimator>().To<ContentAnimator>().AsSingle();

		private void RegisterGridAnimator() => 
			Container.Bind<IGridAnimator>().To<GridAnimator>().AsSingle();

		private void RegisterRestartButtonAnimator() => 
			Container.Bind<IRestartButtonAnimator>().To<RestartButtonAnimator>().AsSingle();

		private void RegisterFXCreator() => 
			Container.Bind<IFXCreator>().To<FXCreator>().AsSingle();

		private void RegisterHelperUtility() => 
			Container.Bind<IHelperUtility>().To<HelperUtility>().AsSingle();

		private void RegisterGameCompleteAnimator() => 
			Container.Bind<GameCompleteWindowAnimator>().AsSingle();

		private void RegisterMainMenuAnimator() =>
			Container.Bind<MainMenuWindowsAnimator>().AsSingle();
	}
}
