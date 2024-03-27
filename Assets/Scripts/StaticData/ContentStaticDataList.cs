using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Content Static Data List", menuName = "ScriptableObjects/Static Data/Lists/Content")]
	public class ContentStaticDataList : ScriptableObject
	{
		public List<ContentStaticData> ContentList;
	}
}