using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
	public class StaticDataService
	{
		private const string GridStaticDataPath = "StaticData/Grid Static Data";
		private const string CellContentStaticDataPath = "StaticData/Content Static Data";

		public GridStaticData ForGrid { get; private set; }
		public ContentStaticData ForContent { get; private set; }

		public void Load()
		{
			ForGrid = Resources.Load<GridStaticData>(GridStaticDataPath);
			ForContent = Resources.Load<ContentStaticData>(CellContentStaticDataPath);
		}
	}
}