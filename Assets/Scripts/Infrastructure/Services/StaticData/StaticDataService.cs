using CellContent;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private const string EasyLevelGridStaticDataPath = "StaticData/Easy Level Grid Static Data";
		private const string MediumLevelGridStaticDataPath = "StaticData/Medium Level Grid Static Data";
		private const string HardLevelGridStaticDataPath = "StaticData/Hard Level Grid Static Data";
		private const string BounceAnimationStaticDataPath = "StaticData/Bounce Animation Static Data";
		private const string LettersContentStaticDataPath = "Prefabs/Content/Letters";
		private const string NumbersContentStaticDataPath = "Prefabs/Content/Numbers";

		public GridStaticData ForEasyLevelGrid { get; private set; }
		public GridStaticData ForMediumLevelGrid { get; private set; }
		public GridStaticData ForHardLevelGrid { get; private set; }
		public BounceAnimationStaticData ForBounceAnimation { get; private set; }
		public Content[] ForLettersContent { get; private set; }
		public Content[] ForNumbersContent { get; private set; }

		public void Load()
		{
			ForEasyLevelGrid = Resources.Load<GridStaticData>(EasyLevelGridStaticDataPath);
			ForMediumLevelGrid = Resources.Load<GridStaticData>(MediumLevelGridStaticDataPath);
			ForHardLevelGrid = Resources.Load<GridStaticData>(HardLevelGridStaticDataPath);
			//ForBounceAnimation = Resources.Load<BounceAnimationStaticData>(BounceAnimationStaticDataPath);
			ForLettersContent = Resources.LoadAll<Content>(LettersContentStaticDataPath);
			ForNumbersContent = Resources.LoadAll<Content>(NumbersContentStaticDataPath);
		}
	}
}