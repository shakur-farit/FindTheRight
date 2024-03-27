using System.Threading.Tasks;
using Infrastructure.AssetsManagement;
using UnityEngine;

namespace FX
{
	public class FXFactory
	{
		private readonly Assets _assets;

		public GameObject StarFx { get; private set; }

		public async Task WarmUp() => 
			await _assets.Instantiate<GameObject>(AssetsAddress.StarFx);

		public FXFactory(Assets assets) => 
			_assets = assets;

		public async Task CreateStarFx()
		{
			GameObject prefab = await _assets.Instantiate<GameObject>(AssetsAddress.StarFx);
			StarFx = _assets.Instantiate(prefab);
		}

		public void DestroyStarFx() => 
			Object.Destroy(StarFx);
	}
}
