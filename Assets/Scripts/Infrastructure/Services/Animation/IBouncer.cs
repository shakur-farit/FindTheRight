using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public interface IBouncer
	{
		UniTask DoBounceEffect(Transform transform, float scalingValue, float duration);
	}
}