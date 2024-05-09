using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.GameObjectsCreate;
using UnityEngine;

namespace CellLogic.Factory
{
	public class CellFactory : ICellFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private readonly IGameObjectsCreateService _gameObjectsCreateService;

		public GameObject Cell { get; private set; }

		public CellFactory(AssetsProvider assetsProvider, IGameObjectsCreateService gameObjectsCreateService)
		{
			_assetsProvider = assetsProvider;
			_gameObjectsCreateService = gameObjectsCreateService;
		}

		public async UniTask<GameObject> CreateCell(Transform parentTransform)
		{
			GameObjectsAssetsReference reference = await _assetsProvider.Load<GameObjectsAssetsReference>(AssetsAddress.GameObjectsAssetsReferenceAddress);
			GameObject prefab = await _assetsProvider.Load<GameObject>(reference.CellAddress);
			return Cell = _gameObjectsCreateService.Instantiate(prefab, parentTransform);
		}
	}
}