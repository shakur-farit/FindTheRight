using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgressService;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticData;
using Zenject;

namespace Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			RegisterStaticDataService();
			RegisterGameFactory();
			RegisterAssets();
			RegisterPersistentProgressService();
			RegisterSaveLoadService();
			RegisterRandomService();
		}

		private void RegisterStaticDataService() => 
			Container.Bind<StaticDataService>().AsSingle();

		private void RegisterGameFactory() => 
			Container.Bind<GameFactory>().AsSingle();

		private void RegisterAssets() => 
			Container.Bind<Assets>().AsSingle();

		private void RegisterPersistentProgressService() => 
			Container.Bind<PersistentProgressService>().AsSingle();

		private void RegisterSaveLoadService() => 
			Container.BindInterfacesAndSelfTo<SaveLoadService>().AsSingle();

		private void RegisterRandomService() => 
			Container.Bind<RandomService>().AsSingle();
	}
}
