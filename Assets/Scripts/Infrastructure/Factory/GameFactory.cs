using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using UnityEngine;

namespace Infrastructure.Factory
{
	public class GameFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private AssetsReference _reference;
		private readonly IGameObjectsCreateService _gameObjectsCreateService;

		public Transform GridParent { get; private set; }
		public GameObject Grid { get; private set; }
		public GameObject Cell { get; private set; }
		public GameObject Content { get; private set; }
		public GameObject Hud { get; private set; }
		public GameObject ClickDetector { get; private set; }

		public GameFactory(AssetsProvider assetsProvider, IGameObjectsCreateService gameObjectsCreateService)
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

		public async UniTask<GameObject> CreateCell(Transform parentTransform)
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(_reference.CellAddress);
			return Cell = _gameObjectsCreateService.Instantiate(prefab, parentTransform);
		}

		public async UniTask<GameObject> CreateContent(Transform parentTransform)
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(_reference.ContentAddress);
			return Content = _gameObjectsCreateService.Instantiate(prefab, parentTransform);
		}

		public async UniTask CreateHud()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(_reference.HudAddress);
			Hud = _gameObjectsCreateService.Instantiate(prefab);
		}

		public async UniTask CreateClickDetector()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(_reference.ClickDetectorAddress);
			ClickDetector = _gameObjectsCreateService.Instantiate(prefab);
		}

		public void DestroyGridParent() =>
			Object.Destroy(GridParent.gameObject);

		public void DestroyHud() =>
			Object.Destroy(Hud);

		public void DestroyClickDetector() => 
			Object.Destroy(ClickDetector);

		private async void LoadAssetsReference() => 
			_reference = await _assetsProvider.Load<AssetsReference>(AssetsAddress.AssetsReferenceAddress);
	}
}