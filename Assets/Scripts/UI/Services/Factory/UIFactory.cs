using Cysharp.Threading.Tasks;
using Infrastructure.AssetsManagement;
using Infrastructure.Services.GameObjectsCreate;
using UnityEngine;

namespace UI.Services.Factory
{
	public class UIFactory : IUIFactory
	{
		private readonly AssetsProvider _assetsProvider;
		private GameObjectsAssetsReference _reference;
		private readonly IGameObjectsCreateService _gameObjectsCreateService;

		public Transform UIRoot { get; private set; }
		public GameObject GameCompleteWindow { get; private set; }

		public UIFactory(AssetsProvider assetsProvider, IGameObjectsCreateService gameObjectsCreateService)
		{
			_assetsProvider = assetsProvider;
			_gameObjectsCreateService = gameObjectsCreateService;

			LoadAssetsReference();
		}

		public async UniTask CreateUIRoot()
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(_reference.UIRootAddress);
			UIRoot = _gameObjectsCreateService.Instantiate(prefab).transform;
		}

		public async UniTask CreateGameCompleteWindow(Transform parentTransform)
		{
			GameObject prefab = await _assetsProvider.Load<GameObject>(_reference.GameCompleteWindowAddress);
			GameCompleteWindow = _gameObjectsCreateService.Instantiate(prefab, parentTransform);
		}

		public void DestroyUIRoot() => 
			Object.Destroy(UIRoot.gameObject);

		public void DestroyGameCompleteWindow() => 
			Object.Destroy(GameCompleteWindow);

		private async void LoadAssetsReference() => 
			_reference = await _assetsProvider.Load<GameObjectsAssetsReference>(AssetsAddress.GameObjectsAssetsReferenceAddress);
	}
}
