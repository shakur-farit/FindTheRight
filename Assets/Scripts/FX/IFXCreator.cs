using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FX
{
	public interface IFXCreator
	{
		UniTask CreateStarEffect(Transform transform);
	}
}