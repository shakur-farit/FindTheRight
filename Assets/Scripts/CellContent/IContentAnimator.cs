using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CellContent
{
	public interface IContentAnimator
	{
		void DoShakeEffect(Transform transform);
		UniTask BounceContent(Transform transform);
	}
}