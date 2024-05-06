using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.GameObjectsCreate;
using UnityEngine;

namespace ClickDetector.Factory
{
	public class ClickDetectorFactory : IClickDetectorFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly IGameObjectsCreateService _gameObjectsCreateService;

		public GameObject ClickDetector { get; private set; }

		public ClickDetectorFactory(AssetsProvider assetsProvider, IGameObjectsCreateService gameObjectsCreateService)
		{
			_assetsProvider = assetsProvider;
			_gameObjectsCreateService = gameObjectsCreateService;
		}

		public void DestroyClickDetector() =>
			Object.Destroy(ClickDetector);

		public async UniTask CreateClickDetector()
		{
			AssetsReference reference = await _assetsProvider.Load<AssetsReference>(AssetsAddress.AssetsReferenceAddress);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.ClickDetectorAddress);
			ClickDetector = _gameObjectsCreateService.Instantiate(prefab);
		}
	}
}