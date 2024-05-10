using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.Animation
{
	public interface IRotator
	{
		UniTask DoRotate(Transform transform, Vector3 endValue, float duration);
	}
}