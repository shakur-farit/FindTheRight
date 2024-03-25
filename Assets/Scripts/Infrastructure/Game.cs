using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgressService;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticData;
using Infrastructure.States.Game;
using Infrastructure.States.LevelDifficultly;

namespace Infrastructure
{
	public class Game
	{
		public GameStateMachine GameStateMachine { get; }

		public Game(StaticDataService staticDataService, GameFactory gameFactory,
			PersistentProgressService persistentProgressService, ILoadService loadService)
		{
			LevelStateMachine levelStateMachine =
				new LevelStateMachine(persistentProgressService, staticDataService, gameFactory);
			
			GameStateMachine = new GameStateMachine(staticDataService, gameFactory, persistentProgressService,
				loadService, levelStateMachine);
		}
	}
}