using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Levels Static Data List", menuName = "ScriptableObjects/Static Data/Lists/Levels")]
	public class LevelStaticDataList : ScriptableObject
	{
		public List<LevelStaticData> LevelstList;
	}
}