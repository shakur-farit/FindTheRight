using Infrastructure.AssetsManagement;
using UnityEngine;

namespace FX
{
	public class FXFactory
	{
		private readonly Assets _assets;

		public GameObject StarFx { get; private set; }

		public FXFactory(Assets assets) => 
			_assets = assets;

		public void CreateStarFx() =>
			StarFx = _assets.Instantiate(AssetsPath.StarFx);

		public void DestroyStarFx() => 
			Object.Destroy(StarFx);
	}
}
