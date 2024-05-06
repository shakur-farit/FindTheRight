using Cysharp.Threading.Tasks;

namespace GridLogic
{
	public interface IGridGenerator
	{
		UniTask GenerateGrid(bool canAnimate);
	}
}