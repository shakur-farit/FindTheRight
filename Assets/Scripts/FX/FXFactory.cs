using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.GameObjectsCreate;
using UnityEngine;

namespace FX
{
	public class FXFactory : IFXFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly IGameObjectsCreateService _gameObjectsCreateService;

		public GameObject StarFx { get; private set; }

		public FXFactory(AssetsProvider assetsProvider, IGameObjectsCreateService gameObjectsCreateService)
		{
			_assetsProvider = assetsProvider;
			_gameObjectsCreateService = gameObjectsCreateService;
		}

		public async UniTask CreateStarFx()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsAddress.AssetsReferenceAddress);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.FXStarAddress);
			StarFx = _gameObjectsCreateService.Instantiate(prefab);
		}

		public void DestroyStarFx() => 
			Object.Destroy(StarFx);
	}
}
