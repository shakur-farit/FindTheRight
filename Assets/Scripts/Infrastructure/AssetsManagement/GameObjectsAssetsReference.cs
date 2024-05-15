using UnityEngine;

namespace Infrastructure.AssetsManagement
{
	[CreateAssetMenu(fileName = "Assets Reference", menuName = "ScriptableObjects/Assets Reference/Game Objects")]
	public class GameObjectsAssetsReference : ScriptableObject
	{
		public string ClickDetectorAddress;
		public string FXStarAddress;
		public string GridParentAddress;
		public string GridAddress;
		public string CellAddress;
		public string ContentAddress;
		public string HudAddress;
		public string UIRootAddress;
		public string MainMenuWindowAddress;
		public string GameCompleteWindowAddress;
	}
}