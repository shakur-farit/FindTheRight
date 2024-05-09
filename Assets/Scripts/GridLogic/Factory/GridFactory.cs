using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.GameObjectsCreate;
using UnityEngine;

namespace GridLogic.Factory
{
	public class GridFactory : IGridFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private GameObjectsAssetsReference _reference;
		private readonly IGameObjectsCreateService _gameObjectsCreateService;

		public Transform GridParent { get; private set; }
		public GameObject Grid { get; private set; }

		public GridFactory(AssetsProvider assetsProvider, IGameObjectsCreateService gameObjectsCreateService)
		{
			_assetsProvider = assetsProvider;
			_gameObjectsCreateService = gameObjectsCreateService;

			LoadAssetsReference();
		}

		public async UniTask CreateGridParent()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(_reference.GridParentAddress);
			GridParent = _gameObjectsCreateService.Instantiate(prefab).transform;
		}

		public async UniTask CreateGrid()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(_reference.GridAddress);
			Grid = _gameObjectsCreateService.Instantiate(prefab);
		}

		public void DestroyGrid() => 
			Object.Destroy(Grid);

		public void DestroyGridParent() =>
			Object.Destroy(GridParent.gameObject);

		private async void LoadAssetsReference() => 
			_reference = await _assetsProvider.Load<GameObjectsAssetsReference>(AssetsAddress.GameObjectsAssetsReferenceAddress);
	}
}