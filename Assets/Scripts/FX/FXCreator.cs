using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FX
{
	public class FXCreator : IFXCreator
	{
		private readonly IFXFactory _fxFactory;

		public FXCreator(IFXFactory fxFactory) =>
			_fxFactory = fxFactory;

		public async UniTask CreateStarEffect(Transform transform)
		{
			await _fxFactory.CreateStarFx();
			_fxFactory.StarFx.transform.position = transform.position;
		}
	}
}