using System;

namespace Data
{
	[Serializable]
	public class Progress
	{
		public GridData GridData = new GridData();
		public ContentData ContentData = new ContentData();
		public SearchIntentData SearchIntentData = new SearchIntentData();
		public LevelData LevelData = new LevelData();
	}
}