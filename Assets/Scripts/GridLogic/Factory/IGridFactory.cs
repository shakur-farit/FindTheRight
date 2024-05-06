using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GridLogic.Factory
{
	public interface IGridFactory
	{
		Transform GridParent { get; }
		GameObject Grid { get; }
		UniTask CreateGridParent();
		UniTask CreateGrid();
		void DestroyGridParent();
	}
}