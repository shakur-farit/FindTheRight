using UnityEngine;

namespace StaticData
{
	[CreateAssetMenu(fileName = "Rotate Animation Static Data", menuName = "ScriptableObjects/Static Data/Animation/Rotate Animation")]
	public class RotateAnimationStaticData : ScriptableObject
	{
		public float XAngle; 
		public float YAngle;
		public float ZAngle;
		public float RotateDuration;
	}
}