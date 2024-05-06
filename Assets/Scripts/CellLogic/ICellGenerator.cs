using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CellLogic
{
	public interface ICellGenerator
	{
		UniTask CreateCell(int column, int row, float cellSize, Transform parentTransform);
	}
}