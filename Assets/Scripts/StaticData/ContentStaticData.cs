using CellContent;
using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Content Static Data", menuName = "ScriptableObjects/Static Data/Content")]
	public class ContentStaticData : ScriptableObject
	{
		public ContentType Type;
		public string Id;
		public Sprite Sprite;
	}
}