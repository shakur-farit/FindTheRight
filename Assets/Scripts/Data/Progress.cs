using System;

namespace Data
{
	[Serializable]
	public class Progress
	{
		public GridData GridData = new();
		public ContentData ContentData = new();
		public SearchIntentData SearchIntentData = new();
		public LevelData LevelData = new();
		public ClickDetectorData ClickDetectorData = new();
	}
}