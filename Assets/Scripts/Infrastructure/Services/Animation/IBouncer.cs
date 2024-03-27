using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public interface IBouncer
	{
		void DoBounceEffect(Transform transform, float scalingValue, float duration);
	}
}