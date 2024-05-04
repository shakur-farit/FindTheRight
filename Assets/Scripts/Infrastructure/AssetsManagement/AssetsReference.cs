using UnityEngine;
using UnityEngine.Serialization;

namespace Infrastructure.AssetsManagement
{
	[CreateAssetMenu(fileName = "Assets Reference", menuName = "ScriptableObjects/Assets Reference")]
	public class AssetsReference : ScriptableObject
	{
		public string ClickDetectorAddress;
		public string FXStarAddress;
		public string GridParentAddress;
		public string GridAddress;
		public string CellAddress;
		public string ContentAddress;
		public string HudAddress;
		public string UIRootAddress;
		public string GameCompleteWindowAddress;
	}
}