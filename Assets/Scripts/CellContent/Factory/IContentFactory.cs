using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CellContent.Factory
{
	public interface IContentFactory
	{
		GameObject Content { get; }
		UniTask<GameObject> CreateContent(Transform parentTransform);
	}
}