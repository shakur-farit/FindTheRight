using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.GameObjectsCreate;
using UnityEngine;

namespace Hud.Factory
{
	public class HudFactory : IHudFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly IGameObjectsCreateService _gameObjectsCreateService;

		public GameObject Hud { get; private set; }

		public HudFactory(AssetsProvider assetsProvider, IGameObjectsCreateService gameObjectsCreateService)
		{
			_assetsProvider = assetsProvider;
			_gameObjectsCreateService = gameObjectsCreateService;
		}

		public async UniTask CreateHud()
		{
			GameObjectsAssetsReference reference = await _assetsProvider.Load<GameObjectsAssetsReference>(AssetsAddress.GameObjectsAssetsReferenceAddress);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.HudAddress);
			Hud = _gameObjectsCreateService.Instantiate(prefab);
		}

		public void DestroyHud() =>
			Object.Destroy(Hud);

	}
}