using System;
using System.Collections.Generic;
using CellContent;
using StaticData;
using UnityEngine;

namespace Data
{
	[Serializable]
	public class ContentData
	{
		public ContentType Type;
		public string Id;
		public Sprite Sprite;

		public List<ContentStaticData> UsedInGame = new();
		public List<ContentStaticData> UsedInLevel = new();

		public List<ContentStaticData> Letters = new();
		public List<ContentStaticData> Numbers = new();

		public List<ContentStaticData> CurrentContent = new();
	}
}