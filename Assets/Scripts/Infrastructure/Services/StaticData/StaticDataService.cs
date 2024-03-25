using CellGrid;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private const string EasyLevelGridStaticDataPath = "StaticData/Easy Level Grid Static Data";
		private const string MediumLevelGridStaticDataPath = "StaticData/Medium Level Grid Static Data";
		private const string HardLevelGridStaticDataPath = "StaticData/Hard Level Grid Static Data";
		private const string ContentStaticDataPath = "Prefabs/Content";

		public GridStaticData ForEasyLevelGrid { get; private set; }
		public GridStaticData ForMediumLevelGrid { get; private set; }
		public GridStaticData ForHardLevelGrid { get; private set; }
		public Content[] ForContent { get; private set; }
		public void Load()
		{
			ForEasyLevelGrid = Resources.Load<GridStaticData>(EasyLevelGridStaticDataPath);
			ForMediumLevelGrid = Resources.Load<GridStaticData>(MediumLevelGridStaticDataPath);
			ForHardLevelGrid = Resources.Load<GridStaticData>(HardLevelGridStaticDataPath);
			ForContent = Resources.LoadAll<Content>(ContentStaticDataPath);
		}
	}
}