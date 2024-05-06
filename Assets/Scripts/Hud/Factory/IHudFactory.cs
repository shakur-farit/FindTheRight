using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Hud.Factory
{
	public interface IHudFactory
	{
		GameObject Hud { get; }
		UniTask CreateHud();
		void DestroyHud();
	}
}