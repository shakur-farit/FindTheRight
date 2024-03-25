using System.Collections.Generic;
using CellGrid;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Content Static Data", menuName = "ScriptableObjects/Static Data/Content")]
	public class ContentStaticData : ScriptableObject
	{
		public List<Content> ContentList;
	}
}