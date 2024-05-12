using UnityEngine;

namespace StaticData.Animation
{
	[CreateAssetMenu(fileName = "Fade InOut Animation Static Data", menuName = "ScriptableObjects/Static Data/Animation/Fade InOut Animation")]
	public class FadeInOutAnimationStaticData : ScriptableObject
	{
		public float EndValue;
		public float Duration;
	}
}