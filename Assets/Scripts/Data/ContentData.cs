using System;
using System.Collections.Generic;
using StaticData;

namespace Data
{
	[Serializable]
	public class ContentData
	{
		public List<ContentStaticData> UsedInGame = new List<ContentStaticData>();
		public List<ContentStaticData> UsedInLevel = new List<ContentStaticData>();

		public List<ContentStaticData> Letters = new List<ContentStaticData>();
		public List<ContentStaticData> Numbers = new List<ContentStaticData>();

		public List<ContentStaticData> CurrentContent = new List<ContentStaticData>();
	}
}