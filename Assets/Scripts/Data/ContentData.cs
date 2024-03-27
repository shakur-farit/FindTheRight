using System;
using System.Collections.Generic;
using CellContent;
using CellGrid;

namespace Data
{
	[Serializable]
	public class ContentData
	{
		public List<Content> UsedInGame = new List<Content>();
		public List<Content> UsedInLevel = new List<Content>();
	}
}