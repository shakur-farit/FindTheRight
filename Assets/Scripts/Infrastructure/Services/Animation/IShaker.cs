using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public interface IShaker
	{
		UniTask DoShakeEffect(Transform transform, float duration, float strength, int vibrato, float randomness);
	}
}