using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Bounce Animation Static Data", menuName = "ScriptableObjects/Static Data/Animation/Bounce Animation")]
	public class BounceAnimationStaticData : ScriptableObject
	{
		public float BounceScaling;
		public float BounceDuration;
	}
}