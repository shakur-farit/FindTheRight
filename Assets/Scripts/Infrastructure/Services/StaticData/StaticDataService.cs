using CellContent;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private const string LevelsStaticDataPath = "StaticData/Levels";
		private const string ContentStaticDataPath = "StaticData/Content";
		private const string LettersContentStaticDataPath = "Prefabs/Content/Letters";
		private const string NumbersContentStaticDataPath = "Prefabs/Content/Numbers";

		public LevelStaticData[] ForLevels { get; private set; }
		public ContentStaticData[] ForContent { get; private set; }

		public void Load()
		{
			ForLevels = Resources.LoadAll<LevelStaticData>(LevelsStaticDataPath);
			ForContent = Resources.LoadAll<ContentStaticData>(ContentStaticDataPath);
		}
	}
}