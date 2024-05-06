using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Events;
using GridLogic;
using GridLogic.Factory;
using Infrastructure.Services.Animation;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using Infrastructure.Services.StaticData;
using SearchIntent;
using StaticData;

namespace Infrastructure.States.LevelDifficultly
{
	public abstract class LevelDifficulty
	{
		protected string LevelId;
		protected bool CanAnimateGrid;
		protected LevelStaticData DifficultyLevel;

		protected readonly StaticDataService StaticData;
		protected readonly PersistentProgressService PersistentProgressService;
		protected readonly RandomService RandomService;
		protected readonly IGridFactory GridFactory;
		protected readonly IBouncer Bouncer;
		protected readonly ILevelCompleteEvent LevelCompleteEvent;

		private readonly ISearchIntentGenerator _searchIntentGenerator;
		private readonly IGridGenerator _gridGenerator;

		protected LevelDifficulty(StaticDataService staticData, PersistentProgressService persistentProgressService,
			RandomService randomService, IGridFactory gridFactory, IBouncer bouncer, 
			ILevelCompleteEvent levelCompleteEvent, ISearchIntentGenerator searchIntentGenerator, IGridGenerator gridGenerator)
		{
			StaticData = staticData;
			PersistentProgressService = persistentProgressService;
			RandomService = randomService;
			GridFactory = gridFactory;
			Bouncer = bouncer;
			LevelCompleteEvent = levelCompleteEvent;
			_searchIntentGenerator = searchIntentGenerator;
			_gridGenerator = gridGenerator;
		}

		public async void Enter()
		{
			LevelCompleteEvent.LevelCompleted += EnterNextState;

			SetupLevelData();
			SetupLevel(LevelId);
			SetupGridData();
			SetupContent();
			await GenerateGrid(CanAnimateGrid);
			GenerateSearchIntent();
		}

		protected abstract void EnterNextState();

		protected abstract void SetupLevelData();

		private void SetupLevel(string levelId)
		{
			foreach (LevelStaticData level in StaticData.ForLevels.LevelstList)
			{
				if (level.LevelId.ToUpper() == levelId.ToUpper())
				{
					PersistentProgressService.Progress.LevelData.Level = level;
					DifficultyLevel = level;
				}
			}
		}

		private void SetupGridData()
		{
			PersistentProgressService.Progress.GridData.RowsNumber = DifficultyLevel.RowsNumber;
			PersistentProgressService.Progress.GridData.ColumnNumber = DifficultyLevel.ColumnsNumber;
			PersistentProgressService.Progress.GridData.CellSize = DifficultyLevel.CellSize;
		}

		private void SetupContent()
		{
			List<List<ContentStaticData>> contentList = new List<List<ContentStaticData>>
			{
				PersistentProgressService.Progress.ContentData.Letters,
				PersistentProgressService.Progress.ContentData.Numbers
			};

			List<ContentStaticData> currentContent = RandomService.GetRandomContentList(contentList);
			PersistentProgressService.Progress.ContentData.CurrentContent = currentContent;
		}

		private async UniTask GenerateGrid(bool canAnimate)
		{
			await _gridGenerator.GenerateGrid(canAnimate);
		}

		private void GenerateSearchIntent() => 
			_searchIntentGenerator.GenerateSearchIntent();
	}
}