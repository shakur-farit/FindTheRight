using FX;
using Infrastructure.AssetsManagement;
using Infrastructure.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Game;
using UI.Services.Factory;
using UI.Services.Window;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine GameStateMachine { get; }

		public Game(StaticDataService staticDataService, GameFactory gameFactory, UIFactory uiFactory,
			PersistentProgressService persistentProgressService, ILoadService loadService,
			RandomService randomService, WindowService windowService, IBouncer bouncer, Assets assets, FXFactory fxFactory)
		{
			GameStateMachine = new GameStateMachine(staticDataService, gameFactory, uiFactory, persistentProgressService,
				loadService, randomService, windowService, bouncer, assets, fxFactory);
		}
	}
}