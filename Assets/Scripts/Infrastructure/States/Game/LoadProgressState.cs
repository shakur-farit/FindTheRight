using CellContent;
using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticData;
using StaticData;

namespace Infrastructure.States.Game
{
	public class LoadProgressState : IState
	{
		private readonly PersistentProgressService _progressService;
		private readonly GameStateMachine _gameStateMachine;
		private readonly ILoadService _loadService;
		private readonly StaticDataService _staticDataService;

		public LoadProgressState(GameStateMachine gameStateMachine, PersistentProgressService progressService, 
			ILoadService loadService, StaticDataService staticDataService)
		{
			_gameStateMachine = gameStateMachine;
			_progressService = progressService;
			_loadService = loadService;
			_staticDataService = staticDataService;
		}

		public void Enter()
		{
			LoadProgressOrInitNew();
			SortContentData();
			EnterLoadSceneState();
		}

		private void EnterLoadSceneState() => 
			_gameStateMachine.Enter<LoadSceneState>();

		private void LoadProgressOrInitNew() =>
			_progressService.Progress = _loadService.LoadProgress() ?? InitNewProgress();

		private Progress InitNewProgress() =>
		new Progress();

		private void SortContentData()
		{
			foreach (ContentStaticData content in _staticDataService.ForContent)
			{
				if (content.Type == ContentType.Letters)
					_progressService.Progress.ContentData.Letters.Add(content);

				if (content.Type == ContentType.Numbers)
					_progressService.Progress.ContentData.Numbers.Add(content);
			}
		}
	}
}