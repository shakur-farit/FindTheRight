using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Shake Animation Static Data", menuName = "ScriptableObjects/Static Data/Animation/Shake Animation")]
	public class ShakeAnimationStaticData : ScriptableObject
	{
		public float ShakeDuration;
		public float ShakeStrength;
		public int ShakeVibrato;
		public float ShakeRandomness;
	}
}