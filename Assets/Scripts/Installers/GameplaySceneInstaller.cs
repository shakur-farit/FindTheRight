using FX;
using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.ContentCompare;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Game;
using Infrastructure.States.LevelDifficultly;
using UI.Services.Factory;
using UI.Services.Window;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterStaticDataService();
			RegisterFactories();
			RegisterAssets();
			RegisterPersistentProgressService();
			RegisterRandomService();
			RegisterWindowService();
			RegisterContentCompareService();
			RegisterAnimationService();
			RegisterStateMachines();
		}

		private void RegisterStateMachines()
		{
			Container.Bind<GameStateMachine>().AsSingle();
			Container.Bind<LevelStateMachine>().AsSingle();
		}

		private void RegisterFactories()
		{
			RegisterGameFactory();
			RegisterUIFactory();
			RegisterFXFactory();
			RegisterStatesFactory();
		}

		private void RegisterStaticDataService() => 
			Container.Bind<StaticDataService>().AsSingle();

		private void RegisterGameFactory() => 
			Container.Bind<GameFactory>().AsSingle();

		private void RegisterUIFactory() => 
			Container.Bind<UIFactory>().AsSingle();

		private void RegisterFXFactory() =>
			Container.Bind<FXFactory>().AsSingle();

		private void RegisterStatesFactory() => 
			Container.BindInterfacesAndSelfTo<StatesFactory>().AsSingle();

		private void RegisterAssets() => 
			Container.Bind<Assets>().AsSingle();

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
	}
}
