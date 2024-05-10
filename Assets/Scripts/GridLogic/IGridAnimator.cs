using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GridLogic
{
	public interface IGridAnimator
	{
		UniTask BounceGrid(Transform gridParent);
	}
}