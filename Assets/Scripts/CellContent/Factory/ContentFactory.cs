using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.GameObjectsCreate;
using UnityEngine;

namespace CellContent.Factory
{
	public class ContentFactory : IContentFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly IGameObjectsCreateService _gameObjectsCreateService;

		public GameObject Content { get; private set; }

		public ContentFactory(AssetsProvider assetsProvider, IGameObjectsCreateService gameObjectsCreateService)
		{
			_assetsProvider = assetsProvider;
			_gameObjectsCreateService = gameObjectsCreateService;
		}

		public async UniTask<GameObject> CreateContent(Transform parentTransform)
		{
			GameObjectsAssetsReference reference = await _assetsProvider.Load<GameObjectsAssetsReference>(AssetsAddress.GameObjectsAssetsReferenceAddress);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.ContentAddress);
			return Content = _gameObjectsCreateService.Instantiate(prefab, parentTransform);
		}
	}
}