using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgressService;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticData;
using Infrastructure.States;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine GameStateMachine { get; }

		public Game(StaticDataService staticDataService, GameFactory gameFactory,
			PersistentProgressService persistentProgressService, ILoadService loadService) => 
			GameStateMachine = new GameStateMachine(staticDataService, gameFactory, persistentProgressService, loadService);
	}
}