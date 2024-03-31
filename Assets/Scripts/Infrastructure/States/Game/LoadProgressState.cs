using CellContent;
using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;

namespace Infrastructure.States.Game
{
	public class LoadProgressState : IState
	{
		private readonly PersistentProgressService _progressService;
		private readonly GameStateMachine _gameStateMachine;
		private readonly StaticDataService _staticDataService;

		public LoadProgressState(GameStateMachine gameStateMachine, PersistentProgressService progressService, StaticDataService staticDataService)
		{
			_gameStateMachine = gameStateMachine;
			_progressService = progressService;
			_staticDataService = staticDataService;
		}

		public void Enter()
		{
			_progressService.Progress = InitNewProgress();
			SortContentData();
			SetupClickDetectorData();
			EnterLoadSceneState();
		}

		private void EnterLoadSceneState() => 
			_gameStateMachine.Enter<LoadSceneState>();

		private Progress InitNewProgress() =>
		new Progress();

		private void SortContentData()
		{
			foreach (ContentStaticData content in _staticDataService.ForContent.ContentList)
			{
				if (content.Type == ContentType.Letters)
					_progressService.Progress.ContentData.Letters.Add(content);

				if (content.Type == ContentType.Numbers)
					_progressService.Progress.ContentData.Numbers.Add(content);
			}
		}

		private void SetupClickDetectorData() => 
			_progressService.Progress.ClickDetectorData.CanClick = true;
	}
}