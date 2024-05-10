using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UI.Windows
{
	public interface IRestartButtonAnimator
	{
		UniTask Animate(Transform transform);
	}
}