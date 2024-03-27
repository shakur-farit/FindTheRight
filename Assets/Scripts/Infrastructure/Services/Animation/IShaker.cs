using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public interface IShaker
	{
		void DoShakeEffect(Transform transform, float duration, float strength, int vibrato, float randomness);
	}
}