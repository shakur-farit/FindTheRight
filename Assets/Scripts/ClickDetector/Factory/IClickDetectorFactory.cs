using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ClickDetector.Factory
{
	public interface IClickDetectorFactory
	{
		GameObject ClickDetector { get; }
		void DestroyClickDetector();
		UniTask CreateClickDetector();
	}
}