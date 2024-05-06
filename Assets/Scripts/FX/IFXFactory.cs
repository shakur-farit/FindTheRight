using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FX
{
	public interface IFXFactory
	{
		GameObject StarFx { get; }
		UniTask CreateStarFx();
		void DestroyStarFx();
	}
}