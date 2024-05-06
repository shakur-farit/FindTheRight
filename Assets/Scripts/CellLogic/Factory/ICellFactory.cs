using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CellLogic.Factory
{
	public interface ICellFactory
	{
		GameObject Cell { get; }
		UniTask<GameObject> CreateCell(Transform parentTransform);
	}
}